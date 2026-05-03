using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ExcelConditionPainter
{
    /// <summary>
    /// 모든 조건 컨트롤에서 공통으로 쓰는 우선순위, 색상, 삭제 UI입니다.
    /// </summary>
    public partial class ConditionCommonControl : UserControl, IConditionSettings
    {
        [Category("Action")]
        [Description("Put PriorityLevel between 0~10")]
        // 조건 우선순위입니다.
        public int PriorityLevel
        {
            get { return (int)priorityLevelInput.Value; }
            set
            {
                if (value > priorityLevelInput.Maximum)
                    value = (int)priorityLevelInput.Maximum;
                priorityLevelInput.Value = value;
            }
        }

        [Category("Action")]
        [Description("Put Type of Painting Color")]
        // 글자색/배경색 중 적용할 대상입니다.
        public PaintTarget PaintTarget
        {
            get { return (PaintTarget)Enum.Parse(typeof(PaintTarget), paintTargetButton.Text); }
            set { paintTargetButton.Text = value.ToString(); }
        }

        [Category("Action")]
        [Description("Put Color to Paint")]
        // 조건에 적용할 색상입니다.
        public Color SelectedColor
        {
            get { return colorComboBox.SelectedColor; }
            set { colorComboBox.SelectedColor = value; }
        }

        [Category("Action")]
        [Description("Occurs when the Delete button is clicked.")]
        // 삭제 버튼 클릭을 부모 컨트롤에 알려주는 이벤트입니다.
        public event EventHandler DeleteButtonClick;

        /// <summary>
        /// 공통 조건 UI와 툴팁을 초기화합니다.
        /// </summary>
        public ConditionCommonControl()
        {
            InitializeComponent();
            paintTargetButton.Text = PaintTarget.Font.ToString();
            conditionToolTip.SetToolTip(priorityLevelInput, "조건 Level을 0~10 사이로 입력하세요.");
            conditionToolTip.SetToolTip(paintTargetButton, "글자색 변경 or 셀 배경색 변경");
            conditionToolTip.SetToolTip(deleteButton, "해당조건 제거.");
        }

        /// <summary>
        /// 색칠 대상을 글자색과 배경색 사이에서 전환합니다.
        /// </summary>
        private void paintTargetButton_Click(object sender, EventArgs e)
        {
            if (paintTargetButton.Text == PaintTarget.Font.ToString())
                paintTargetButton.Text = PaintTarget.Fill.ToString();
            else
                paintTargetButton.Text = PaintTarget.Font.ToString();
        }

        /// <summary>
        /// 삭제 버튼 클릭 이벤트를 외부로 전달합니다.
        /// </summary>
        private void deleteButton_Click(object sender, EventArgs e)
        {
            DeleteButtonClick?.Invoke(this, e);
        }
    }
}
