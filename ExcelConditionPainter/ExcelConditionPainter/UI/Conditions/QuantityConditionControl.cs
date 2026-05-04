using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ExcelConditionPainter
{
    /// <summary>
    /// 구매 수량 조건의 UI 입력을 받고 계산 Rule을 생성하는 컨트롤입니다.
    /// </summary>
    public partial class QuantityConditionControl : UserControl, IConditionControl
    {
        /// <summary>
        /// 수량 조건 컨트롤을 초기화합니다.
        /// </summary>
        public QuantityConditionControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 선택 가능한 컬럼과 행 수를 받아 수량 조건 컨트롤을 초기화합니다.
        /// </summary>
        public QuantityConditionControl(string[] columnNames, int rowCount) : this()
        {
            SetSelectableItems(columnNames, rowCount);
        }

        /// <summary>
        /// 수량 그룹을 만들 컬럼 선택 목록과 인원 제한 범위를 설정합니다.
        /// </summary>
        public void SetSelectableItems(string[] columnNames, int rowCount)
        {
            selectableColumnsComboBox.ItemClear();
            selectableColumnsComboBox.AddItemRange(columnNames ?? new string[0]);

            // 주소 컬럼이 있으면 기본 선택합니다.
            CheckBox checkBox = selectableColumnsComboBox.GetItems.FirstOrDefault(item => item.Text.Contains("주소"));
            if (checkBox != null)
                checkBox.Checked = true;

            peopleLimitInput.Maximum = rowCount;
        }

        /// <summary>
        /// 현재 UI 입력값으로 수량 조건 Rule을 생성합니다.
        /// </summary>
        public IConditionRule CreateRule()
        {
            return new QuantityConditionRule(PriorityLevel, PaintTarget, MatchMode, SelectedColor, GetSelectedColumnNames(), GoodsCount, PeopleLimit);
        }

        [Category("Action")]
        [Description("Put PriorityLevel between 0~10")]
        // 조건 우선순위입니다.
        public int PriorityLevel
        {
            get { return conditionCommonControl.PriorityLevel; }
            set { conditionCommonControl.PriorityLevel = value; }
        }

        [Category("Action")]
        [Description("Put Type of Painting Color")]
        // 글자색/배경색 중 적용할 대상입니다.
        public PaintTarget PaintTarget
        {
            get { return conditionCommonControl.PaintTarget; }
            set { conditionCommonControl.PaintTarget = value; }
        }

        [Category("Action")]
        [Description("Put Multi Select Match Mode")]
        public MultiSelectMatchMode MatchMode
        {
            get { return conditionCommonControl.MatchMode; }
            set { conditionCommonControl.MatchMode = value; }
        }

        [Category("Action")]
        [Description("Put Color to Paint")]
        // 조건에 적용할 색상입니다.
        public Color SelectedColor
        {
            get { return conditionCommonControl.SelectedColor; }
            set { conditionCommonControl.SelectedColor = value; }
        }

        [Category("Action")]
        [Description("Put Goods Count")]
        // 조건 기준이 되는 총 상품 수량입니다.
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
        // 조건을 적용할 최대 인원 수입니다.
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

        /// <summary>
        /// 체크된 컬럼명만 Rule 생성용으로 반환합니다.
        /// </summary>
        private string[] GetSelectedColumnNames()
        {
            return selectableColumnsComboBox.GetItems
                .Where(item => item.Checked)
                .Select(item => item.Text)
                .ToArray();
        }

        /// <summary>
        /// 삭제 버튼 클릭 시 현재 조건 컨트롤을 화면에서 제거합니다.
        /// </summary>
        private void conditionCommonControl_DeleteButtonClick(object sender, EventArgs e)
        {
            Parent.Controls.Remove(this);
        }
    }
}
