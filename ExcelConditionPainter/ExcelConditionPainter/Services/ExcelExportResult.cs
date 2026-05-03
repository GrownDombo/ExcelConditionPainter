namespace ExcelConditionPainter
{
    /// <summary>
    /// Excel Export 후 사용자에게 열어줄 경로 정보를 담습니다.
    /// </summary>
    public sealed class ExcelExportResult
    {
        // 항상 생성되는 전체 Export 파일 경로입니다.
        public readonly string DefaultFilePath;
        // Export 완료 후 Process.Start로 열 대상 경로입니다.
        public readonly string OpenTargetPath;
        // 조건별 분리 Export 여부입니다.
        public readonly bool SplitByConditions;

        /// <summary>
        /// Export 결과 파일과 열 대상 정보를 초기화합니다.
        /// </summary>
        public ExcelExportResult(string defaultFilePath, string openTargetPath, bool splitByConditions)
        {
            DefaultFilePath = defaultFilePath;
            OpenTargetPath = openTargetPath;
            SplitByConditions = splitByConditions;
        }
    }
}
