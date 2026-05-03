using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ExcelConditionPainter
{
    /// <summary>
    /// 중복 제외 순서 조건의 UI 입력을 받고 계산 Rule을 생성하는 컨트롤입니다.
    /// </summary>
    public partial class DistinctOrderConditionControl : UserControl, IConditionControl
    {
        /// <summary>
        /// 중복 제외 순서 조건 컨트롤을 초기화합니다.
        /// </summary>
        public DistinctOrderConditionControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 선택 가능한 컬럼과 행 수를 받아 컨트롤을 초기화합니다.
        /// </summary>
        public DistinctOrderConditionControl(string[] columnNames, int rowCount) : this()
        {
            SetSelectableItems(columnNames, rowCount);
        }

        /// <summary>
        /// 순서 그룹을 만들 컬럼 선택 목록과 인원 제한 범위를 설정합니다.
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
        /// 현재 UI 입력값으로 중복 제외 순서 조건 Rule을 생성합니다.
        /// </summary>
        public IConditionRule CreateRule()
        {
            return new DistinctOrderConditionRule(PriorityLevel, PaintTarget, SelectedColor, GetSelectedColumnNames(), PeopleLimit);
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
        [Description("Put Color to Paint")]
        // 조건에 적용할 색상입니다.
        public Color SelectedColor
        {
            get { return conditionCommonControl.SelectedColor; }
            set { conditionCommonControl.SelectedColor = value; }
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
