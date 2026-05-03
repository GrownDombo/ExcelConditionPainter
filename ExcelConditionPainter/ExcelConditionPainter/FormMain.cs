using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ExcelConditionPainter
{
    public partial class FormMain : Form
    {
        private const string FirstSheetName = "ExportedData";
        private readonly FormSearch searchForm; // FormSearch를 필드로 선언
        private readonly FormOptions optionsForm;

        private string sourceFilePath;
        private ConditionEvaluationContext conditionContext;
        public FormMain()
        {
            InitializeComponent();
            searchForm = new FormSearch(mainGridView);
            searchForm.Owner = this; // FormSearch의 소유자를 현재 폼으로 설정
            optionsForm = new FormOptions();
            optionsForm.Owner = this;

            sourceFilePath = string.Empty;
            conditionContext = null;
        }
        private DataTable LoadFileToDataTable(string fileFullPath)
        {
            string tableName = Path.GetFileNameWithoutExtension(fileFullPath);
            DataTable table = new DataTable(tableName);
            using (XLWorkbook workbook = new XLWorkbook(fileFullPath))
            {
                IXLWorksheet worksheet = workbook.Worksheet(1);// 첫 번째 시트를 가져옴
                int firstColIndex = worksheet.FirstColumnUsed().ColumnNumber(); // 첫 번째로 비어있지 않은 열의 번호
                int firstRowIndex = worksheet.FirstRowUsed().RowNumber();       // 첫 번째로 비어있지 않은 행의 번호
                int lastColIndex = worksheet.LastColumnUsed().ColumnNumber();   // 마지막 번째로 비어있지 않은 열의 번호
                int lastRowIndex = worksheet.LastRowUsed().RowNumber();         // 마지막 번째로 비어있지 않은 행의 번호

                for (int col = firstColIndex; col <= lastColIndex; col++)
                    table.Columns.Add(worksheet.Cell(firstRowIndex, col).GetString());
                for (int row = firstRowIndex + 1; row <= lastRowIndex; row++)               // 데이터를 DataTable에 추가
                {
                    DataRow dataRow = table.NewRow();
                    for (int col = firstColIndex; col <= lastColIndex; col++)
                        dataRow[col - firstColIndex] = worksheet.Cell(row, col).GetString();  // 셀 값을 DataTable에 추가
                    table.Rows.Add(dataRow);
                }
            }
            return table;
        }
        private void openMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Multiselect = false;
                if (openFileDialog.ShowDialog() != DialogResult.OK)
                    return;
                sourceFilePath = openFileDialog.FileName;
            }

            if (File.Exists(sourceFilePath) == false)
                return;
            switch (Path.GetExtension(sourceFilePath))
            {
                case ".xlsx":
                case ".xls":
                    break;
                default:
                    MessageBox.Show("지원하지 않는 파일 형식입니다.");
                    return;
            }
            this.Text = $"Condition Excel Painter - {sourceFilePath}";
            mainGridView.DataSource = LoadFileToDataTable(sourceFilePath);
            using (FormSetConditions formDataDetails = new FormSetConditions(mainGridView))
            {
                formDataDetails.Owner = this;
                formDataDetails.ShowDialog();
                conditionContext = formDataDetails.ConditionContext; // conditionContext 가 null이면 안됨
                if (conditionContext is null)
                    return;
                conditionContext.PaintDataGridView(mainGridView);// 조건 계산 후 테이블 업데이트
            }
        }
        private void helpMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://growndombo.tistory.com/7");
        }
        private void optionsMenuItem_Click(object sender, EventArgs e)
        {
            optionsForm.ShowDialog();
        }
        private void mainGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewColumn col in mainGridView.Columns)
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
        }
        private void mainGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string rowIndex = (e.RowIndex + 1).ToString(); // 1부터 시작하는 행 번호
            StringFormat centerFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            // RowHeader에 행 번호 그리기
            Rectangle headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, mainGridView.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIndex, mainGridView.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }
        private void exportButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(sourceFilePath))
            {
                MessageBox.Show($"Path Error : {sourceFilePath}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (conditionContext is null)
            {
                MessageBox.Show("Condition Set Error", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                string exportDirectory = Path.Combine(Path.GetDirectoryName(sourceFilePath), "ExcelPainter");
                Directory.CreateDirectory(exportDirectory); // 이미 존재하면 아무 일도 안 함

                string fileName = Path.GetFileNameWithoutExtension(sourceFilePath);
                string extension = Path.GetExtension(sourceFilePath);
                string exportDefaultFilePath = Path.Combine(exportDirectory, $"{fileName}_Default{extension}");

                // DataGridView 데이터를 Excel로 그대로 출력
                using (XLWorkbook workbook = CreateDefaultWorkbook(out IXLWorksheet worksheet))
                {
                    for (int rowIndex = 0; rowIndex < mainGridView.Rows.Count; rowIndex++)
                    {
                        DataGridViewRow row = mainGridView.Rows[rowIndex];
                        AddRow(row, ref worksheet);
                    }
                    SaveWorkbook(workbook, exportDefaultFilePath);
                }
                // 옵션 1 조결별 출력
                if (AppOptions.ExportSplitByConditions)
                {
                    DataTable dataTable = mainGridView.DataSource as DataTable;
                    Dictionary<int, XLWorkbook> workbooksByConditionIndex = new Dictionary<int, XLWorkbook>();
                    for (int rowIndex = 0; rowIndex < dataTable.Rows.Count; rowIndex++)
                    {
                        DataRow row = dataTable.Rows[rowIndex];
                        string primaryKey = row[row.Table.PrimaryKey[0]].ToString(); // 키가 1개라고 가정하기 때문에 가능
                        if (conditionContext.ConditionsByPrimaryValue.TryGetValue(primaryKey, out List<IConditionRule> conditionRules))
                        {
                            for (int conditionIndex = 0; conditionIndex < conditionRules.Count; conditionIndex++)
                            {
                                IConditionRule conditionRule = conditionRules[conditionIndex];
                                int appliedConditionIndex = conditionRule.AppliedConditionIndex;
                                IXLWorksheet worksheet;
                                if (workbooksByConditionIndex.TryGetValue(appliedConditionIndex, out XLWorkbook workbook))
                                    worksheet = workbook.Worksheets.Worksheet(FirstSheetName);
                                else
                                {
                                    workbook = CreateDefaultWorkbook(out worksheet);
                                    workbooksByConditionIndex[appliedConditionIndex] = workbook;
                                }
                                AddRow(mainGridView.Rows[rowIndex], ref worksheet);
                            }
                        }
                    }
                    foreach (KeyValuePair<int, XLWorkbook> workbookEntry in workbooksByConditionIndex)
                    {
                        int appliedConditionIndex = workbookEntry.Key;
                        XLWorkbook workbook = workbookEntry.Value;
                        string conditionFilePath = Path.Combine(exportDirectory, $"{fileName}_{appliedConditionIndex}{extension}");
                        SaveWorkbook(workbook, conditionFilePath);
                        workbook.Dispose();
                    }
                    Process.Start(exportDirectory);
                }
                else
                    Process.Start(exportDefaultFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"에러 {ex}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private XLWorkbook CreateDefaultWorkbook(out IXLWorksheet worksheet)
        {
            XLWorkbook workbook = new XLWorkbook();
            worksheet = workbook.Worksheets.Add(FirstSheetName);
            // DataGridView 헤더를 Excel로 복사
            for (int col = 0; col < mainGridView.Columns.Count; col++)
                worksheet.Cell(1, col + 1).Value = mainGridView.Columns[col].HeaderText; // 헤더
            IXLRange headerRange = worksheet.Range(1, 1, 1, mainGridView.Columns.Count);
            headerRange.Style.Font.Bold = true;
            return workbook;
        }
        private void AddRow(DataGridViewRow row, ref IXLWorksheet worksheet)
        {
            int excelRow = (worksheet.LastRowUsed()?.RowNumber() ?? 0) + 1;

            // 행/셀 스타일 캐시
            Color rowBackColor = row.DefaultCellStyle.BackColor;
            Color rowForeColor = row.DefaultCellStyle.ForeColor;

            int colCount = row.DataGridView?.Columns.Count ?? row.Cells.Count;

            for (int columnIndex = 0; columnIndex < colCount; columnIndex++)
            {
                DataGridViewCell cell = row.Cells[columnIndex];
                IXLCell excelCell = worksheet.Cell(excelRow, 1 + columnIndex);

                // 값 설정 (숫자는 숫자로, 아니면 문자열)
                object val = cell.Value;
                if (val != null)
                {
                    string valueText = val.ToString();
                    if (double.TryParse(valueText, out double d))
                    {
                        excelCell.Value = d;
                        excelCell.Style.NumberFormat.Format = "0";
                    }
                    else
                        excelCell.Value = valueText;
                }
                else
                {
                    excelCell.Clear();
                }
                // ----- 스타일 적용 순서: Row 기본 → Cell 개별 -----
                if (rowBackColor != Color.Empty)
                    excelCell.Style.Fill.BackgroundColor = XLColor.FromColor(rowBackColor);
                if (rowForeColor != Color.Empty)
                    excelCell.Style.Font.FontColor = XLColor.FromColor(rowForeColor);

                Color cellBack = cell.Style.BackColor;
                Color cellFore = cell.Style.ForeColor;

                if (cellBack != Color.Empty)
                    excelCell.Style.Fill.BackgroundColor = XLColor.FromColor(cellBack);
                if (cellFore != Color.Empty)
                    excelCell.Style.Font.FontColor = XLColor.FromColor(cellFore);
            }
        }
        private void SaveWorkbook(XLWorkbook workbook, string targetFilePath)
        {
            IXLWorksheet worksheet = workbook.Worksheets.Worksheet(FirstSheetName);
            worksheet.Columns().AdjustToContents();
            IXLRange usedRange = worksheet.RangeUsed();
            usedRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            usedRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
            // Excel 파일 저장
            workbook.SaveAs(targetFilePath);
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.F)) // Control + F 키 조합 확인
            {
                if (searchForm.Visible) // FormSearch가 보이지 않는 경우
                    searchForm.Focus(); // 이미 열려 있는 경우 포커스 설정
                else
                    searchForm.Show(); // FormSearch 창 열기
                return true; // 키 이벤트 처리 완료
            }
            return base.ProcessCmdKey(ref msg, keyData); // 기본 처리
        }
    }
}
