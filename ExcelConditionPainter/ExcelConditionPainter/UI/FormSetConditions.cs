using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelConditionPainter
{
    public partial class FormSetConditions : Form
    {
        private readonly DataGridView dataGridView;
        private readonly string[] columnNames;
        private readonly int rowCount;
        private string[] optionNames;

        public ConditionEvaluationContext ConditionContext { get; private set; }

        public FormSetConditions(DataGridView dataGridView)
        {
            InitializeComponent();
            // 소스 전체에서 필요할때 사용할수 있도록 캐싱
            this.dataGridView = dataGridView;
            /////////////////////////////////////////////////////

            ConditionContext = null;
            DataTable dataTable = dataGridView.DataSource as DataTable;
            List<string> primaryKeyCandidates = new List<string>();

            int columnIndex = 0;
            int dateColumnIndex = -1; // 날짜 형식의 Col을 찾음
            int nameColumnIndex = -1;  // 이름 형식의 Col을 찾음
            int optionColumnIndex = -1; // 상품옵션 컬럼을 찾음
            int countColumnIndex = -1; // 상품수량 컬럼을 찾음

            columnNames = new string[dataTable.Columns.Count];
            rowCount = dataTable.Rows.Count;
            foreach (DataColumn column in dataTable.Columns)
            {
                string columnName = columnNames[columnIndex++] = column.ColumnName;
                primarySortColumnComboBox.Items.Add(columnName);
                secondarySortColumnComboBox.Items.Add(columnName);
                goodsOptionColumnComboBox.Items.Add(columnName);
                buyCountColumnComboBox.Items.Add(columnName);
                HashSet<string> uniqueValues = new HashSet<string>();
                bool hasNull = false;
                bool isDateColumn = true;

                foreach (DataRow row in dataTable.Rows)
                {
                    string value = row[column].ToString();
                    if (string.IsNullOrEmpty(value))
                    {
                        hasNull = true;
                        isDateColumn = false; // Null 이어도 찾은 컬럼은아님
                        break;
                    }
                    uniqueValues.Add(value);
                    if (!DateTime.TryParse(value, out _))
                    {
                        isDateColumn = false;
                    }
                }
                if (!hasNull && uniqueValues.Count == dataTable.Rows.Count)
                {
                    primaryKeyCandidates.Add(columnName);
                }
                if (optionColumnIndex == -1 && columnName.Contains("옵션"))
                {
                    optionColumnIndex = columnIndex - 1;
                }
                else if (countColumnIndex == -1 && columnName.Contains("수량"))
                {
                    countColumnIndex = columnIndex - 1;
                }
                else if (dateColumnIndex == -1 && isDateColumn)
                {
                    dateColumnIndex = columnIndex - 1;
                }
                else if (nameColumnIndex == -1 && columnName.Contains("주문자"))
                {
                    nameColumnIndex = columnIndex - 1;
                }
            }
            int candidateCount = primaryKeyCandidates.Count();
            if (candidateCount <= 0)
            {
                MessageBox.Show("데이터 잘못됨 엑셀 파일 확인 필요함 - 기본키 잘못됨");
                this.DialogResult = DialogResult.Abort;
                return;
            }

            for (int i = 0; i < candidateCount; i++)
                primaryKeyComboBox.Items.Add(primaryKeyCandidates[i]);

            primaryKeyComboBox.SelectedIndex = 0;
            primarySortColumnComboBox.SelectedIndex = dateColumnIndex < 0 ? 0 : dateColumnIndex;
            secondarySortColumnComboBox.SelectedIndex = nameColumnIndex < 0 ? 0 : nameColumnIndex;
            goodsOptionColumnComboBox.SelectedIndex = optionColumnIndex < 0 ? 0 : optionColumnIndex;
            buyCountColumnComboBox.SelectedIndex = countColumnIndex < 0 ? 0 : countColumnIndex;

            foreach (ConditionRuleType cond in Enum.GetValues(typeof(ConditionRuleType)))
            {
                addConditionComboBox.Items.Add(cond.GetDescription());
            }
            addConditionComboBox.SelectedIndex = 0;

            // 이부분 인터페이스로 뺄수 있면 빼자
            foreach (Control control in conditionFlowPanel.Controls)
            {
                if (control is IConditionRule conditionRule)
                {
                    string[] selectableItems;
                    if (conditionRule is OptionPurchaseOrderConditionControl)
                        selectableItems = optionNames;
                    else
                        selectableItems = columnNames;
                    conditionRule.SetSelectableItems(selectableItems, rowCount);
                }
            }
        }
        private void goodsOptionColumnComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dataTable = dataGridView.DataSource as DataTable;
                optionQuantityFlowPanel.SuspendLayout();
                optionQuantityFlowPanel.Controls.Clear();

                HashSet<string> uniqueValues = new HashSet<string>();
                string selectedColumn = goodsOptionColumnComboBox.SelectedItem.ToString();
                List<OptionQuantityControl> optionQuantityControls = new List<OptionQuantityControl>();
                foreach (DataRow row in dataTable.Rows)
                {
                    string value = row[selectedColumn].ToString();
                    if (string.IsNullOrEmpty(value) ||
                        uniqueValues.Contains(value))
                        continue;
                    uniqueValues.Add(value);
                    optionQuantityControls.Add(new OptionQuantityControl() { OptionName = value });
                }
                optionNames = uniqueValues.ToArray();
                optionQuantityFlowPanel.Controls.AddRange(optionQuantityControls.ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                optionQuantityFlowPanel.ResumeLayout();
            }
        }
        private void addConditionButton_Click(object sender, EventArgs e)
        {
            conditionFlowPanel.SuspendLayout(); // 레이아웃 일시 중지
            try
            {
                int maxPriorityLevel = conditionFlowPanel.Controls.OfType<IConditionRule>().Max(c => c.PriorityLevel) + 1;
                IConditionRule conditionRule;
                switch (addConditionComboBox.SelectedIndex)
                {
                    case (int)ConditionRuleType.Order:
                        conditionRule = new DistinctOrderConditionControl(columnNames, rowCount);
                        break;
                    case (int)ConditionRuleType.Duplicate:
                        conditionRule = new DuplicateConditionControl(columnNames, rowCount);
                        break;
                    case (int)ConditionRuleType.Quantity:
                        conditionRule = new QuantityConditionControl(columnNames, rowCount);
                        break;
                    case (int)ConditionRuleType.OptionBuyOrder:
                        conditionRule = new OptionPurchaseOrderConditionControl(optionNames, rowCount);
                        break;
                    default:
                        return;
                }
                conditionRule.PriorityLevel = maxPriorityLevel;
                conditionFlowPanel.Controls.Add(conditionRule as Control);
            }
            finally
            {
                conditionFlowPanel.ResumeLayout(false); // 레이아웃 다시 시작
                conditionFlowPanel.PerformLayout(); // 레이아웃 강제 업데이트서 
            }
        }
        private void setButton_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. 정렬 설정 
                string primarySortColumnName = primarySortColumnComboBox.SelectedItem.ToString();
                string secondarySortColumnName = secondarySortColumnComboBox.SelectedItem.ToString();
                DataTable dataTable = dataGridView.DataSource as DataTable;
                dataTable.DefaultView.Sort = $"{primarySortColumnName} ASC, {secondarySortColumnName} ASC"; // ASC 또는 DESC
                dataTable = dataTable.DefaultView.ToTable();

                // 2. 기본키 설정
                string primaryKey = primaryKeyComboBox.SelectedItem.ToString();
                DataColumn primaryKeyColumn = dataTable.Columns[primaryKey];
                dataTable.PrimaryKey = new DataColumn[] { primaryKeyColumn };
                
                // 3. 상품옵션 설정
                string buyCountColumnName = buyCountColumnComboBox.SelectedItem.ToString();
                string optionColumnName = goodsOptionColumnComboBox.SelectedItem.ToString();
                Dictionary<string, int> goodsQuantitiesByOption = new Dictionary<string, int>();
                foreach (Control control in optionQuantityFlowPanel.Controls)
                {
                    if (control is OptionQuantityControl optionQuantityControl)
                    {
                        if (string.IsNullOrEmpty(optionQuantityControl.OptionName))
                            continue;
                        goodsQuantitiesByOption.Add(optionQuantityControl.OptionName, optionQuantityControl.OptionCount);
                    }
                }

                // 5. 조건 계산
                int appliedConditionIndex = 0;
                ConditionContext = new ConditionEvaluationContext(primaryKey, buyCountColumnName, optionColumnName, goodsQuantitiesByOption, dataTable);
                ILookup<int, IConditionRule> lookups = conditionFlowPanel.Controls.OfType<IConditionRule>().ToLookup(c => c.PriorityLevel); // PriorityLevel 이 낮은 값부터 
                foreach (IGrouping<int, IConditionRule> group in lookups)
                {
                    foreach (IConditionRule conditionRule in group)
                    {
                        if (conditionRule.Evaluate(ConditionContext))
                            conditionRule.AppliedConditionIndex = ++appliedConditionIndex;
                    }
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
