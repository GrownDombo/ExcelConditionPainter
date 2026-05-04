using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;

namespace ExcelConditionPainter
{
    /// <summary>
    /// 조건에 매칭된 Rule과, 필요 시 실제로 칠할 컬럼 목록을 함께 보관합니다.
    /// </summary>
    public sealed class ConditionMatch
    {
        private readonly bool hasTargetColumnOverride;
        private readonly ReadOnlyCollection<string> targetColumnNames;

        public readonly IConditionRule ConditionRule;

        public ConditionMatch(IConditionRule conditionRule, IEnumerable<string> targetColumnNames)
        {
            ConditionRule = conditionRule;
            hasTargetColumnOverride = targetColumnNames != null;

            string[] columnNames = targetColumnNames == null
                ? new string[0]
                : targetColumnNames.Where(name => string.IsNullOrEmpty(name) == false).ToArray();
            this.targetColumnNames = Array.AsReadOnly(columnNames);
        }

        public ConditionPaintInstruction CreatePaintInstruction()
        {
            if (hasTargetColumnOverride == false)
                return ConditionRule.CreatePaintInstruction();

            return new ConditionPaintInstruction(
                ConditionRule.PriorityLevel,
                ConditionRule.AppliedConditionIndex,
                ConditionRule.PaintTarget,
                ConditionRule.SelectedColor,
                targetColumnNames);
        }
    }

    /// <summary>
    /// 조건 평가 중 공유되는 입력 데이터, 계산 캐시, 적용 결과를 담는 컨텍스트입니다.
    /// </summary>
    public class ConditionEvaluationContext
    {
        public readonly string PrimaryColumnName;
        public readonly string BuyCountColumnName;
        public readonly string OptionColumnName;
        public readonly ReadOnlyDictionary<string, int> GoodsQuantitiesByOption;
        public readonly DataTable ConditionTable;

        public readonly Dictionary<string, List<DistinctOrderConditionCalculation>> DistinctOrderCalculationsBySelection;
        public readonly Dictionary<string, List<QuantityConditionCalculation>> QuantityCalculationsBySelection;
        public readonly Dictionary<string, List<ConditionMatch>> ConditionsByPrimaryValue;

        public ConditionEvaluationContext(string primaryColumnName, string buyCountColumnName, string optionColumnName, Dictionary<string, int> goodsQuantitiesByOption, DataTable conditionTable)
        {
            PrimaryColumnName = primaryColumnName;
            BuyCountColumnName = buyCountColumnName;
            OptionColumnName = optionColumnName;
            GoodsQuantitiesByOption = new ReadOnlyDictionary<string, int>(goodsQuantitiesByOption);
            ConditionTable = conditionTable;

            DistinctOrderCalculationsBySelection = new Dictionary<string, List<DistinctOrderConditionCalculation>>();
            QuantityCalculationsBySelection = new Dictionary<string, List<QuantityConditionCalculation>>();
            ConditionsByPrimaryValue = new Dictionary<string, List<ConditionMatch>>();
        }

        public bool TryAddCondition(string primaryKey, IConditionRule conditionRule)
        {
            return TryAddCondition(primaryKey, conditionRule, null);
        }

        public bool TryAddCondition(string primaryKey, IConditionRule conditionRule, IEnumerable<string> targetColumnNames)
        {
            if (ConditionsByPrimaryValue.TryGetValue(primaryKey, out List<ConditionMatch> conditionMatches))
            {
                int maxPriorityLevel = conditionMatches.Max(x => x.ConditionRule.PriorityLevel);

                if (maxPriorityLevel > 0 && maxPriorityLevel < conditionRule.PriorityLevel)
                    return false;
            }
            else
            {
                conditionMatches = new List<ConditionMatch>();
                ConditionsByPrimaryValue[primaryKey] = conditionMatches;
            }

            conditionMatches.Add(new ConditionMatch(conditionRule, targetColumnNames));
            return true;
        }
    }
}
