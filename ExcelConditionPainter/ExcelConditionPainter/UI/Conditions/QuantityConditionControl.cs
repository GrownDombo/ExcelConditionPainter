using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ExcelConditionPainter
{
    public partial class QuantityConditionControl : UserControl, IConditionRule
    {
        public int AppliedConditionIndex { get; set; }
        public QuantityConditionControl()
        {
            InitializeComponent();
        }
        public QuantityConditionControl(string[] columnNames, int rowCount) : this()
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
            set { conditionCommonControl.SelectedColor = value; }
        }
        [Category("Action")]
        [Description("Put Goods Count")]
        public int GoodsCount
        {
            get { return (int)goodsCountInput.Value; }
            set
            {
                if (value > goodsCountInput.Maximum)
                    value = (int)goodsCountInput.Maximum;
                goodsCountInput.Value = value;
            }
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
            string buyCountColumnName = conditionContext.BuyCountColumnName;
            string optionColumnName = conditionContext.OptionColumnName;
            ReadOnlyDictionary<string, int> goodsQuantitiesByOption = conditionContext.GoodsQuantitiesByOption;
            DataTable dataTable = conditionContext.ConditionTable;

            // 그룹화 결과를 저장할 Dictionary Key
            string selectedColumnsKey = string.Join("|", selectedColumnNames);
            if (conditionContext.QuantityCalculationsBySelection.TryGetValue(selectedColumnsKey, out Dictionary<string, QuantityConditionCalculation> groupedCalculations) == false)
            {
                // 한번도 계산한게 없을때 계산 1회 실행 
                groupedCalculations = new Dictionary<string, QuantityConditionCalculation>();
                conditionContext.QuantityCalculationsBySelection[selectedColumnsKey] = groupedCalculations;
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    DataRow dataRow = dataTable.Rows[i];
                    string groupKey = string.Join("|", selectedColumnNames.Select(col => dataRow[col]));

                    int buyCount = Convert.ToInt32(dataRow[buyCountColumnName]);
                    string optionValue = dataRow[optionColumnName].ToString();
                    int goodsQuantity = goodsQuantitiesByOption[optionValue]; // 무조건 있다고 가정하고 해야함

                    string primaryValue = dataRow[primaryColumnName].ToString();
                    int totalGoodsCount = buyCount * goodsQuantity;
                    if (groupedCalculations.TryGetValue(groupKey, out QuantityConditionCalculation quantityCalculation))
                        quantityCalculation.AddAdditionalData(primaryValue, totalGoodsCount);
                    else
                        groupedCalculations[groupKey] = new QuantityConditionCalculation(primaryValue, totalGoodsCount);
                }
            }

            int peopleCount = 1;
            //for (int i = 0; i < dataTable.Rows.Count; i++)
            //{
            //    DataRow dataRow = dataTable.Rows[i];
            //    string groupKey = string.Join("|", selectedColumnNames.Select(col => dataRow[col]));
            //    QuantityConditionCalculation quantityCalculation = groupedCalculations[groupKey];

            //    int totalGoodsCount = quantityCalculation.TotalGoodsCount;
            //    if (totalGoodsCount < GoodsCount)
            //        continue;
            //    string primaryValue = dataRow[primaryColumnName].ToString();
            //    if (primaryValue.Equals(quantityCalculation.FirstRowPrimaryValue) == false)
            //        continue;

            //    if (conditionContext.TryAddCondition(quantityCalculation.FirstRowPrimaryValue, this) == false)
            //        continue;
            //    if (++peopleCount > PeopleLimit)
            //        break;
            //}
            foreach (QuantityConditionCalculation quantityCalculation in groupedCalculations.Values)
            {
                int totalGoodsCount = quantityCalculation.TotalGoodsCount;
                if (totalGoodsCount < GoodsCount)
                    continue;
                if (conditionContext.TryAddCondition(quantityCalculation.FirstRowPrimaryValue, this) == false)
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
