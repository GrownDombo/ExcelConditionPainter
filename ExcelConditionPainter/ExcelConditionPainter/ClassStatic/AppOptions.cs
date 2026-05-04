using System;

namespace ExcelConditionPainter
{
    /// <summary>
    /// 앱 설정값을 코드에서 읽기 쉽게 제공하는 래퍼입니다.
    /// </summary>
    internal static class AppOptions
    {
        // Export 시 조건별 파일 분리 여부입니다.
        public static bool ExportSplitByConditions => Properties.Settings.Default.ExportSplitByConditions;

        public static MultiSelectMatchMode GetDefaultMatchMode(ConditionRuleType conditionRuleType)
        {
            switch (conditionRuleType)
            {
                case ConditionRuleType.Order:
                    return ParseMatchMode(Properties.Settings.Default.DefaultOrderMatchMode, MultiSelectMatchMode.And);
                case ConditionRuleType.Duplicate:
                    return ParseMatchMode(Properties.Settings.Default.DefaultDuplicateMatchMode, MultiSelectMatchMode.And);
                case ConditionRuleType.Quantity:
                    return ParseMatchMode(Properties.Settings.Default.DefaultQuantityMatchMode, MultiSelectMatchMode.And);
                case ConditionRuleType.OptionBuyOrder:
                    return MultiSelectMatchMode.Or;
                default:
                    return MultiSelectMatchMode.And;
            }
        }

        public static MultiSelectMatchMode ParseMatchMode(string value, MultiSelectMatchMode fallback)
        {
            if (Enum.TryParse(value, true, out MultiSelectMatchMode matchMode))
                return matchMode;

            return fallback;
        }

        public static string ToMatchModeSettingValue(MultiSelectMatchMode matchMode)
        {
            return matchMode.ToString();
        }
    }
}
