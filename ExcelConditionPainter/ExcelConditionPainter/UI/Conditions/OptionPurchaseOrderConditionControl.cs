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
    // 특정 옵션을 산사람중 선착순
    public partial class OptionPurchaseOrderConditionControl : UserControl, IConditionRule 
    {
        public int AppliedConditionIndex { get; set; }
        public OptionPurchaseOrderConditionControl()
        {
            InitializeComponent();
        }
        public OptionPurchaseOrderConditionControl(string[] optionNames, int rowCount) : this()
        {
            SetSelectableItems(optionNames, rowCount);
        }
        public void SetSelectableItems(string[] optionNames, int rowCount)
        {
            selectableOptionsComboBox.ItemClear();
            selectableOptionsComboBox.AddItemRange(optionNames);
            selectableOptionsComboBox.GetItems[0].Checked = true; // 기본값 True
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
            set { conditionCommonControl.SelectedColor = value; }
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
            string[] selectedOptionNames = selectableOptionsComboBox.GetItems.Where(CheckBox => CheckBox.Checked).Select(CheckBox => CheckBox.Text).ToArray();
            if (selectedOptionNames.Length == 0)
                return false;

            string primaryColumnName = conditionContext.PrimaryColumnName;
            string optionColumnName = conditionContext.OptionColumnName;
            DataTable dataTable = conditionContext.ConditionTable;

            int peopleCount = 1;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow dataRow = dataTable.Rows[i];
                string optionValue = dataRow[optionColumnName].ToString();
                if (selectedOptionNames.Contains(optionValue))
                {
                    string primaryValue = dataRow[primaryColumnName].ToString();
                    if (conditionContext.TryAddCondition(primaryValue, this) == false)
                        continue;
                    if (++peopleCount > PeopleLimit)
                        break;
                }
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
