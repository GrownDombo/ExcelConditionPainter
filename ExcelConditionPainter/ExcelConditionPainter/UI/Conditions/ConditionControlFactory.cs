namespace ExcelConditionPainter
{
    /// <summary>
    /// 조건 타입에 맞는 조건 UI 컨트롤을 생성합니다.
    /// </summary>
    public static class ConditionControlFactory
    {
        /// <summary>
        /// 선택된 조건 타입에 맞는 컨트롤을 만들어 반환합니다.
        /// </summary>
        public static IConditionControl Create(ConditionRuleType conditionRuleType, string[] columnNames, string[] optionNames, int rowCount)
        {
            switch (conditionRuleType)
            {
                case ConditionRuleType.Order:
                    return new DistinctOrderConditionControl(columnNames, rowCount);
                case ConditionRuleType.Duplicate:
                    return new DuplicateConditionControl(columnNames, rowCount);
                case ConditionRuleType.Quantity:
                    return new QuantityConditionControl(columnNames, rowCount);
                case ConditionRuleType.OptionBuyOrder:
                    return new OptionPurchaseOrderConditionControl(optionNames, rowCount);
                default:
                    return null;
            }
        }
    }
}
