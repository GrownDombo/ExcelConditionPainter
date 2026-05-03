using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelConditionPainter
{
    public partial class FormSearch : Form
    {
        private readonly DataGridView mainGridView;
        public FormSearch(DataGridView mainGridView)
        {
            InitializeComponent();
            this.mainGridView = mainGridView;
        }

        private void FormSearch_Shown(object sender, EventArgs e)
        {
            if (mainGridView.CurrentCell == null || mainGridView.CurrentCell.Value == null)
                searchTextBox.Text = string.Empty; // 선택된 셀이 없거나 값이 없으면 텍스트박스를 비움
            else
                searchTextBox.Text = mainGridView.CurrentCell.Value.ToString(); // 선택된 셀의 텍스트를 텍스트박스에 설정
        }
        private void searchAllButton_Click(object sender, EventArgs e)
        {
            string searchText = searchTextBox.Text.Trim(); // 검색할 텍스트 가져오기
            if (string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show("검색어를 입력하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            allSearchResultsGridView.Rows.Clear(); // 모든 검색 결과 초기화
            // 모든 셀 검색
            for (int rowIndex = 0; rowIndex < mainGridView.Rows.Count; rowIndex++)
            {
                DataGridViewRow row = mainGridView.Rows[rowIndex];
                for (int columnIndex = 0; columnIndex < mainGridView.Columns.Count; columnIndex++)
                {
                    DataGridViewCell cell = row.Cells[columnIndex];
                    if (cell.Value == null)
                        continue;

                    if (cell.Value.ToString().Contains(searchText))
                    {
                        string headerText = mainGridView.Columns[cell.ColumnIndex].HeaderText; // 열 이름
                        string rowNumberText = (row.Index + 1).ToString(); // 행 번호
                        string cellValue = cell.Value.ToString();
                        allSearchResultsGridView.Rows.Add(headerText, rowNumberText, cellValue);
                    }
                }
            }
        }

        private void FormSearch_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();   // 리소스 정리
        }

        private void allSearchResultsGridView_SelectionChanged(object sender, EventArgs e)
        {
            mainGridView.SuspendLayout();
            try
            {
                if (allSearchResultsGridView.SelectedRows.Count == 0)
                    return;

                // 선택된 행 가져오기
                DataGridViewRow selectedRow = allSearchResultsGridView.SelectedRows[0];
                // 열 이름, 행 번호 가져오기
                string columnName = selectedRow.Cells[0].Value?.ToString(); // 열 이름
                string rowIndexStr = selectedRow.Cells[1].Value?.ToString(); // 행 번호
                if (string.IsNullOrEmpty(columnName) || string.IsNullOrEmpty(rowIndexStr))
                    return;

                if (!int.TryParse(rowIndexStr, out int rowIndex))
                    return;

                mainGridView.CurrentCell = mainGridView.Rows[rowIndex - 1].Cells[columnName];
                mainGridView.FirstDisplayedScrollingRowIndex = rowIndex - 1; // 스크롤 이동
            }
            finally
            {
                mainGridView.ResumeLayout();
            }
        }
    }
}
