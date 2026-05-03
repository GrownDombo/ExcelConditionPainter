using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;

namespace ExcelConditionPainter
{
    /// <summary>
    /// 조건이 매칭된 행/셀을 어떤 색으로 칠할지 설명하는 값 객체입니다.
    /// </summary>
    public sealed class ConditionPaintInstruction
    {
        // 조건 우선순위입니다.
        public readonly int PriorityLevel;
        // 실제 적용된 조건의 순번입니다.
        public readonly int AppliedConditionIndex;
        // 글자색 또는 배경색 중 칠할 대상입니다.
        public readonly PaintTarget PaintTarget;
        // 적용할 색상입니다.
        public readonly Color SelectedColor;
        // 특정 셀만 칠할 때 사용할 컬럼명 목록입니다.
        public readonly ReadOnlyCollection<string> TargetColumnNames;

        /// <summary>
        /// 특정 컬럼이 없으면 행 전체에 적용할 색칠인지 확인합니다.
        /// </summary>
        public bool AppliesToWholeRow
        {
            get { return TargetColumnNames.Count == 0; }
        }

        /// <summary>
        /// 색칠 대상과 색상 정보를 초기화합니다.
        /// </summary>
        public ConditionPaintInstruction(int priorityLevel, int appliedConditionIndex, PaintTarget paintTarget, Color selectedColor, IEnumerable<string> targetColumnNames)
        {
            PriorityLevel = priorityLevel;
            AppliedConditionIndex = appliedConditionIndex;
            PaintTarget = paintTarget;
            SelectedColor = selectedColor;

            // null 또는 빈 컬럼명은 색칠 대상에서 제외합니다.
            string[] columnNames = targetColumnNames == null
                ? new string[0]
                : targetColumnNames.Where(name => string.IsNullOrEmpty(name) == false).ToArray();
            TargetColumnNames = Array.AsReadOnly(columnNames);
        }
    }
}
