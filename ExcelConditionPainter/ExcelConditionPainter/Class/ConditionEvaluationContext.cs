using DocumentFormat.OpenXml.Drawing;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ExcelConditionPainter
{
    public class ConditionEvaluationContext
    {
        // 조건 검색에 쓰이는 데이터 (사용자가 Setup창에서 설정한 값 데이터)
        public readonly string PrimaryColumnName; // 기본키
        public readonly string BuyCountColumnName;  
        public readonly string OptionColumnName;
        public readonly ReadOnlyDictionary<string, int> GoodsQuantitiesByOption;
        public readonly DataTable ConditionTable;
        // 조건 건색에 쓰이는 데이터(엑셀 전체 중 조건에 맞는 값을 한번은 계산해야 하는 값 데이터)
        public readonly Dictionary<string, Dictionary<string, DistinctOrderConditionCalculation>> DistinctOrderCalculationsBySelection;       // 중복제외 순서 찾는 조건 관련 결과 가지는 
        public readonly Dictionary<string, Dictionary<string, QuantityConditionCalculation>> QuantityCalculationsBySelection;  // Quantity 조건 관련 결과를 가지는 Dic

        // 조건 검색 적용된 레벨 값, Value: IConditionSettings - 
        public readonly Dictionary<string, List<IConditionRule>> ConditionsByPrimaryValue; //각 Row(PrimaryKey) 마다 어떤 조건이 적용되어 있는지 나타냄 <Key : PrimaryKey, Value : 적용되어 있는 Conditions>

        public ConditionEvaluationContext(string primaryColumnName, string buyCountColumnName, string optionColumnName, Dictionary<string, int> goodsQuantitiesByOption, DataTable conditionTable)
        {
            PrimaryColumnName = primaryColumnName;
            BuyCountColumnName = buyCountColumnName;
            OptionColumnName = optionColumnName;
            GoodsQuantitiesByOption = new ReadOnlyDictionary<string, int>(goodsQuantitiesByOption);
            ConditionTable = conditionTable;

            DistinctOrderCalculationsBySelection = new Dictionary<string, Dictionary<string, DistinctOrderConditionCalculation>>();
            QuantityCalculationsBySelection = new Dictionary<string, Dictionary<string, QuantityConditionCalculation>>();

            ConditionsByPrimaryValue = new Dictionary<string, List<IConditionRule>>();
        }
        public bool TryAddCondition(string primaryKey, IConditionRule conditionRule)
        {
            if (ConditionsByPrimaryValue.TryGetValue(primaryKey, out List<IConditionRule> conditionRules))
            {
                int maxPriorityLevel = conditionRules.Max(x => x.PriorityLevel); // PrimaryKey를 가지는 Row에 적용되는 조건들중 가장 큰 PriorityLevel
                if (maxPriorityLevel > 0 &&             // 가장 큰 PriorityLevel이 0이상일대만 비교해야함
                    maxPriorityLevel < conditionRule.PriorityLevel) // 가장 큰 PriorityLevel이 지금 들어와야 하는 조건보다 작으면 조건 적용시키면 안됨
                    return false;
            }
            else
            {
                conditionRules = new List<IConditionRule>();
                ConditionsByPrimaryValue[primaryKey] = conditionRules;
            }
            conditionRules.Add(conditionRule); // PriorityLevel이 같으면 같이 칠한다, 나중에 색이 덧칠해지는건 따로 생각해봐야 할듯
            return true;
        }
        public void PaintDataGridView(DataGridView dataGridView)
        {
            dataGridView.DataSource = ConditionTable;
            DataTable dataTable = dataGridView.DataSource as DataTable;
            foreach(KeyValuePair<string, List<IConditionRule>> conditionEntry in ConditionsByPrimaryValue)
            {
                string primaryValue = conditionEntry.Key;
                int rowIndex = dataTable.Rows.IndexOf(dataTable.Rows.Find(primaryValue));
                if (rowIndex < 0)
                {
                    MessageBox.Show($"Row Index not found for {primaryValue} in {primaryValue} column", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // row를 못찾으면 아예 잘못된 값이라고 볼수있음 못찾으면 안됨
                    break;
                }
                DataGridViewRow row = dataGridView.Rows[rowIndex];
                List<IConditionRule> conditionRules = conditionEntry.Value;
                for (int i=0; i < conditionRules.Count; i++)
                    conditionRules[i].PaintRow(row);
            }
        }
    }
}
