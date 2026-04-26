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
    public partial class ucConditionOrderExceptDuplication : UserControl, ICondtions
    {
        public int nAppliedConditionIndex { get; set; }
        public ucConditionOrderExceptDuplication()
        {
            InitializeComponent();
        }
        public ucConditionOrderExceptDuplication(string[] sColNames, int nRowCnt) : this()
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
            numcLimitPeopleCnt.Maximum = nRowCnt;
        }
        #region UI
        [Category("Action")]
        [Description("Put Level between 0~10")]
        public int Level
        {
            get { return ucConditonCommon.Level; }
            set { ucConditonCommon.Level = value; }
        }
        [Category("Action")]
        [Description("Put Type of Painting Color")]
        public eConditionType ConditionType
        {
            get { return ucConditonCommon.ConditionType; }
            set { ucConditonCommon.ConditionType = value; }
        }
        [Category("Action")]
        [Description("Put Color to Paint")]
        public Color SelectColor
        {
            get { return ucConditonCommon.SelectColor; }
            set { ucConditonCommon.SelectColor = SelectColor; }
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
            string sOptionColName = conditionCalculator.sOptionColName;
            DataTable dataTable = conditionCalculator.dtCondition;

            // 그룹화 결과를 저장할 Dictionary Key
            string sSelectColsGroupKey = string.Join("|", selectedCols);
            if(conditionCalculator.dic2DOrderExceptDuplCal.TryGetValue(sSelectColsGroupKey, out Dictionary<string, cOrderExceptDuplOptionCal> dicOrderExceptDuplCal) == false)
            {
                // 한번도 계산한게 없을때 계산 1회 실행 
                dicOrderExceptDuplCal = new Dictionary<string, cOrderExceptDuplOptionCal>();
                conditionCalculator.dic2DOrderExceptDuplCal[sSelectColsGroupKey] = dicOrderExceptDuplCal;
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    DataRow dataRow = dataTable.Rows[i];
                    string groupKey = string.Join("|", selectedCols.Select(col => dataRow[col]));

                    string PrimaryValue = dataRow[sPrimaryColName].ToString();
                    if (dicOrderExceptDuplCal.TryGetValue(groupKey, out cOrderExceptDuplOptionCal orderExceptDuplCal))
                        orderExceptDuplCal.AddEdtionData(PrimaryValue);
                    else
                        dicOrderExceptDuplCal[groupKey] = new cOrderExceptDuplOptionCal(PrimaryValue);
                }
            }
            int nPeopleCnt = 1;
            foreach (cOrderExceptDuplOptionCal orderExceptDuplCal in dicOrderExceptDuplCal.Values)
            {
                if (conditionCalculator.AddCondtions(orderExceptDuplCal.FirstRowPrimaryValue, this) == false)
                    continue;
                if (++nPeopleCnt > nLimitPeopleCnt)
                    break;
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
