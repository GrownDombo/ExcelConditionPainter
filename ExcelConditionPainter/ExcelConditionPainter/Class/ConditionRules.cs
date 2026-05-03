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
        // 셀 단위 색칠에 사용할 컬럼명 목록입니다. 비어 있으면 행 전체 색칠입니다.
        private readonly string[] targetColumnNames;

        // 평가 후 실제 적용된 조건 순번입니다.
        public int AppliedConditionIndex { get; set; }
        // 조건 우선순위입니다.
        public int PriorityLevel { get; set; }
        // 글자색/배경색 중 적용할 대상입니다.
        public PaintTarget PaintTarget { get; set; }
        // 적용할 색상입니다.
        public Color SelectedColor { get; set; }

        /// <summary>
        /// 조건의 공통 색칠 설정을 초기화합니다.
        /// </summary>
        protected ConditionRuleBase(int priorityLevel, PaintTarget paintTarget, Color selectedColor, IEnumerable<string> targetColumnNames)
        {
            PriorityLevel = priorityLevel;
            PaintTarget = paintTarget;
            SelectedColor = selectedColor;
            this.targetColumnNames = targetColumnNames == null
                ? new string[0]
                : targetColumnNames.ToArray();
        }

        /// <summary>
        /// 조건을 평가하고 매칭된 기본키에 자신을 등록합니다.
        /// </summary>
        public abstract bool Evaluate(ConditionEvaluationContext conditionContext);

        /// <summary>
        /// GridPainter가 사용할 색칠 지시 객체를 만듭니다.
        /// </summary>
        public ConditionPaintInstruction CreatePaintInstruction()
        {
            return new ConditionPaintInstruction(PriorityLevel, AppliedConditionIndex, PaintTarget, SelectedColor, targetColumnNames);
        }
    }

    /// <summary>
    /// 선택한 컬럼 조합이 중복되는 행을 찾는 조건입니다.
    /// </summary>
    public sealed class DuplicateConditionRule : ConditionRuleBase
    {
        // 중복 판단에 사용할 컬럼명 목록입니다.
        private readonly string[] selectedColumnNames;

        /// <summary>
        /// 중복 조건에 필요한 선택 컬럼과 색칠 설정을 받습니다.
        /// </summary>
        public DuplicateConditionRule(int priorityLevel, PaintTarget paintTarget, Color selectedColor, IEnumerable<string> selectedColumnNames)
            : base(priorityLevel, paintTarget, selectedColor, selectedColumnNames)
        {
            this.selectedColumnNames = selectedColumnNames == null
                ? new string[0]
                : selectedColumnNames.ToArray();
        }

        /// <summary>
        /// 선택 컬럼 값이 같은 행들을 찾아 조건 결과에 추가합니다.
        /// </summary>
        public override bool Evaluate(ConditionEvaluationContext conditionContext)
        {
            if (selectedColumnNames.Length == 0)
                return false;

            // 조건 결과를 저장할 기본키 컬럼명입니다.
            string primaryColumnName = conditionContext.PrimaryColumnName;
            // 조건 평가 대상 테이블입니다.
            DataTable dataTable = conditionContext.ConditionTable;

            // 선택 컬럼 값 조합별 행 목록입니다.
            Dictionary<string, List<DataRow>> groupedResults = new Dictionary<string, List<DataRow>>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                // 현재 검사 중인 행입니다.
                DataRow dataRow = dataTable.Rows[i];
                // 선택 컬럼 값을 합쳐 만든 그룹 키입니다.
                string groupKey = string.Join("|", selectedColumnNames.Select(col => dataRow[col].ToString()));
                if (groupedResults.TryGetValue(groupKey, out List<DataRow> matchingRows) == false)
                {
                    matchingRows = new List<DataRow>();
                    groupedResults[groupKey] = matchingRows;
                }
                matchingRows.Add(dataRow);
            }

            foreach (List<DataRow> rows in groupedResults.Values)
            {
                if (rows.Count <= 1)
                    continue;

                for (int i = 0; i < rows.Count; i++)
                {
                    // 중복 그룹에 포함된 행입니다.
                    DataRow row = rows[i];
                    // 조건 결과에 등록할 기본키 값입니다.
                    string primaryValue = row[primaryColumnName].ToString();
                    conditionContext.TryAddCondition(primaryValue, this);
                }
            }

            return true;
        }
    }

    /// <summary>
    /// 선택 컬럼 조합별 첫 주문자를 순서대로 찾는 조건입니다.
    /// </summary>
    public sealed class DistinctOrderConditionRule : ConditionRuleBase
    {
        // 순서 그룹을 만들 때 사용할 컬럼명 목록입니다.
        private readonly string[] selectedColumnNames;
        // 조건을 적용할 최대 인원 수입니다.
        private readonly int peopleLimit;

        /// <summary>
        /// 중복 제외 순서 조건에 필요한 설정을 받습니다.
        /// </summary>
        public DistinctOrderConditionRule(int priorityLevel, PaintTarget paintTarget, Color selectedColor, IEnumerable<string> selectedColumnNames, int peopleLimit)
            : base(priorityLevel, paintTarget, selectedColor, null)
        {
            this.selectedColumnNames = selectedColumnNames == null
                ? new string[0]
                : selectedColumnNames.ToArray();
            this.peopleLimit = peopleLimit;
        }

        /// <summary>
        /// 선택 컬럼 조합별 첫 행을 찾아 인원 제한까지 조건 결과에 추가합니다.
        /// </summary>
        public override bool Evaluate(ConditionEvaluationContext conditionContext)
        {
            if (selectedColumnNames.Length == 0)
                return false;

            // 조건 결과를 저장할 기본키 컬럼명입니다.
            string primaryColumnName = conditionContext.PrimaryColumnName;
            // 조건 평가 대상 테이블입니다.
            DataTable dataTable = conditionContext.ConditionTable;

            // 선택 컬럼 조합을 캐시 키로 사용합니다.
            string selectedColumnsKey = string.Join("|", selectedColumnNames);
            if (conditionContext.DistinctOrderCalculationsBySelection.TryGetValue(selectedColumnsKey, out Dictionary<string, DistinctOrderConditionCalculation> distinctOrderCalculations) == false)
            {
                distinctOrderCalculations = new Dictionary<string, DistinctOrderConditionCalculation>();
                conditionContext.DistinctOrderCalculationsBySelection[selectedColumnsKey] = distinctOrderCalculations;

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    // 현재 검사 중인 행입니다.
                    DataRow dataRow = dataTable.Rows[i];
                    // 같은 그룹을 묶기 위한 선택 컬럼 값 조합입니다.
                    string groupKey = string.Join("|", selectedColumnNames.Select(col => dataRow[col]));
                    // 그룹의 대표 기본키 후보입니다.
                    string primaryValue = dataRow[primaryColumnName].ToString();

                    if (distinctOrderCalculations.TryGetValue(groupKey, out DistinctOrderConditionCalculation distinctOrderCalculation))
                        distinctOrderCalculation.AddAdditionalData(primaryValue);
                    else
                        distinctOrderCalculations[groupKey] = new DistinctOrderConditionCalculation(primaryValue);
                }
            }

            // 현재까지 조건을 적용한 인원 수입니다.
            int peopleCount = 1;
            foreach (DistinctOrderConditionCalculation distinctOrderCalculation in distinctOrderCalculations.Values)
            {
                if (conditionContext.TryAddCondition(distinctOrderCalculation.FirstRowPrimaryValue, this) == false)
                    continue;
                if (++peopleCount > peopleLimit)
                    break;
            }

            return peopleCount > 1;
        }
    }

    /// <summary>
    /// 선택 컬럼 그룹의 총 상품 수량이 기준을 넘는지 판단하는 조건입니다.
    /// </summary>
    public sealed class QuantityConditionRule : ConditionRuleBase
    {
        // 수량 그룹을 만들 때 사용할 컬럼명 목록입니다.
        private readonly string[] selectedColumnNames;
        // 조건 적용 기준이 되는 총 상품 수량입니다.
        private readonly int goodsCount;
        // 조건을 적용할 최대 인원 수입니다.
        private readonly int peopleLimit;

        /// <summary>
        /// 수량 조건에 필요한 선택 컬럼, 기준 수량, 인원 제한을 받습니다.
        /// </summary>
        public QuantityConditionRule(int priorityLevel, PaintTarget paintTarget, Color selectedColor, IEnumerable<string> selectedColumnNames, int goodsCount, int peopleLimit)
            : base(priorityLevel, paintTarget, selectedColor, null)
        {
            this.selectedColumnNames = selectedColumnNames == null
                ? new string[0]
                : selectedColumnNames.ToArray();
            this.goodsCount = goodsCount;
            this.peopleLimit = peopleLimit;
        }

        /// <summary>
        /// 그룹별 총 상품 수량을 계산한 뒤 기준 이상인 그룹을 조건 결과에 추가합니다.
        /// </summary>
        public override bool Evaluate(ConditionEvaluationContext conditionContext)
        {
            if (selectedColumnNames.Length == 0)
                return false;

            // 조건 결과를 저장할 기본키 컬럼명입니다.
            string primaryColumnName = conditionContext.PrimaryColumnName;
            // 구매 수량 컬럼명입니다.
            string buyCountColumnName = conditionContext.BuyCountColumnName;
            // 상품 옵션 컬럼명입니다.
            string optionColumnName = conditionContext.OptionColumnName;
            // 옵션명별 실제 상품 수량입니다.
            ReadOnlyDictionary<string, int> goodsQuantitiesByOption = conditionContext.GoodsQuantitiesByOption;
            // 조건 평가 대상 테이블입니다.
            DataTable dataTable = conditionContext.ConditionTable;

            // 선택 컬럼 조합을 캐시 키로 사용합니다.
            string selectedColumnsKey = string.Join("|", selectedColumnNames);
            if (conditionContext.QuantityCalculationsBySelection.TryGetValue(selectedColumnsKey, out Dictionary<string, QuantityConditionCalculation> groupedCalculations) == false)
            {
                groupedCalculations = new Dictionary<string, QuantityConditionCalculation>();
                conditionContext.QuantityCalculationsBySelection[selectedColumnsKey] = groupedCalculations;

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    // 현재 검사 중인 행입니다.
                    DataRow dataRow = dataTable.Rows[i];
                    // 같은 그룹을 묶기 위한 선택 컬럼 값 조합입니다.
                    string groupKey = string.Join("|", selectedColumnNames.Select(col => dataRow[col]));

                    // 사용자가 구매한 옵션 개수입니다.
                    int buyCount = Convert.ToInt32(dataRow[buyCountColumnName]);
                    // 현재 행의 옵션명입니다.
                    string optionValue = dataRow[optionColumnName].ToString();
                    // 옵션 하나가 실제로 의미하는 상품 수량입니다.
                    int goodsQuantity = goodsQuantitiesByOption[optionValue];
                    // 조건 결과에 등록할 기본키 값입니다.
                    string primaryValue = dataRow[primaryColumnName].ToString();
                    // 구매 개수와 옵션 수량을 곱한 실제 상품 수량입니다.
                    int totalGoodsCount = buyCount * goodsQuantity;

                    if (groupedCalculations.TryGetValue(groupKey, out QuantityConditionCalculation quantityCalculation))
                        quantityCalculation.AddAdditionalData(primaryValue, totalGoodsCount);
                    else
                        groupedCalculations[groupKey] = new QuantityConditionCalculation(primaryValue, totalGoodsCount);
                }
            }

            // 현재까지 조건을 적용한 인원 수입니다.
            int peopleCount = 1;
            foreach (QuantityConditionCalculation quantityCalculation in groupedCalculations.Values)
            {
                if (quantityCalculation.TotalGoodsCount < goodsCount)
                    continue;
                if (conditionContext.TryAddCondition(quantityCalculation.FirstRowPrimaryValue, this) == false)
                    continue;
                if (++peopleCount > peopleLimit)
                    break;
            }

            return peopleCount > 1;
        }
    }

    /// <summary>
    /// 특정 옵션을 구매한 행을 순서대로 찾는 조건입니다.
    /// </summary>
    public sealed class OptionPurchaseOrderConditionRule : ConditionRuleBase
    {
        // 사용자가 선택한 옵션명 목록입니다.
        private readonly string[] selectedOptionNames;
        // 조건을 적용할 최대 인원 수입니다.
        private readonly int peopleLimit;

        /// <summary>
        /// 옵션 구매 순서 조건에 필요한 옵션 목록과 인원 제한을 받습니다.
        /// </summary>
        public OptionPurchaseOrderConditionRule(int priorityLevel, PaintTarget paintTarget, Color selectedColor, IEnumerable<string> selectedOptionNames, int peopleLimit)
            : base(priorityLevel, paintTarget, selectedColor, null)
        {
            this.selectedOptionNames = selectedOptionNames == null
                ? new string[0]
                : selectedOptionNames.ToArray();
            this.peopleLimit = peopleLimit;
        }

        /// <summary>
        /// 선택 옵션을 포함한 행을 찾아 인원 제한까지 조건 결과에 추가합니다.
        /// </summary>
        public override bool Evaluate(ConditionEvaluationContext conditionContext)
        {
            if (selectedOptionNames.Length == 0)
                return false;

            // 조건 결과를 저장할 기본키 컬럼명입니다.
            string primaryColumnName = conditionContext.PrimaryColumnName;
            // 상품 옵션 컬럼명입니다.
            string optionColumnName = conditionContext.OptionColumnName;
            // 조건 평가 대상 테이블입니다.
            DataTable dataTable = conditionContext.ConditionTable;

            // 현재까지 조건을 적용한 인원 수입니다.
            int peopleCount = 1;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                // 현재 검사 중인 행입니다.
                DataRow dataRow = dataTable.Rows[i];
                // 현재 행의 옵션명입니다.
                string optionValue = dataRow[optionColumnName].ToString();
                if (selectedOptionNames.Contains(optionValue) == false)
                    continue;

                // 조건 결과에 등록할 기본키 값입니다.
                string primaryValue = dataRow[primaryColumnName].ToString();
                if (conditionContext.TryAddCondition(primaryValue, this) == false)
                    continue;
                if (++peopleCount > peopleLimit)
                    break;
            }

            return peopleCount > 1;
        }
    }
}
