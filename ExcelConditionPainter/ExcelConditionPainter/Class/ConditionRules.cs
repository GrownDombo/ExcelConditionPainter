using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Drawing;
using System.Linq;

namespace ExcelConditionPainter
{
    /// <summary>
    /// 모든 조건 계산 전략이 공유하는 색칠 설정과 결과 생성 로직입니다.
    /// </summary>
    public abstract class ConditionRuleBase : IConditionRule
    {
        private readonly string[] targetColumnNames;

        public int AppliedConditionIndex { get; set; }
        public int PriorityLevel { get; set; }
        public PaintTarget PaintTarget { get; set; }
        public MultiSelectMatchMode MatchMode { get; set; }
        public Color SelectedColor { get; set; }

        protected ConditionRuleBase(int priorityLevel, PaintTarget paintTarget, MultiSelectMatchMode matchMode, Color selectedColor, IEnumerable<string> targetColumnNames)
        {
            PriorityLevel = priorityLevel;
            PaintTarget = paintTarget;
            MatchMode = matchMode;
            SelectedColor = selectedColor;
            this.targetColumnNames = targetColumnNames == null
                ? new string[0]
                : targetColumnNames.ToArray();
        }

        public abstract bool Evaluate(ConditionEvaluationContext conditionContext);

        public ConditionPaintInstruction CreatePaintInstruction()
        {
            return new ConditionPaintInstruction(PriorityLevel, AppliedConditionIndex, PaintTarget, SelectedColor, targetColumnNames);
        }
    }

    /// <summary>
    /// 선택한 컬럼 값이 중복되는 행을 찾는 조건입니다.
    /// </summary>
    public sealed class DuplicateConditionRule : ConditionRuleBase
    {
        private readonly string[] selectedColumnNames;

        public DuplicateConditionRule(int priorityLevel, PaintTarget paintTarget, MultiSelectMatchMode matchMode, Color selectedColor, IEnumerable<string> selectedColumnNames)
            : base(priorityLevel, paintTarget, matchMode, selectedColor, selectedColumnNames)
        {
            this.selectedColumnNames = selectedColumnNames == null
                ? new string[0]
                : selectedColumnNames.ToArray();
        }

        public override bool Evaluate(ConditionEvaluationContext conditionContext)
        {
            if (selectedColumnNames.Length == 0)
                return false;

            if (MatchMode == MultiSelectMatchMode.Or)
                return EvaluateOr(conditionContext);

            return EvaluateAnd(conditionContext);
        }

        private bool EvaluateAnd(ConditionEvaluationContext conditionContext)
        {
            DataTable dataTable = conditionContext.ConditionTable;
            Dictionary<string, List<DataRow>> groupedResults = GroupRows(dataTable, selectedColumnNames);

            foreach (List<DataRow> rows in groupedResults.Values)
            {
                if (rows.Count <= 1)
                    continue;

                foreach (DataRow row in rows)
                {
                    string primaryValue = row[conditionContext.PrimaryColumnName].ToString();
                    conditionContext.TryAddCondition(primaryValue, this);
                }
            }

            return true;
        }

        private bool EvaluateOr(ConditionEvaluationContext conditionContext)
        {
            DataTable dataTable = conditionContext.ConditionTable;

            foreach (string columnName in selectedColumnNames)
            {
                Dictionary<string, List<DataRow>> groupedResults = GroupRows(dataTable, new[] { columnName });

                foreach (List<DataRow> rows in groupedResults.Values)
                {
                    if (rows.Count <= 1)
                        continue;

                    foreach (DataRow row in rows)
                    {
                        string primaryValue = row[conditionContext.PrimaryColumnName].ToString();
                        conditionContext.TryAddCondition(primaryValue, this, new[] { columnName });
                    }
                }
            }

            return true;
        }

        private static Dictionary<string, List<DataRow>> GroupRows(DataTable dataTable, IEnumerable<string> columnNames)
        {
            string[] columns = columnNames.ToArray();
            Dictionary<string, List<DataRow>> groupedResults = new Dictionary<string, List<DataRow>>();

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow dataRow = dataTable.Rows[i];
                string groupKey = string.Join("|", columns.Select(col => dataRow[col].ToString()));
                if (groupedResults.TryGetValue(groupKey, out List<DataRow> matchingRows) == false)
                {
                    matchingRows = new List<DataRow>();
                    groupedResults[groupKey] = matchingRows;
                }

                matchingRows.Add(dataRow);
            }

            return groupedResults;
        }
    }

    /// <summary>
    /// 선택한 컬럼 그룹별 첫 주문자를 순서대로 찾는 조건입니다.
    /// </summary>
    public sealed class DistinctOrderConditionRule : ConditionRuleBase
    {
        private readonly string[] selectedColumnNames;
        private readonly int peopleLimit;

        public DistinctOrderConditionRule(int priorityLevel, PaintTarget paintTarget, MultiSelectMatchMode matchMode, Color selectedColor, IEnumerable<string> selectedColumnNames, int peopleLimit)
            : base(priorityLevel, paintTarget, matchMode, selectedColor, null)
        {
            this.selectedColumnNames = selectedColumnNames == null
                ? new string[0]
                : selectedColumnNames.ToArray();
            this.peopleLimit = peopleLimit;
        }

        public override bool Evaluate(ConditionEvaluationContext conditionContext)
        {
            if (selectedColumnNames.Length == 0)
                return false;

            if (MatchMode == MultiSelectMatchMode.Or)
                return ApplyCalculations(conditionContext, GetOrCalculations(conditionContext));

            return ApplyCalculations(conditionContext, GetDistinctOrderCalculations(conditionContext, selectedColumnNames));
        }

        private IEnumerable<DistinctOrderConditionCalculation> GetOrCalculations(ConditionEvaluationContext conditionContext)
        {
            foreach (string columnName in selectedColumnNames)
            {
                foreach (DistinctOrderConditionCalculation calculation in GetDistinctOrderCalculations(conditionContext, new[] { columnName }))
                    yield return calculation;
            }
        }

        private bool ApplyCalculations(ConditionEvaluationContext conditionContext, IEnumerable<DistinctOrderConditionCalculation> calculations)
        {
            int addedCount = 0;
            HashSet<string> addedPrimaryValues = new HashSet<string>();

            foreach (DistinctOrderConditionCalculation calculation in calculations)
            {
                if (addedPrimaryValues.Contains(calculation.FirstRowPrimaryValue))
                    continue;
                if (conditionContext.TryAddCondition(calculation.FirstRowPrimaryValue, this) == false)
                    continue;

                addedPrimaryValues.Add(calculation.FirstRowPrimaryValue);
                addedCount++;
                if (addedCount >= peopleLimit)
                    break;
            }

            return addedCount > 0;
        }

        private static List<DistinctOrderConditionCalculation> GetDistinctOrderCalculations(ConditionEvaluationContext conditionContext, IEnumerable<string> columnNames)
        {
            string[] columns = columnNames.ToArray();
            string selectedColumnsKey = string.Join("|", columns);
            if (conditionContext.DistinctOrderCalculationsBySelection.TryGetValue(selectedColumnsKey, out List<DistinctOrderConditionCalculation> cachedCalculations))
                return cachedCalculations;

            DataTable dataTable = conditionContext.ConditionTable;
            string primaryColumnName = conditionContext.PrimaryColumnName;
            Dictionary<string, DistinctOrderConditionCalculation> calculationsByGroup = new Dictionary<string, DistinctOrderConditionCalculation>();
            List<DistinctOrderConditionCalculation> calculations = new List<DistinctOrderConditionCalculation>();

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow dataRow = dataTable.Rows[i];
                string groupKey = string.Join("|", columns.Select(col => dataRow[col]));
                string primaryValue = dataRow[primaryColumnName].ToString();

                if (calculationsByGroup.TryGetValue(groupKey, out DistinctOrderConditionCalculation calculation))
                {
                    calculation.AddAdditionalData(primaryValue);
                }
                else
                {
                    calculation = new DistinctOrderConditionCalculation(primaryValue);
                    calculationsByGroup[groupKey] = calculation;
                    calculations.Add(calculation);
                }
            }

            conditionContext.DistinctOrderCalculationsBySelection[selectedColumnsKey] = calculations;
            return calculations;
        }
    }

    /// <summary>
    /// 선택한 컬럼 그룹별 총 상품 수량이 기준 이상인지 판단하는 조건입니다.
    /// </summary>
    public sealed class QuantityConditionRule : ConditionRuleBase
    {
        private readonly string[] selectedColumnNames;
        private readonly int goodsCount;
        private readonly int peopleLimit;

        public QuantityConditionRule(int priorityLevel, PaintTarget paintTarget, MultiSelectMatchMode matchMode, Color selectedColor, IEnumerable<string> selectedColumnNames, int goodsCount, int peopleLimit)
            : base(priorityLevel, paintTarget, matchMode, selectedColor, null)
        {
            this.selectedColumnNames = selectedColumnNames == null
                ? new string[0]
                : selectedColumnNames.ToArray();
            this.goodsCount = goodsCount;
            this.peopleLimit = peopleLimit;
        }

        public override bool Evaluate(ConditionEvaluationContext conditionContext)
        {
            if (selectedColumnNames.Length == 0)
                return false;

            IEnumerable<QuantityConditionCalculation> calculations = MatchMode == MultiSelectMatchMode.Or
                ? GetOrCalculations(conditionContext)
                : GetQuantityCalculations(conditionContext, selectedColumnNames);

            return ApplyCalculations(conditionContext, calculations);
        }

        private IEnumerable<QuantityConditionCalculation> GetOrCalculations(ConditionEvaluationContext conditionContext)
        {
            foreach (string columnName in selectedColumnNames)
            {
                foreach (QuantityConditionCalculation calculation in GetQuantityCalculations(conditionContext, new[] { columnName }))
                    yield return calculation;
            }
        }

        private bool ApplyCalculations(ConditionEvaluationContext conditionContext, IEnumerable<QuantityConditionCalculation> calculations)
        {
            int addedCount = 0;
            HashSet<string> addedPrimaryValues = new HashSet<string>();

            foreach (QuantityConditionCalculation calculation in calculations)
            {
                if (calculation.TotalGoodsCount < goodsCount)
                    continue;
                if (addedPrimaryValues.Contains(calculation.FirstRowPrimaryValue))
                    continue;
                if (conditionContext.TryAddCondition(calculation.FirstRowPrimaryValue, this) == false)
                    continue;

                addedPrimaryValues.Add(calculation.FirstRowPrimaryValue);
                addedCount++;
                if (addedCount >= peopleLimit)
                    break;
            }

            return addedCount > 0;
        }

        private static List<QuantityConditionCalculation> GetQuantityCalculations(ConditionEvaluationContext conditionContext, IEnumerable<string> columnNames)
        {
            string[] columns = columnNames.ToArray();
            string selectedColumnsKey = string.Join("|", columns);
            if (conditionContext.QuantityCalculationsBySelection.TryGetValue(selectedColumnsKey, out List<QuantityConditionCalculation> cachedCalculations))
                return cachedCalculations;

            string primaryColumnName = conditionContext.PrimaryColumnName;
            string buyCountColumnName = conditionContext.BuyCountColumnName;
            string optionColumnName = conditionContext.OptionColumnName;
            ReadOnlyDictionary<string, int> goodsQuantitiesByOption = conditionContext.GoodsQuantitiesByOption;
            DataTable dataTable = conditionContext.ConditionTable;
            Dictionary<string, QuantityConditionCalculation> calculationsByGroup = new Dictionary<string, QuantityConditionCalculation>();
            List<QuantityConditionCalculation> calculations = new List<QuantityConditionCalculation>();

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow dataRow = dataTable.Rows[i];
                string groupKey = string.Join("|", columns.Select(col => dataRow[col]));
                int buyCount = Convert.ToInt32(dataRow[buyCountColumnName]);
                string optionValue = dataRow[optionColumnName].ToString();
                int goodsQuantity = goodsQuantitiesByOption[optionValue];
                string primaryValue = dataRow[primaryColumnName].ToString();
                int totalGoodsCount = buyCount * goodsQuantity;

                if (calculationsByGroup.TryGetValue(groupKey, out QuantityConditionCalculation calculation))
                {
                    calculation.AddAdditionalData(primaryValue, totalGoodsCount);
                }
                else
                {
                    calculation = new QuantityConditionCalculation(primaryValue, totalGoodsCount);
                    calculationsByGroup[groupKey] = calculation;
                    calculations.Add(calculation);
                }
            }

            conditionContext.QuantityCalculationsBySelection[selectedColumnsKey] = calculations;
            return calculations;
        }
    }

    /// <summary>
    /// 특정 옵션을 구매한 주문자를 순서대로 찾는 조건입니다.
    /// </summary>
    public sealed class OptionPurchaseOrderConditionRule : ConditionRuleBase
    {
        private readonly string[] selectedOptionNames;
        private readonly int peopleLimit;

        public OptionPurchaseOrderConditionRule(int priorityLevel, PaintTarget paintTarget, Color selectedColor, IEnumerable<string> selectedOptionNames, int peopleLimit)
            : base(priorityLevel, paintTarget, MultiSelectMatchMode.Or, selectedColor, null)
        {
            this.selectedOptionNames = selectedOptionNames == null
                ? new string[0]
                : selectedOptionNames.ToArray();
            this.peopleLimit = peopleLimit;
        }

        public override bool Evaluate(ConditionEvaluationContext conditionContext)
        {
            if (selectedOptionNames.Length == 0)
                return false;

            string primaryColumnName = conditionContext.PrimaryColumnName;
            string optionColumnName = conditionContext.OptionColumnName;
            DataTable dataTable = conditionContext.ConditionTable;

            int addedCount = 0;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow dataRow = dataTable.Rows[i];
                string optionValue = dataRow[optionColumnName].ToString();
                if (selectedOptionNames.Contains(optionValue) == false)
                    continue;

                string primaryValue = dataRow[primaryColumnName].ToString();
                if (conditionContext.TryAddCondition(primaryValue, this) == false)
                    continue;

                addedCount++;
                if (addedCount >= peopleLimit)
                    break;
            }

            return addedCount > 0;
        }
    }
}
