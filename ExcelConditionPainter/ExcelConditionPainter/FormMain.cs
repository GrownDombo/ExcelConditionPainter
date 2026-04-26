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
        private const string FIRST_SHEET_NAME = "ExportedData";
        private readonly FormSearch formSearch; // FormSearch를 필드로 선언
        private readonly FormOptions formOptions;

        private string sPath;
        private cConditionCalculator conditionCalculator;
        public FormMain()
        {
            InitializeComponent();
            formSearch = new FormSearch(dgvMain);
            formSearch.Owner = this; // FormSearch의 소유자를 현재 폼으로 설정
            formOptions = new FormOptions();
            formOptions.Owner = this;

            sPath = string.Empty;
            conditionCalculator = null;
        }
        private DataTable LoadFileToDataTable(string fileFullPath)
        {
            string tableName = Path.GetFileNameWithoutExtension(fileFullPath);
            DataTable table = new DataTable(tableName);
            List<string> duplValues = new List<string>();
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
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Multiselect = false;
                if (openFileDialog.ShowDialog() != DialogResult.OK)
                    return;
                sPath = openFileDialog.FileName;
            }

            if (File.Exists(sPath) == false)
                return;
            switch (Path.GetExtension(sPath))
            {
                case ".xlsx":
                case ".xls":
                    break;
                default:
                    MessageBox.Show("지원하지 않는 파일 형식입니다.");
                    return;
            }
            this.Text = $"Condition Excel Painter - {sPath}";
            dgvMain.DataSource = LoadFileToDataTable(sPath);
            using (FormSetConditions formDataDetails = new FormSetConditions(dgvMain))
            {
                formDataDetails.Owner = this;
                formDataDetails.ShowDialog();
                conditionCalculator = formDataDetails.conditionCalculator; // conditionCalculator 가 null이면 안됨
                if (conditionCalculator is null)
                    return;
                conditionCalculator.PaintDataGridView(dgvMain);// 조건 계산 후 테이블 업데이트
            }
        }
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://growndombo.tistory.com/7");
        }
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formOptions.ShowDialog();
        }
        private void dgvMain_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewColumn col in dgvMain.Columns)
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
        }
        private void dgvMain_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string rowIdx = (e.RowIndex + 1).ToString(); // 1부터 시작하는 행 번호
            StringFormat centerFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            // RowHeader에 행 번호 그리기
            Rectangle headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, dgvMain.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, dgvMain.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(sPath))
            {
                MessageBox.Show($"Path Error : {sPath}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (conditionCalculator is null)
            {
                MessageBox.Show("Condition Set Error", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                string dir = Path.Combine(Path.GetDirectoryName(sPath), "ExcelPainter");
                Directory.CreateDirectory(dir); // 이미 존재하면 아무 일도 안 함

                string sFileName = Path.GetFileNameWithoutExtension(sPath);
                string sExtension = Path.GetExtension(sPath);
                string exportDefaultFilePath = Path.Combine(dir, $"{sFileName}_Default{sExtension}");

                // DataGridView 데이터를 Excel로 그대로 출력
                using (XLWorkbook workBook = makeXLWorkBookDefault(out IXLWorksheet worksheet))
                {
                    for (int rowIdx = 0; rowIdx < dgvMain.Rows.Count; rowIdx++)
                    {
                        DataGridViewRow row = dgvMain.Rows[rowIdx];
                        AddRow(row, ref worksheet);
                    }
                    SaveWorkBook(workBook, exportDefaultFilePath);
                }
                // 옵션 1 조결별 출력
                if (AppOptions.ExportSplitByConditions)
                {
                    DataTable dataTable = dgvMain.DataSource as DataTable;
                    Dictionary<int, XLWorkbook> dicworkbook = new Dictionary<int, XLWorkbook>();
                    for (int rowIdx = 0; rowIdx < dataTable.Rows.Count; rowIdx++)
                    {
                        DataRow row = dataTable.Rows[rowIdx];
                        string sPrimaryKey = row[row.Table.PrimaryKey[0]].ToString(); // 키가 1개라고 가정하기 때문에 가능
                        if (conditionCalculator.dicRowConditions.TryGetValue(sPrimaryKey, out List<ICondtions> liCondtions))
                        {
                            for (int idxCondtion = 0; idxCondtion < liCondtions.Count; idxCondtion++)
                            {
                                ICondtions condtion = liCondtions[idxCondtion];
                                int nAppliedConditionIndex = condtion.nAppliedConditionIndex;
                                IXLWorksheet worksheet;
                                if (dicworkbook.TryGetValue(nAppliedConditionIndex, out XLWorkbook workBook))
                                    worksheet = workBook.Worksheets.Worksheet(FIRST_SHEET_NAME);
                                else
                                {
                                    workBook = makeXLWorkBookDefault(out worksheet);
                                    dicworkbook[nAppliedConditionIndex] = workBook;
                                }
                                AddRow(dgvMain.Rows[rowIdx], ref worksheet);
                            }
                        }
                    }
                    foreach (KeyValuePair<int, XLWorkbook> kvp in dicworkbook)
                    {
                        int nAppliedConditionIndex = kvp.Key;
                        XLWorkbook workBook = kvp.Value;
                        string sPath = Path.Combine(dir, $"{sFileName}_{nAppliedConditionIndex}{sExtension}");
                        SaveWorkBook(workBook, sPath);
                        workBook.Dispose();
                    }
                    Process.Start(dir);
                }
                else
                    Process.Start(exportDefaultFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"에러 {ex}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private XLWorkbook makeXLWorkBookDefault(out IXLWorksheet worksheet)
        {
            XLWorkbook workbook = new XLWorkbook();
            worksheet = workbook.Worksheets.Add(FIRST_SHEET_NAME);
            // DataGridView 헤더를 Excel로 복사
            for (int col = 0; col < dgvMain.Columns.Count; col++)
                worksheet.Cell(1, col + 1).Value = dgvMain.Columns[col].HeaderText; // 헤더
            IXLRange headerRange = worksheet.Range(1, 1, 1, dgvMain.Columns.Count);
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

            for (int colIdx = 0; colIdx < colCount; colIdx++)
            {
                DataGridViewCell cell = row.Cells[colIdx];
                IXLCell excelCell = worksheet.Cell(excelRow, 1 + colIdx);

                // 값 설정 (숫자는 숫자로, 아니면 문자열)
                object val = cell.Value;
                if (val != null)
                {
                    string s = val.ToString();
                    if (double.TryParse(s, out double d))
                    {
                        excelCell.Value = d;
                        excelCell.Style.NumberFormat.Format = "0";
                    }
                    else
                        excelCell.Value = s;
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
        private void SaveWorkBook(XLWorkbook workBook, string sPath)
        {
            IXLWorksheet worksheet = workBook.Worksheets.Worksheet(FIRST_SHEET_NAME);
            worksheet.Columns().AdjustToContents();
            IXLRange usedRange = worksheet.RangeUsed();
            usedRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            usedRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
            // Excel 파일 저장
            workBook.SaveAs(sPath);
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.F)) // Control + F 키 조합 확인
            {
                if (formSearch.Visible) // FormSearch가 보이지 않는 경우
                    formSearch.Focus(); // 이미 열려 있는 경우 포커스 설정
                else
                    formSearch.Show(); // FormSearch 창 열기
                return true; // 키 이벤트 처리 완료
            }
            return base.ProcessCmdKey(ref msg, keyData); // 기본 처리
        }
    }
}
