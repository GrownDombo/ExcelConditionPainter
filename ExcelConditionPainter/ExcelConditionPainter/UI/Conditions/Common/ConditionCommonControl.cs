using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ExcelConditionPainter
{
    /// <summary>
    /// 모든 조건 컨트롤에 공통으로 노출되는 매칭 방식, 우선순위, 색상, 삭제 UI입니다.
    /// </summary>
    public partial class ConditionCommonControl : UserControl, IConditionSettings
    {
        private MultiSelectMatchMode matchMode = MultiSelectMatchMode.And;
        private bool matchModeEnabled = true;

        private const string MatchModeChangeToolTipText = "여러 컬럼 선택 시 AND/OR 검색을 변경합니다.";
        private const string MatchModeDisabledToolTipText = "특정 옵션 구매 검색은 OR 검색만 지원합니다.";

        [Category("Action")]
        [Description("Put PriorityLevel between 0~10")]
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
        public PaintTarget PaintTarget
        {
            get { return (PaintTarget)Enum.Parse(typeof(PaintTarget), paintTargetButton.Text); }
            set { paintTargetButton.Text = value.ToString(); }
        }

        [Category("Action")]
        [Description("Put Multi Select Match Mode")]
        public MultiSelectMatchMode MatchMode
        {
            get { return matchMode; }
            set
            {
                matchMode = value;
                UpdateMatchModeButton();
            }
        }

        [Category("Action")]
        [Description("Enable Multi Select Match Mode")]
        public bool MatchModeEnabled
        {
            get { return matchModeEnabled; }
            set
            {
                matchModeEnabled = value;
                UpdateMatchModeButton();
            }
        }

        [Category("Action")]
        [Description("Put Color to Paint")]
        public Color SelectedColor
        {
            get { return colorComboBox.SelectedColor; }
            set { colorComboBox.SelectedColor = value; }
        }

        [Category("Action")]
        [Description("Occurs when the Delete button is clicked.")]
        public event EventHandler DeleteButtonClick;

        public ConditionCommonControl()
        {
            InitializeComponent();

            UpdateMatchModeButton();
            paintTargetButton.Text = PaintTarget.Font.ToString();
            conditionToolTip.SetToolTip(priorityLevelInput, "조건 Level을 0~10 사이로 입력하세요.");
            conditionToolTip.SetToolTip(paintTargetButton, "글자색 변경 또는 셀 배경색 변경");
            conditionToolTip.SetToolTip(deleteButton, "해당 조건 제거");
        }

        private void matchModeButton_Click(object sender, EventArgs e)
        {
            if (matchModeEnabled == false)
            {
                conditionToolTip.Show(MatchModeDisabledToolTipText, matchModeButton, 0, matchModeButton.Height + 2, 2000);
                return;
            }

            MatchMode = matchMode == MultiSelectMatchMode.And
                ? MultiSelectMatchMode.Or
                : MultiSelectMatchMode.And;
        }

        private void UpdateMatchModeButton()
        {
            matchModeButton.Text = matchMode.ToString().ToUpper();
            matchModeButton.BackColor = matchModeEnabled
                ? Color.White
                : Color.FromArgb(249, 250, 251);
            matchModeButton.Cursor = matchModeEnabled
                ? Cursors.Hand
                : Cursors.No;
            matchModeButton.FlatAppearance.BorderColor = matchModeEnabled
                ? Color.FromArgb(156, 163, 175)
                : Color.FromArgb(209, 213, 219);
            matchModeButton.ForeColor = matchModeEnabled == false
                ? Color.FromArgb(107, 114, 128)
                : matchMode == MultiSelectMatchMode.And
                ? Color.FromArgb(15, 118, 110)
                : Color.FromArgb(29, 78, 216);

            if (conditionToolTip != null)
            {
                conditionToolTip.SetToolTip(
                    matchModeButton,
                    matchModeEnabled ? MatchModeChangeToolTipText : MatchModeDisabledToolTipText);
            }
        }

        private void paintTargetButton_Click(object sender, EventArgs e)
        {
            if (paintTargetButton.Text == PaintTarget.Font.ToString())
                paintTargetButton.Text = PaintTarget.Fill.ToString();
            else
                paintTargetButton.Text = PaintTarget.Font.ToString();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DeleteButtonClick?.Invoke(this, e);
        }
    }
}
