using System;
using System.Windows.Forms;

namespace ExcelConditionPainter
{
    /// <summary>
    /// 앱 설정값을 수정하고 저장하는 옵션 창입니다.
    /// </summary>
    public partial class FormOptions : Form
    {
        private const string AndDisplayText = "AND";
        private const string OrDisplayText = "OR";

        /// <summary>
        /// 옵션 UI와 설정 바인딩을 초기화합니다.
        /// </summary>
        public FormOptions()
        {
            InitializeComponent();
            exportSplitByConditionsCheckBox.DataBindings.Add("Checked", Properties.Settings.Default, nameof(Properties.Settings.Default.ExportSplitByConditions), false, DataSourceUpdateMode.OnPropertyChanged);
            SetMatchModeComboBox(orderDefaultMatchModeComboBox, AppOptions.ParseMatchMode(Properties.Settings.Default.DefaultOrderMatchMode, MultiSelectMatchMode.And));
            SetMatchModeComboBox(duplicateDefaultMatchModeComboBox, AppOptions.ParseMatchMode(Properties.Settings.Default.DefaultDuplicateMatchMode, MultiSelectMatchMode.And));
            SetMatchModeComboBox(quantityDefaultMatchModeComboBox, AppOptions.ParseMatchMode(Properties.Settings.Default.DefaultQuantityMatchMode, MultiSelectMatchMode.And));
            SetMatchModeComboBox(optionBuyOrderDefaultMatchModeComboBox, MultiSelectMatchMode.Or);
            conditionDefaultToolTip.SetToolTip(optionBuyOrderDefaultMatchModeLabel, "특정 옵션 구매 검색은 OR 검색만 지원합니다.");
            conditionDefaultToolTip.SetToolTip(optionBuyOrderDefaultMatchModeComboBox, "특정 옵션 구매 검색은 OR 검색만 지원합니다.");
        }

        /// <summary>
        /// 현재 옵션 값을 사용자 설정에 저장하고 창을 닫습니다.
        /// </summary>
        private void saveButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.DefaultOrderMatchMode = AppOptions.ToMatchModeSettingValue(GetMatchMode(orderDefaultMatchModeComboBox));
            Properties.Settings.Default.DefaultDuplicateMatchMode = AppOptions.ToMatchModeSettingValue(GetMatchMode(duplicateDefaultMatchModeComboBox));
            Properties.Settings.Default.DefaultQuantityMatchMode = AppOptions.ToMatchModeSettingValue(GetMatchMode(quantityDefaultMatchModeComboBox));
            Properties.Settings.Default.DefaultOptionBuyOrderMatchMode = AppOptions.ToMatchModeSettingValue(MultiSelectMatchMode.Or);
            Properties.Settings.Default.Save();
            Close();
        }

        private static void SetMatchModeComboBox(ComboBox comboBox, MultiSelectMatchMode matchMode)
        {
            comboBox.SelectedItem = matchMode == MultiSelectMatchMode.Or
                ? OrDisplayText
                : AndDisplayText;
        }

        private static MultiSelectMatchMode GetMatchMode(ComboBox comboBox)
        {
            return string.Equals(comboBox.SelectedItem as string, OrDisplayText, StringComparison.OrdinalIgnoreCase)
                ? MultiSelectMatchMode.Or
                : MultiSelectMatchMode.And;
        }
    }
}
