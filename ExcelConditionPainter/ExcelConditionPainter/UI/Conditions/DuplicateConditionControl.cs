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
    public partial class DuplicateConditionControl : UserControl, IConditionRule
    {
        public int AppliedConditionIndex { get; set; }
        public DuplicateConditionControl()
        {
            InitializeComponent();
        }
        public DuplicateConditionControl(string[] columnNames, int rowCount) : this()
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
            // 이 조건은 rowCount 사용하지 않는다
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
            DataTable dataTable = conditionContext.ConditionTable;

            Dictionary<string, List<DataRow>> groupedResults = new Dictionary<string, List<DataRow>>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow dataRow = dataTable.Rows[i];
                string groupKey = string.Join("|", selectedColumnNames.Select(col => dataRow[col].ToString()));
                if (groupedResults.TryGetValue(groupKey, out List<DataRow> matchingRows) == false)
                {
                    matchingRows = new List<DataRow>();
                    groupedResults[groupKey] = matchingRows;
                }
                matchingRows.Add(dataRow);
            }
            foreach (List<DataRow> rows in groupedResults.Values)
            {
                if (rows.Count <= 1)
                    continue; // 중복이 아니면 패스
                for (int i = 0; i < rows.Count; i++)
                {
                    DataRow row = rows[i];
                    string primaryValue = row[primaryColumnName].ToString();
                    if (conditionContext.TryAddCondition(primaryValue, this) == false)
                        continue;
                }
            }
            return true;
        }
        public void PaintRow(DataGridViewRow row)
        {
            string[] selectedColumnNames = selectableColumnsComboBox.GetItems.Where(CheckBox => CheckBox.Checked).Select(CheckBox => CheckBox.Text).ToArray();
            Action<DataGridViewCell, Color> applyCellColor;
            if (PaintTarget == PaintTarget.Font)
                applyCellColor = ApplyFontColor;// 글씨 색 변경
            else
                applyCellColor = ApplyBackColor;// 배경색 변경
            for (int columnIndex = 0; columnIndex < selectedColumnNames.Length; columnIndex++)
            {
                string columnName = selectedColumnNames[columnIndex];
                applyCellColor(row.Cells[columnName], SelectedColor);
            }
        }
        private void ApplyFontColor(DataGridViewCell cell, Color color)
        {
            cell.Style.ForeColor = color;
        }
        private void ApplyBackColor(DataGridViewCell cell, Color color)
        {
            cell.Style.BackColor = color;
        }
    }
}
