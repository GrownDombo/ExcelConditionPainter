using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ExcelConditionPainter
{
    /// <summary>
    /// 옵션명과 해당 옵션의 실제 상품 수량을 입력받는 컨트롤입니다.
    /// </summary>
    public partial class OptionQuantityControl : UserControl
    {
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Gets or sets the text of the option name label.")]
        [Category("Custom")]
        // 화면에 표시되는 옵션명입니다.
        public string OptionName
        {
            get { return optionNameLabel.Text; }
            set
            {
                optionNameLabel.Text = value;
                if (string.IsNullOrEmpty(value))
                    return;

                // 옵션명에서 자동 추출한 숫자입니다.
                Match match = Regex.Match(value, @"\d+");
                if (match.Success && int.TryParse(match.Value, out int extractedNumber))
                    optionCountInput.Value = Math.Min(optionCountInput.Maximum, extractedNumber);
            }
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Gets or sets the text of the option name label.")]
        [Category("Custom")]
        // 옵션 하나가 의미하는 실제 상품 수량입니다.
        public int OptionCount
        {
            get { return (int)optionCountInput.Value; }
            set { optionCountInput.Value = value; }
        }

        /// <summary>
        /// 옵션 수량 입력 컨트롤을 초기화합니다.
        /// </summary>
        public OptionQuantityControl()
        {
            InitializeComponent();
        }
    }
}
