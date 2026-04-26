using DocumentFormat.OpenXml.Drawing;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ExcelConditionPainter
{
    public class cConditionCalculator
    {
        // 조건 검색에 쓰이는 데이터 (사용자가 Setup창에서 설정한 값 데이터)
        public readonly string sPrimaryColName; // 기본키
        public readonly string sBuyCntColName;  
        public readonly string sOptionColName;
        public readonly ReadOnlyDictionary<string, int> dicGoodsQuntity;
        public readonly DataTable dtCondition;
        // 조건 건색에 쓰이는 데이터(엑셀 전체 중 조건에 맞는 값을 한번은 계산해야 하는 값 데이터)
        public readonly Dictionary<string, Dictionary<string, cOrderExceptDuplOptionCal>> dic2DOrderExceptDuplCal;       // 중복제외 순서 찾는 조건 관련 결과 가지는 
        public readonly Dictionary<string, Dictionary<string, cQuantityOptionCal>> dic2DQuantityCal;  // Quantity 조건 관련 결과를 가지는 Dic

        // 조건 검색 적용된 레벨 값, Value: ICondtionsCommon - 
        public readonly Dictionary<string, List<ICondtions>> dicRowConditions; //각 Row(PrimaryKey) 마다 어떤 조건이 적용되있는지 나타냄 <Key : PrimaryKey, Value : 적용되있는 Condtion들>

        public cConditionCalculator(string sPrimaryColName, string sBuyCntColName, string sOptionColName, Dictionary<string, int> dicGoodsQuntity, DataTable dtCondition)
        {
            this.sPrimaryColName = sPrimaryColName;
            this.sBuyCntColName = sBuyCntColName;
            this.sOptionColName = sOptionColName;
            this.dicGoodsQuntity = new ReadOnlyDictionary<string, int>(dicGoodsQuntity);
            this.dtCondition = dtCondition;

            dic2DOrderExceptDuplCal = new Dictionary<string, Dictionary<string, cOrderExceptDuplOptionCal>>();
            dic2DQuantityCal = new Dictionary<string, Dictionary<string, cQuantityOptionCal>>();

            dicRowConditions = new Dictionary<string, List<ICondtions>>();
        }
        public bool AddCondtions(string sPrimaryKey, ICondtions condtions)
        {
            if (dicRowConditions.TryGetValue(sPrimaryKey, out List<ICondtions> liCondtions))
            {
                int MaxLevel = liCondtions.Max(x => x.Level); // PrimaryKey를 가지는 Row에 적용되는 조건들중 가장 큰 Level
                if (MaxLevel > 0 &&             // 가장 큰 Level이 0이상일대만 비교해야함
                    MaxLevel < condtions.Level) // 가장 큰 Level이 지금 들어와야 하는 조건보다 작으면 조건 적용시키면 안됨
                    return false;
            }
            else
            {
                liCondtions = new List<ICondtions>();
                dicRowConditions[sPrimaryKey] = liCondtions;
            }
            liCondtions.Add(condtions); // Level이 같으면 같이 칠한다, 나중에 색이 덧칠해지는건 따로 생각해봐야 할듯
            return true;
        }
        public void PaintDataGridView(DataGridView dgv)
        {
            dgv.DataSource = dtCondition;
            DataTable dataTable = dgv.DataSource as DataTable;
            foreach(KeyValuePair<string, List<ICondtions>> kvp in dicRowConditions)
            {
                string sPrimaryValue = kvp.Key;
                int nRowIdx = dataTable.Rows.IndexOf(dataTable.Rows.Find(sPrimaryValue));
                if (nRowIdx < 0)
                {
                    MessageBox.Show($"Row Index not found for {sPrimaryValue} in {sPrimaryValue} column", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // row를 못찾으면 아예 잘못된 값이라고 볼수있음 못찾으면 안됨
                    break;
                }
                DataGridViewRow row = dgv.Rows[nRowIdx];
                List<ICondtions> liCondtions = kvp.Value;
                for (int i=0; i < liCondtions.Count; i++)
                    liCondtions[i].PaintRows(row);
            }
        }
    }
}
