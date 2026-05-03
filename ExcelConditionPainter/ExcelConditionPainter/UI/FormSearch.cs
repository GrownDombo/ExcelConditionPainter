using System;
using System.Windows.Forms;

namespace ExcelConditionPainter
{
    /// <summary>
    /// 메인 그리드에서 문자열을 검색하고 선택 위치로 이동하는 창입니다.
    /// </summary>
    public partial class FormSearch : Form
    {
        // 검색 대상 메인 그리드입니다.
        private readonly DataGridView mainGridView;

        /// <summary>
        /// 검색 대상 그리드를 받아 검색창을 초기화합니다.
        /// </summary>
        public FormSearch(DataGridView mainGridView)
        {
            InitializeComponent();
            this.mainGridView = mainGridView;
        }

        /// <summary>
        /// 창이 표시될 때 현재 선택 셀 값을 검색어로 채웁니다.
        /// </summary>
        private void FormSearch_Shown(object sender, EventArgs e)
        {
            if (mainGridView.CurrentCell == null || mainGridView.CurrentCell.Value == null)
                searchTextBox.Text = string.Empty;
            else
                searchTextBox.Text = mainGridView.CurrentCell.Value.ToString();
        }

        /// <summary>
        /// 검색어가 포함된 모든 셀을 결과 그리드에 표시합니다.
        /// </summary>
        private void searchAllButton_Click(object sender, EventArgs e)
        {
            // 사용자가 입력한 검색어입니다.
            string searchText = searchTextBox.Text.Trim();
            if (string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show("검색어를 입력하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            allSearchResultsGridView.Rows.Clear();
            for (int rowIndex = 0; rowIndex < mainGridView.Rows.Count; rowIndex++)
            {
                // 현재 검색 중인 행입니다.
                DataGridViewRow row = mainGridView.Rows[rowIndex];
                for (int columnIndex = 0; columnIndex < mainGridView.Columns.Count; columnIndex++)
                {
                    // 현재 검색 중인 셀입니다.
                    DataGridViewCell cell = row.Cells[columnIndex];
                    if (cell.Value == null)
                        continue;

                    if (cell.Value.ToString().Contains(searchText))
                    {
                        // 검색 결과에 표시할 컬럼명입니다.
                        string headerText = mainGridView.Columns[cell.ColumnIndex].HeaderText;
                        // 검색 결과에 표시할 1부터 시작하는 행 번호입니다.
                        string rowNumberText = (row.Index + 1).ToString();
                        // 검색 결과에 표시할 셀 값입니다.
                        string cellValue = cell.Value.ToString();
                        allSearchResultsGridView.Rows.Add(headerText, rowNumberText, cellValue);
                    }
                }
            }
        }

        /// <summary>
        /// 검색창 닫기 시 별도 처리는 하지 않고 FormMain에서 재생성하게 둡니다.
        /// </summary>
        private void FormSearch_FormClosing(object sender, FormClosingEventArgs e)
        {
            // FormMain이 닫힌 검색창을 다음 호출 때 새로 생성합니다.
        }

        /// <summary>
        /// 검색 결과 행을 선택하면 메인 그리드의 해당 셀로 이동합니다.
        /// </summary>
        private void allSearchResultsGridView_SelectionChanged(object sender, EventArgs e)
        {
            mainGridView.SuspendLayout();
            try
            {
                if (allSearchResultsGridView.SelectedRows.Count == 0)
                    return;

                // 사용자가 선택한 검색 결과 행입니다.
                DataGridViewRow selectedRow = allSearchResultsGridView.SelectedRows[0];
                // 이동할 컬럼명입니다.
                string columnName = selectedRow.Cells[0].Value?.ToString();
                // 이동할 행 번호 문자열입니다.
                string rowIndexStr = selectedRow.Cells[1].Value?.ToString();
                if (string.IsNullOrEmpty(columnName) || string.IsNullOrEmpty(rowIndexStr))
                    return;

                // 1부터 시작하는 행 번호를 숫자로 변환한 값입니다.
                if (!int.TryParse(rowIndexStr, out int rowIndex))
                    return;

                mainGridView.CurrentCell = mainGridView.Rows[rowIndex - 1].Cells[columnName];
                mainGridView.FirstDisplayedScrollingRowIndex = rowIndex - 1;
            }
            finally
            {
                mainGridView.ResumeLayout();
            }
        }
    }
}
