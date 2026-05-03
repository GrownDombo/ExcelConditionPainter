using System;
using System.Windows.Forms;

namespace ExcelConditionPainter
{
    /// <summary>
    /// 앱 설정값을 수정하고 저장하는 옵션 창입니다.
    /// </summary>
    public partial class FormOptions : Form
    {
        /// <summary>
        /// 옵션 UI와 설정 바인딩을 초기화합니다.
        /// </summary>
        public FormOptions()
        {
            InitializeComponent();
            exportSplitByConditionsCheckBox.DataBindings.Add("Checked", Properties.Settings.Default, nameof(Properties.Settings.Default.ExportSplitByConditions), false, DataSourceUpdateMode.OnPropertyChanged);
        }

        /// <summary>
        /// 현재 옵션 값을 사용자 설정에 저장하고 창을 닫습니다.
        /// </summary>
        private void saveButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            Close();
        }
    }
}
