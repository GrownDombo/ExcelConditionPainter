using ClosedXML.Excel;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ExcelConditionPainter
{
    /// <summary>
    /// ClosedXML 기반 Excel 읽기/쓰기 세부 구현을 Form에서 숨기는 서비스입니다.
    /// </summary>
    public class ExcelWorkbookService
    {
        // Export 시 생성할 기본 워크시트 이름입니다.
        private const string FirstSheetName = "ExportedData";

        /// <summary>
        /// 첫 번째 Excel 시트를 DataTable로 읽어옵니다.
        /// </summary>
        public DataTable LoadFileToDataTable(string fileFullPath)
        {
            // DataTable 이름은 원본 파일명에서 가져옵니다.
            string tableName = Path.GetFileNameWithoutExtension(fileFullPath);
            // Excel 행/열을 담을 테이블입니다.
            DataTable table = new DataTable(tableName);

            using (XLWorkbook workbook = new XLWorkbook(fileFullPath))
            {
                // 현재 앱은 첫 번째 시트만 읽습니다.
                IXLWorksheet worksheet = workbook.Worksheet(1);
                // 실제 데이터가 시작되는 첫 열입니다.
                int firstColIndex = worksheet.FirstColumnUsed().ColumnNumber();
                // 헤더가 있는 첫 행입니다.
                int firstRowIndex = worksheet.FirstRowUsed().RowNumber();
                // 실제 데이터가 끝나는 마지막 열입니다.
                int lastColIndex = worksheet.LastColumnUsed().ColumnNumber();
                // 실제 데이터가 끝나는 마지막 행입니다.
                int lastRowIndex = worksheet.LastRowUsed().RowNumber();

                for (int col = firstColIndex; col <= lastColIndex; col++)
                    table.Columns.Add(worksheet.Cell(firstRowIndex, col).GetString());

                for (int row = firstRowIndex + 1; row <= lastRowIndex; row++)
                {
                    // Excel 한 행을 DataTable 행으로 변환합니다.
                    DataRow dataRow = table.NewRow();
                    for (int col = firstColIndex; col <= lastColIndex; col++)
                        dataRow[col - firstColIndex] = worksheet.Cell(row, col).GetString();
                    table.Rows.Add(dataRow);
                }
            }

            return table;
        }

        /// <summary>
        /// 현재 그리드 내용을 기본 파일과 조건별 분리 파일로 Export합니다.
        /// </summary>
        public ExcelExportResult ExportGrid(DataGridView dataGridView, string sourceFilePath, ConditionEvaluationContext conditionContext)
        {
            // Export 파일들을 모아둘 폴더입니다.
            string exportDirectory = Path.Combine(Path.GetDirectoryName(sourceFilePath), "ExcelPainter");
            Directory.CreateDirectory(exportDirectory);

            // 원본 파일명입니다.
            string fileName = Path.GetFileNameWithoutExtension(sourceFilePath);
            // 원본 확장자입니다.
            string extension = Path.GetExtension(sourceFilePath);
            // 전체 데이터가 저장되는 기본 Export 파일 경로입니다.
            string exportDefaultFilePath = Path.Combine(exportDirectory, $"{fileName}_Default{extension}");

            // 전체 색칠 결과는 항상 _Default 파일로 저장합니다.
            using (XLWorkbook workbook = CreateDefaultWorkbook(dataGridView, out IXLWorksheet worksheet))
            {
                for (int rowIndex = 0; rowIndex < dataGridView.Rows.Count; rowIndex++)
                    AddRow(dataGridView.Rows[rowIndex], worksheet);

                SaveWorkbook(workbook, exportDefaultFilePath);
            }

            if (AppOptions.ExportSplitByConditions == false)
                return new ExcelExportResult(exportDefaultFilePath, exportDefaultFilePath, false);

            ExportSplitWorkbooks(dataGridView, conditionContext, exportDirectory, fileName, extension);
            return new ExcelExportResult(exportDefaultFilePath, exportDirectory, true);
        }

        /// <summary>
        /// 적용 조건 순번별로 행을 나누어 별도 Excel 파일을 생성합니다.
        /// </summary>
        private void ExportSplitWorkbooks(DataGridView dataGridView, ConditionEvaluationContext conditionContext, string exportDirectory, string fileName, string extension)
        {
            // 그리드에 바인딩된 조건 평가 대상 테이블입니다.
            DataTable dataTable = dataGridView.DataSource as DataTable;
            // 적용 조건 순번별로 생성 중인 Workbook입니다.
            Dictionary<int, XLWorkbook> workbooksByConditionIndex = new Dictionary<int, XLWorkbook>();

            try
            {
                for (int rowIndex = 0; rowIndex < dataTable.Rows.Count; rowIndex++)
                {
                    // Export 여부를 확인할 원본 DataTable 행입니다.
                    DataRow row = dataTable.Rows[rowIndex];
                    // 조건 결과 Dictionary를 찾기 위한 기본키 값입니다.
                    string primaryKey = row[conditionContext.PrimaryColumnName].ToString();
                    if (conditionContext.ConditionsByPrimaryValue.TryGetValue(primaryKey, out List<IConditionRule> conditionRules) == false)
                        continue;

                    foreach (IConditionRule conditionRule in conditionRules)
                    {
                        // 조건별 파일명을 결정하는 적용 순번입니다.
                        int appliedConditionIndex = conditionRule.AppliedConditionIndex;
                        // 행을 추가할 대상 워크시트입니다.
                        IXLWorksheet worksheet;
                        if (workbooksByConditionIndex.TryGetValue(appliedConditionIndex, out XLWorkbook workbook))
                            worksheet = workbook.Worksheets.Worksheet(FirstSheetName);
                        else
                        {
                            workbook = CreateDefaultWorkbook(dataGridView, out worksheet);
                            workbooksByConditionIndex[appliedConditionIndex] = workbook;
                        }

                        AddRow(dataGridView.Rows[rowIndex], worksheet);
                    }
                }

                // 조건별 파일은 기존 규칙대로 원본명 + 적용 조건 순번으로 저장합니다.
                foreach (KeyValuePair<int, XLWorkbook> workbookEntry in workbooksByConditionIndex)
                {
                    // 조건별 Export 파일 경로입니다.
                    string conditionFilePath = Path.Combine(exportDirectory, $"{fileName}_{workbookEntry.Key}{extension}");
                    SaveWorkbook(workbookEntry.Value, conditionFilePath);
                }
            }
            finally
            {
                foreach (XLWorkbook workbook in workbooksByConditionIndex.Values)
                    workbook.Dispose();
            }
        }

        /// <summary>
        /// 헤더가 포함된 기본 Workbook과 Worksheet를 생성합니다.
        /// </summary>
        private XLWorkbook CreateDefaultWorkbook(DataGridView dataGridView, out IXLWorksheet worksheet)
        {
            // 새 Excel 파일 객체입니다.
            XLWorkbook workbook = new XLWorkbook();
            // 데이터를 쓸 기본 시트입니다.
            worksheet = workbook.Worksheets.Add(FirstSheetName);

            for (int col = 0; col < dataGridView.Columns.Count; col++)
                worksheet.Cell(1, col + 1).Value = dataGridView.Columns[col].HeaderText;

            IXLRange headerRange = worksheet.Range(1, 1, 1, dataGridView.Columns.Count);
            headerRange.Style.Font.Bold = true;
            return workbook;
        }

        /// <summary>
        /// DataGridView 한 행의 값과 스타일을 Excel 행으로 복사합니다.
        /// </summary>
        private void AddRow(DataGridViewRow row, IXLWorksheet worksheet)
        {
            // Excel에서 새로 추가할 행 번호입니다.
            int excelRow = (worksheet.LastRowUsed()?.RowNumber() ?? 0) + 1;

            // 행 기본 배경색입니다.
            Color rowBackColor = row.DefaultCellStyle.BackColor;
            // 행 기본 글자색입니다.
            Color rowForeColor = row.DefaultCellStyle.ForeColor;
            // 복사할 컬럼 개수입니다.
            int colCount = row.DataGridView?.Columns.Count ?? row.Cells.Count;

            for (int columnIndex = 0; columnIndex < colCount; columnIndex++)
            {
                // 복사할 그리드 셀입니다.
                DataGridViewCell cell = row.Cells[columnIndex];
                // 값을 넣을 Excel 셀입니다.
                IXLCell excelCell = worksheet.Cell(excelRow, 1 + columnIndex);

                // 그리드 셀의 원본 값입니다.
                object val = cell.Value;
                if (val != null)
                {
                    // Excel에 기록할 문자열 값입니다.
                    string valueText = val.ToString();
                    if (double.TryParse(valueText, out double d))
                    {
                        excelCell.Value = d;
                        excelCell.Style.NumberFormat.Format = "0";
                    }
                    else
                    {
                        excelCell.Value = valueText;
                    }
                }
                else
                {
                    excelCell.Clear();
                }

                // Excel 스타일은 그리드와 같은 순서로 적용합니다: 행 기본값 후 셀 개별값.
                if (rowBackColor != Color.Empty)
                    excelCell.Style.Fill.BackgroundColor = XLColor.FromColor(rowBackColor);
                if (rowForeColor != Color.Empty)
                    excelCell.Style.Font.FontColor = XLColor.FromColor(rowForeColor);

                // 셀 개별 배경색입니다.
                Color cellBack = cell.Style.BackColor;
                // 셀 개별 글자색입니다.
                Color cellFore = cell.Style.ForeColor;

                if (cellBack != Color.Empty)
                    excelCell.Style.Fill.BackgroundColor = XLColor.FromColor(cellBack);
                if (cellFore != Color.Empty)
                    excelCell.Style.Font.FontColor = XLColor.FromColor(cellFore);
            }
        }

        /// <summary>
        /// 워크시트 서식을 정리하고 Excel 파일로 저장합니다.
        /// </summary>
        private void SaveWorkbook(XLWorkbook workbook, string targetFilePath)
        {
            // 저장 전 서식을 적용할 기본 시트입니다.
            IXLWorksheet worksheet = workbook.Worksheets.Worksheet(FirstSheetName);
            worksheet.Columns().AdjustToContents();
            // 테두리를 적용할 실제 사용 범위입니다.
            IXLRange usedRange = worksheet.RangeUsed();
            usedRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            usedRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
            workbook.SaveAs(targetFilePath);
        }
    }
}
