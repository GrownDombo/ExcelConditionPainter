namespace ExcelConditionPainter
{
    /// <summary>
    /// 앱 설정값을 코드에서 읽기 쉽게 제공하는 래퍼입니다.
    /// </summary>
    internal static class AppOptions
    {
        // Export 시 조건별 파일 분리 여부입니다.
        public static bool ExportSplitByConditions => Properties.Settings.Default.ExportSplitByConditions;
    }
}
