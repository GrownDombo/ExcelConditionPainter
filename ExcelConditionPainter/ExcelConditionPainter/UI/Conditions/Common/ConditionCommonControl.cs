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
    public partial class ConditionCommonControl : UserControl, IConditionSettings
    {
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
            paintTargetButton.Text = PaintTarget.Font.ToString();
            conditionToolTip.SetToolTip(priorityLevelInput, "조건 Level을 0~10 사이로 입력하세요.");
            conditionToolTip.SetToolTip(paintTargetButton, "글자색 변경 or 셀 배경색 변경.");
            conditionToolTip.SetToolTip(deleteButton, "해당조건 제거.");
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
