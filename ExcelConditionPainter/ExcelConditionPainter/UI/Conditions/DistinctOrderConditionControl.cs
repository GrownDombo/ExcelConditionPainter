using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelConditionPainter
{
    public partial class DistinctOrderConditionControl : UserControl, IConditionRule
    {
        public int AppliedConditionIndex { get; set; }
        public DistinctOrderConditionControl()
        {
            InitializeComponent();
        }
        public DistinctOrderConditionControl(string[] columnNames, int rowCount) : this()
        {
            SetSelectableItems(columnNames, rowCount);
        }
        public void SetSelectableItems(string[] columnNames, int rowCount)
        {
            selectableColumnsComboBox.ItemClear();
            selectableColumnsComboBox.AddItemRange(columnNames);
            CheckBox checkBox = selectableColumnsComboBox.GetItems.FirstOrDefault(CheckBox => CheckBox.Text.Contains("주소"));
            if (checkBox != null)
                checkBox.Checked = true;
            peopleLimitInput.Maximum = rowCount;
        }
        #region UI
        [Category("Action")]
        [Description("Put PriorityLevel between 0~10")]
        public int PriorityLevel
        {
            get { return conditionCommonControl.PriorityLevel; }
            set { conditionCommonControl.PriorityLevel = value; }
        }
        [Category("Action")]
        [Description("Put Type of Painting Color")]
        public PaintTarget PaintTarget
        {
            get { return conditionCommonControl.PaintTarget; }
            set { conditionCommonControl.PaintTarget = value; }
        }
        [Category("Action")]
        [Description("Put Color to Paint")]
        public Color SelectedColor
        {
            get { return conditionCommonControl.SelectedColor; }
            set { conditionCommonControl.SelectedColor = SelectedColor; }
        }
        [Category("Action")]
        [Description("Put Goods Count")]
        public int PeopleLimit
        {
            get { return (int)peopleLimitInput.Value; }
            set
            {
                if (value > peopleLimitInput.Maximum)
                    value = (int)peopleLimitInput.Maximum;
                peopleLimitInput.Value = value;
            }
        }
        private void conditionCommonControl_DeleteButtonClick(object sender, EventArgs e)
        {
            Parent.Controls.Remove(this);
        }
        #endregion
        public bool Evaluate(ConditionEvaluationContext conditionContext)
        {
            string[] selectedColumnNames = selectableColumnsComboBox.GetItems.Where(CheckBox => CheckBox.Checked).Select(CheckBox => CheckBox.Text).ToArray();
            if (selectedColumnNames.Length == 0)
                return false;
            string primaryColumnName = conditionContext.PrimaryColumnName;
            string optionColumnName = conditionContext.OptionColumnName;
            DataTable dataTable = conditionContext.ConditionTable;

            // 그룹화 결과를 저장할 Dictionary Key
            string selectedColumnsKey = string.Join("|", selectedColumnNames);
            if(conditionContext.DistinctOrderCalculationsBySelection.TryGetValue(selectedColumnsKey, out Dictionary<string, DistinctOrderConditionCalculation> distinctOrderCalculations) == false)
            {
                // 한번도 계산한게 없을때 계산 1회 실행 
                distinctOrderCalculations = new Dictionary<string, DistinctOrderConditionCalculation>();
                conditionContext.DistinctOrderCalculationsBySelection[selectedColumnsKey] = distinctOrderCalculations;
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    DataRow dataRow = dataTable.Rows[i];
                    string groupKey = string.Join("|", selectedColumnNames.Select(col => dataRow[col]));

                    string primaryValue = dataRow[primaryColumnName].ToString();
                    if (distinctOrderCalculations.TryGetValue(groupKey, out DistinctOrderConditionCalculation distinctOrderCalculation))
                        distinctOrderCalculation.AddAdditionalData(primaryValue);
                    else
                        distinctOrderCalculations[groupKey] = new DistinctOrderConditionCalculation(primaryValue);
                }
            }
            int peopleCount = 1;
            foreach (DistinctOrderConditionCalculation distinctOrderCalculation in distinctOrderCalculations.Values)
            {
                if (conditionContext.TryAddCondition(distinctOrderCalculation.FirstRowPrimaryValue, this) == false)
                    continue;
                if (++peopleCount > PeopleLimit)
                    break;
            }
            return peopleCount > 1;
        }
        public void PaintRow(DataGridViewRow row)
        {
            if (PaintTarget == PaintTarget.Font)// 글씨 색 변경
                row.DefaultCellStyle.ForeColor = SelectedColor;
            else // 배경색 변경
                row.DefaultCellStyle.BackColor = SelectedColor;
        }
        
    }
}
