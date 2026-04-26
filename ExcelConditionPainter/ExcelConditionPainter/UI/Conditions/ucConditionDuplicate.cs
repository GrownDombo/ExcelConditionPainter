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
    public partial class ucConditionDuplicate : UserControl, ICondtions
    {
        private readonly Lazy<int> _appliedConditionIndex;
        public int AppliedConditionIndex => _appliedConditionIndex.Value;
        public int nAppliedConditionIndex { get; set; }
        public ucConditionDuplicate()
        {
            InitializeComponent();
        }
        public ucConditionDuplicate(string[] sColNames, int nRowCnt) : this()
        {
            SetOptionRange(sColNames, nRowCnt);
        }
        public void SetOptionRange(string[] sColNames, int nRowCnt)
        {
            cbxcomSelectCols.ItemClear();
            cbxcomSelectCols.AddItemRange(sColNames);
            CheckBox checkBox = cbxcomSelectCols.GetItems.FirstOrDefault(CheckBox => CheckBox.Text.Contains("주소"));
            if (checkBox != null)
                checkBox.Checked = true;
            // 이 조건은 nRowCnt 사용하지 않는다
        }
        #region UI
        [Category("Action")]
        [Description("Put Level between 0~10")]
        public int Level
        {
            get { return ucConditionCommon.Level; }
            set { ucConditionCommon.Level = value; }
        }
        [Category("Action")]
        [Description("Put Type of Painting Color")]
        public eConditionType ConditionType
        {
            get { return ucConditionCommon.ConditionType; }
            set { ucConditionCommon.ConditionType = value; }
        }
        [Category("Action")]
        [Description("Put Color to Paint")]
        public Color SelectColor
        {
            get { return ucConditionCommon.SelectColor; }
            set { ucConditionCommon.SelectColor = SelectColor; }
        }
        private void ucConditonCommon_DeleteButtonClick(object sender, EventArgs e)
        {
            Parent.Controls.Remove(this);
        }
        #endregion
        public bool CondtionResult(cConditionCalculator conditionCalculator)
        {
            string[] selectedCols = cbxcomSelectCols.GetItems.Where(CheckBox => CheckBox.Checked).Select(CheckBox => CheckBox.Text).ToArray();
            if (selectedCols.Length == 0)
                return false;

            string sPrimaryColName = conditionCalculator.sPrimaryColName;
            DataTable dataTable = conditionCalculator.dtCondition;

            Dictionary<string, List<DataRow>> groupedResults = new Dictionary<string, List<DataRow>>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow dataRow = dataTable.Rows[i];
                string groupKey = string.Join("|", selectedCols.Select(col => dataRow[col].ToString()));
                if (groupedResults.TryGetValue(groupKey, out List<DataRow> lRows) == false)
                {
                    lRows = new List<DataRow>();
                    groupedResults[groupKey] = lRows;
                }
                lRows.Add(dataRow);
            }
            foreach (List<DataRow> rows in groupedResults.Values)
            {
                if (rows.Count <= 1)
                    continue; // 중복이 아니면 패스
                for (int i = 0; i < rows.Count; i++)
                {
                    DataRow row = rows[i];
                    string sPrimaryValue = row[sPrimaryColName].ToString();
                    if (conditionCalculator.AddCondtions(sPrimaryValue, this) == false)
                        continue;
                }
            }
            return true;
        }
        public void PaintRows(DataGridViewRow row)
        {
            string[] selectedCols = cbxcomSelectCols.GetItems.Where(CheckBox => CheckBox.Checked).Select(CheckBox => CheckBox.Text).ToArray();
            Action<DataGridViewCell, Color> applyCellColor;
            if (ConditionType == eConditionType.Font)
                applyCellColor = ApplyFontColor;// 글씨 색 변경
            else
                applyCellColor = ApplyBackColor;// 배경색 변경
            for (int nColIdx = 0; nColIdx < selectedCols.Length; nColIdx++)
            {
                string sColName = selectedCols[nColIdx];
                applyCellColor(row.Cells[sColName], SelectColor);
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
