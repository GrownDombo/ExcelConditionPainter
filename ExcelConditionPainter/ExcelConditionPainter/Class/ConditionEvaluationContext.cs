using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;

namespace ExcelConditionPainter
{
    /// <summary>
    /// 조건 평가 중 공유하는 입력 데이터, 캐시, 적용 결과를 담는 컨텍스트입니다.
    /// </summary>
    public class ConditionEvaluationContext
    {
        // 기본키로 사용할 컬럼명입니다.
        public readonly string PrimaryColumnName;
        // 구매 수량이 들어있는 컬럼명입니다.
        public readonly string BuyCountColumnName;
        // 상품 옵션명이 들어있는 컬럼명입니다.
        public readonly string OptionColumnName;
        // 옵션명별 실제 상품 수량입니다.
        public readonly ReadOnlyDictionary<string, int> GoodsQuantitiesByOption;
        // 조건 평가 대상 DataTable입니다.
        public readonly DataTable ConditionTable;

        // 선택 컬럼 조합별 중복 제외 순서 계산 캐시입니다.
        public readonly Dictionary<string, Dictionary<string, DistinctOrderConditionCalculation>> DistinctOrderCalculationsBySelection;
        // 선택 컬럼 조합별 수량 계산 캐시입니다.
        public readonly Dictionary<string, Dictionary<string, QuantityConditionCalculation>> QuantityCalculationsBySelection;
        // 기본키 값별 적용된 조건 목록입니다.
        public readonly Dictionary<string, List<IConditionRule>> ConditionsByPrimaryValue;

        /// <summary>
        /// 조건 평가에 필요한 입력값과 계산 캐시를 초기화합니다.
        /// </summary>
        public ConditionEvaluationContext(string primaryColumnName, string buyCountColumnName, string optionColumnName, Dictionary<string, int> goodsQuantitiesByOption, DataTable conditionTable)
        {
            PrimaryColumnName = primaryColumnName;
            BuyCountColumnName = buyCountColumnName;
            OptionColumnName = optionColumnName;
            GoodsQuantitiesByOption = new ReadOnlyDictionary<string, int>(goodsQuantitiesByOption);
            ConditionTable = conditionTable;

            DistinctOrderCalculationsBySelection = new Dictionary<string, Dictionary<string, DistinctOrderConditionCalculation>>();
            QuantityCalculationsBySelection = new Dictionary<string, Dictionary<string, QuantityConditionCalculation>>();
            ConditionsByPrimaryValue = new Dictionary<string, List<IConditionRule>>();
        }

        /// <summary>
        /// 우선순위 규칙에 맞으면 기본키 값에 조건을 추가합니다.
        /// </summary>
        public bool TryAddCondition(string primaryKey, IConditionRule conditionRule)
        {
            if (ConditionsByPrimaryValue.TryGetValue(primaryKey, out List<IConditionRule> conditionRules))
            {
                // 이미 적용된 조건 중 가장 큰 우선순위 값입니다.
                int maxPriorityLevel = conditionRules.Max(x => x.PriorityLevel);

                // 기존 규칙: 0번 우선순위는 누적 가능하고, 양수 우선순위는 낮은 숫자가 더 강합니다.
                if (maxPriorityLevel > 0 && maxPriorityLevel < conditionRule.PriorityLevel)
                    return false;
            }
            else
            {
                conditionRules = new List<IConditionRule>();
                ConditionsByPrimaryValue[primaryKey] = conditionRules;
            }

            conditionRules.Add(conditionRule);
            return true;
        }
    }
}
