using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ExcelConditionPainter
{
    /// <summary>
    /// 조건 전략들을 실행하고 그리드/Export 계층에서 사용할 평가 결과를 만듭니다.
    /// </summary>
    public class ConditionEvaluationService
    {
        /// <summary>
        /// 조건 목록을 우선순위별로 평가하고 적용 순번을 부여합니다.
        /// </summary>
        public ConditionEvaluationContext Evaluate(string primaryColumnName, string buyCountColumnName, string optionColumnName, Dictionary<string, int> goodsQuantitiesByOption, DataTable conditionTable, IEnumerable<IConditionRule> conditionRules)
        {
            // 조건 평가 중 공유할 입력 데이터와 결과 저장소입니다.
            ConditionEvaluationContext conditionContext = new ConditionEvaluationContext(primaryColumnName, buyCountColumnName, optionColumnName, goodsQuantitiesByOption, conditionTable);

            // 실제로 적용된 조건에 붙일 순번입니다.
            int appliedConditionIndex = 0;
            // 같은 우선순위의 조건들을 묶은 평가 그룹입니다.
            ILookup<int, IConditionRule> lookups = conditionRules.ToLookup(c => c.PriorityLevel);
            foreach (IGrouping<int, IConditionRule> group in lookups)
            {
                foreach (IConditionRule conditionRule in group)
                {
                    if (conditionRule.Evaluate(conditionContext))
                        conditionRule.AppliedConditionIndex = ++appliedConditionIndex;
                }
            }

            return conditionContext;
        }
    }
}
