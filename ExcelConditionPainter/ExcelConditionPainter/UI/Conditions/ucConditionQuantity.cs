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
    public partial class ucConditionQuantity : UserControl, ICondtions
    {
        public int nAppliedConditionIndex { get; set; }
        public ucConditionQuantity()
        {
            InitializeComponent();
        }
        public ucConditionQuantity(string[] sColNames, int nRowCnt) : this()
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
        public int nGoodsCount
        {
            get { return (int)numcGoodsCnt.Value; }
            set
            {
                if (value > numcGoodsCnt.Maximum)
                    value = (int)numcGoodsCnt.Maximum;
                numcGoodsCnt.Value = value;
            }
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
            string sBuyCntColName = conditionCalculator.sBuyCntColName;
            string sOptionColName = conditionCalculator.sOptionColName;
            ReadOnlyDictionary<string, int> dicGoodsQuntity = conditionCalculator.dicGoodsQuntity;
            DataTable dataTable = conditionCalculator.dtCondition;

            // 그룹화 결과를 저장할 Dictionary Key
            string sSelectColsGroupKey = string.Join("|", selectedCols);
            if (conditionCalculator.dic2DQuantityCal.TryGetValue(sSelectColsGroupKey, out Dictionary<string, cQuantityOptionCal> dicGroupedRst) == false)
            {
                // 한번도 계산한게 없을때 계산 1회 실행 
                dicGroupedRst = new Dictionary<string, cQuantityOptionCal>();
                conditionCalculator.dic2DQuantityCal[sSelectColsGroupKey] = dicGroupedRst;
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    DataRow dataRow = dataTable.Rows[i];
                    string groupKey = string.Join("|", selectedCols.Select(col => dataRow[col]));

                    int nBuyCnt = Convert.ToInt32(dataRow[sBuyCntColName]);
                    string sGoodsQuntityValue = dataRow[sOptionColName].ToString();
                    int nGoodsQuntity = dicGoodsQuntity[sGoodsQuntityValue]; // 무조건 있다고 가정하고 해야함

                    string PrimaryValue = dataRow[sPrimaryColName].ToString();
                    int TotalGoodsCount = nBuyCnt * nGoodsQuntity;
                    if (dicGroupedRst.TryGetValue(groupKey, out cQuantityOptionCal quantityOptionCal))
                        quantityOptionCal.AddEdtionData(PrimaryValue, TotalGoodsCount);
                    else
                        dicGroupedRst[groupKey] = new cQuantityOptionCal(PrimaryValue, TotalGoodsCount);
                }
            }

            int nPeopleCnt = 1;
            //for (int i = 0; i < dataTable.Rows.Count; i++)
            //{
            //    DataRow dataRow = dataTable.Rows[i];
            //    string groupKey = string.Join("|", selectedCols.Select(col => dataRow[col]));
            //    cQuantityOptionCal quantityOptionCal = dicGroupedRst[groupKey];

            //    int nTotalGoodsCount = quantityOptionCal.TotalGoodsCount;
            //    if (nTotalGoodsCount < nGoodsCount)
            //        continue;
            //    string PrimaryValue = dataRow[sPrimaryColName].ToString();
            //    if (PrimaryValue.Equals(quantityOptionCal.FirstRowPrimaryValue) == false)
            //        continue;

            //    if (conditionCalculator.AddCondtions(quantityOptionCal.FirstRowPrimaryValue, this) == false)
            //        continue;
            //    if (++nPeopleCnt > nLimitPeopleCnt)
            //        break;
            //}
            foreach (cQuantityOptionCal quantityOptionCal in dicGroupedRst.Values)
            {
                int nTotalGoodsCount = quantityOptionCal.TotalGoodsCount;
                if (nTotalGoodsCount < nGoodsCount)
                    continue;
                if (conditionCalculator.AddCondtions(quantityOptionCal.FirstRowPrimaryValue, this) == false)
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
