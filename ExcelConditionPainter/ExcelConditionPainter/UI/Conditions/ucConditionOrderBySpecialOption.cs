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
    public partial class ucConditionOrderBySpecialOption : UserControl, ICondtions 
    {
        public int nAppliedConditionIndex { get; set; }
        public ucConditionOrderBySpecialOption()
        {
            InitializeComponent();
        }
        public ucConditionOrderBySpecialOption(string[] sOptions, int nRowCnt) : this()
        {
            SetOptionRange(sOptions, nRowCnt);
        }
        public void SetOptionRange(string[] sOptions, int nRowCnt)
        {
            cbxcomSelectOptions.ItemClear();
            cbxcomSelectOptions.AddItemRange(sOptions);
            cbxcomSelectOptions.GetItems[0].Checked = true; // 기본값 True
            numcLimitPeopleCnt.Maximum = nRowCnt;
        }
        #region UI
        [Category("Action")]
        [Description("Put Level between 0~10")]
        public int Level
        {
            get { return ConditionCommon.Level; }
            set { ConditionCommon.Level = value; }
        }
        [Category("Action")]
        [Description("Put Type of Painting Color")]
        public eConditionType ConditionType
        {
            get { return ConditionCommon.ConditionType; }
            set { ConditionCommon.ConditionType = value; }
        }
        [Category("Action")]
        [Description("Put Color to Paint")]
        public Color SelectColor
        {
            get { return ConditionCommon.SelectColor; }
            set { ConditionCommon.SelectColor = value; }
        }
        [Category("Action")]
        [Description("Put Goods Count")]
        public int nLimitPeopleCnt
        {
            get { return (int)numcLimitPeopleCnt.Value; }
            set
            {
                if (value > numcLimitPeopleCnt.Maximum)
                    value = (int)numcLimitPeopleCnt.Maximum;
                numcLimitPeopleCnt.Value = value;
            }
        }
        private void ConditionCommon_DeleteButtonClick(object sender, EventArgs e)
        {
            Parent.Controls.Remove(this);
        }
        #endregion
        public bool CondtionResult(cConditionCalculator conditionCalculator)
        {
            string[] selectedCols = cbxcomSelectOptions.GetItems.Where(CheckBox => CheckBox.Checked).Select(CheckBox => CheckBox.Text).ToArray();
            if (selectedCols.Length == 0)
                return false;

            string sPrimaryColName = conditionCalculator.sPrimaryColName;
            string sOptionColName = conditionCalculator.sOptionColName;
            DataTable dataTable = conditionCalculator.dtCondition;

            int nPeopleCnt = 1;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow dataRow = dataTable.Rows[i];
                string sOptionValue = dataRow[sOptionColName].ToString();
                if (selectedCols.Contains(sOptionValue))
                {
                    string sPrimaryValue = dataRow[sPrimaryColName].ToString();
                    if (conditionCalculator.AddCondtions(sPrimaryValue, this) == false)
                        continue;
                    if (++nPeopleCnt > nLimitPeopleCnt)
                        break;
                }
            }
            return nPeopleCnt > 1;

        }
        public void PaintRows(DataGridViewRow row)
        {
            if (ConditionType == eConditionType.Font)// 글씨 색 변경
                row.DefaultCellStyle.ForeColor = SelectColor;
            else // 배경색 변경
                row.DefaultCellStyle.BackColor = SelectColor;
        }
    }
}
