using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ExcelConditionPainter
{
    /// <summary>
    /// 메인 화면에서 파일 열기, 조건 설정, 검색, Export 흐름을 제어합니다.
    /// </summary>
    public partial class FormMain : Form
    {
        // 환경설정 창 인스턴스입니다.
        private readonly FormOptions optionsForm;
        // Excel 읽기/쓰기 처리를 담당하는 서비스입니다.
        private readonly ExcelWorkbookService excelWorkbookService;
        // 조건 평가 결과를 그리드에 색칠하는 서비스입니다.
        private readonly GridPainter gridPainter;

        // Ctrl+F로 열 검색창입니다.
        private FormSearch searchForm;
        // 현재 열려 있는 원본 Excel 파일 경로입니다.
        private string sourceFilePath;
        // 마지막으로 적용된 조건 평가 결과입니다.
        private ConditionEvaluationContext conditionContext;

        /// <summary>
        /// 메인 폼과 필요한 서비스/보조 창을 초기화합니다.
        /// </summary>
        public FormMain()
        {
            InitializeComponent();

            optionsForm = new FormOptions();
            optionsForm.Owner = this;
            excelWorkbookService = new ExcelWorkbookService();
            gridPainter = new GridPainter();

            sourceFilePath = string.Empty;
            conditionContext = null;
            UpdateCurrentFileLabel();
        }

        /// <summary>
        /// Excel 파일을 열고 조건 설정 창을 통해 조건 색칠을 적용합니다.
        /// </summary>
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

            // 파일이 실제로 존재하지 않으면 열기 흐름을 중단합니다.
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

            Text = $"Condition Excel Painter - {sourceFilePath}";
            UpdateCurrentFileLabel();
            mainGridView.DataSource = excelWorkbookService.LoadFileToDataTable(sourceFilePath);

            using (FormSetConditions formDataDetails = new FormSetConditions(mainGridView))
            {
                formDataDetails.Owner = this;
                formDataDetails.ShowDialog();
                // 조건 설정 창에서 계산된 조건 평가 결과입니다.
                conditionContext = formDataDetails.ConditionContext;
                if (conditionContext is null)
                    return;

                try
                {
                    gridPainter.Paint(mainGridView, conditionContext);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// 도움말 웹 페이지를 엽니다.
        /// </summary>
        private void helpMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://growndombo.tistory.com/7");
        }

        /// <summary>
        /// 설정 창을 엽니다.
        /// </summary>
        private void optionsMenuItem_Click(object sender, EventArgs e)
        {
            optionsForm.ShowDialog();
        }

        /// <summary>
        /// 바인딩 완료 후 사용자가 컬럼 정렬을 바꾸지 못하도록 막습니다.
        /// </summary>
        private void mainGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewColumn col in mainGridView.Columns)
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        /// <summary>
        /// 그리드 행 머리글에 1부터 시작하는 행 번호를 그립니다.
        /// </summary>
        private void mainGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            // 화면에 표시할 행 번호입니다.
            string rowIndex = (e.RowIndex + 1).ToString();
            // 행 번호를 가운데 정렬하기 위한 서식입니다.
            StringFormat centerFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            // 행 번호를 그릴 RowHeader 영역입니다.
            Rectangle headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, mainGridView.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIndex, mainGridView.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        /// <summary>
        /// 현재 그리드 내용을 Excel 파일로 Export합니다.
        /// </summary>
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
                // Export 후 사용자가 열어볼 경로 정보입니다.
                ExcelExportResult exportResult = excelWorkbookService.ExportGrid(mainGridView, sourceFilePath, conditionContext);

                Process.Start(exportResult.OpenTargetPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"에러 {ex}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Ctrl+F 단축키로 검색창을 열거나 이미 열린 검색창에 포커스를 줍니다.
        /// </summary>
        private void UpdateCurrentFileLabel()
        {
            currentFileLabel.Text = string.IsNullOrEmpty(sourceFilePath)
                ? "No file opened"
                : $"Current file: {Path.GetFileName(sourceFilePath)}";
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.F))
            {
                // 현재 사용할 검색창 인스턴스입니다.
                FormSearch currentSearchForm = GetSearchForm();
                if (currentSearchForm.Visible)
                    currentSearchForm.Focus();
                else
                    currentSearchForm.Show();

                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// 닫혀서 Dispose된 검색창은 새로 만들고, 살아있는 검색창은 재사용합니다.
        /// </summary>
        private FormSearch GetSearchForm()
        {
            if (searchForm == null || searchForm.IsDisposed)
            {
                searchForm = new FormSearch(mainGridView);
                searchForm.Owner = this;
            }

            return searchForm;
        }
    }
}
