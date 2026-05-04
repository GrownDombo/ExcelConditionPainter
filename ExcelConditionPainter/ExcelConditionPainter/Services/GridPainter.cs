using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ExcelConditionPainter
{
    /// <summary>
    /// 평가된 조건 색칠 지시를 WinForms 그리드에 반영합니다.
    /// </summary>
    public class GridPainter
    {
        /// <summary>
        /// 조건 평가 결과를 DataGridView의 행과 셀 스타일에 적용합니다.
        /// </summary>
        public void Paint(DataGridView dataGridView, ConditionEvaluationContext conditionContext)
        {
            dataGridView.DataSource = conditionContext.ConditionTable;
            // 기본키 검색을 위해 그리드에 바인딩된 테이블을 다시 가져옵니다.
            DataTable dataTable = dataGridView.DataSource as DataTable;

            foreach (KeyValuePair<string, List<ConditionMatch>> conditionEntry in conditionContext.ConditionsByPrimaryValue)
            {
                // 조건이 적용된 기본키 값입니다.
                string primaryValue = conditionEntry.Key;
                // 기본키 값이 위치한 DataGridView 행 인덱스입니다.
                int rowIndex = dataTable.Rows.IndexOf(dataTable.Rows.Find(primaryValue));
                if (rowIndex < 0)
                    throw new InvalidOperationException($"Row index not found for {primaryValue} in {conditionContext.PrimaryColumnName} column.");

                // 실제 색칠할 그리드 행입니다.
                DataGridViewRow row = dataGridView.Rows[rowIndex];
                foreach (ConditionMatch conditionMatch in conditionEntry.Value)
                    ApplyPaintInstruction(row, conditionMatch.CreatePaintInstruction());
            }
        }

        /// <summary>
        /// 행 전체 또는 지정 컬럼 셀에 색칠 지시를 적용합니다.
        /// </summary>
        private void ApplyPaintInstruction(DataGridViewRow row, ConditionPaintInstruction paintInstruction)
        {
            if (paintInstruction.AppliesToWholeRow)
            {
                ApplyRowColor(row, paintInstruction.PaintTarget, paintInstruction.SelectedColor);
                return;
            }

            foreach (string columnName in paintInstruction.TargetColumnNames)
            {
                if (row.DataGridView.Columns.Contains(columnName) == false)
                    continue;

                ApplyCellColor(row.Cells[columnName], paintInstruction.PaintTarget, paintInstruction.SelectedColor);
            }
        }

        /// <summary>
        /// 행 전체의 글자색 또는 배경색을 변경합니다.
        /// </summary>
        private void ApplyRowColor(DataGridViewRow row, PaintTarget paintTarget, Color color)
        {
            if (paintTarget == PaintTarget.Font)
            {
                row.DefaultCellStyle.ForeColor = color;
                row.DefaultCellStyle.SelectionForeColor = color;
            }
            else
            {
                row.DefaultCellStyle.BackColor = color;
                row.DefaultCellStyle.SelectionBackColor = color;
            }
        }

        /// <summary>
        /// 개별 셀의 글자색 또는 배경색을 변경합니다.
        /// </summary>
        private void ApplyCellColor(DataGridViewCell cell, PaintTarget paintTarget, Color color)
        {
            if (paintTarget == PaintTarget.Font)
            {
                cell.Style.ForeColor = color;
                cell.Style.SelectionForeColor = color;
            }
            else
            {
                cell.Style.BackColor = color;
                cell.Style.SelectionBackColor = color;
            }
        }
    }
}
