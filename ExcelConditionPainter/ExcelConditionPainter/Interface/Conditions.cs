using System.ComponentModel;
using System.Drawing;

namespace ExcelConditionPainter
{
    /// <summary>
    /// 사용자가 추가할 수 있는 조건 종류입니다.
    /// </summary>
    public enum ConditionRuleType
    {
        [Description("중복 제외 순차 검색")]
        Order = 0,
        [Description("중복값 Cell 검색")]
        Duplicate = 1,
        [Description("총 구매 수량 검색")]
        Quantity,
        [Description("특정 옵션 구매 검색")]
        OptionBuyOrder
    }

    /// <summary>
    /// 여러 선택 항목을 평가할 때 사용할 매칭 방식입니다.
    /// </summary>
    public enum MultiSelectMatchMode
    {
        And = 0,
        Or = 1
    }

    /// <summary>
    /// 조건 색상을 글자색 또는 배경색 중 어디에 적용할지 나타냅니다.
    /// </summary>
    public enum PaintTarget
    {
        Font = 0,
        Fill = 1,
    }

    /// <summary>
    /// 조건 UI와 계산 Rule이 공유하는 기본 색칠 설정입니다.
    /// </summary>
    public interface IConditionSettings
    {
        int PriorityLevel { get; set; }
        PaintTarget PaintTarget { get; set; }
        MultiSelectMatchMode MatchMode { get; set; }
        Color SelectedColor { get; set; }
    }

    /// <summary>
    /// WinForms 조건 컨트롤이 제공해야 하는 설정 수집 기능입니다.
    /// </summary>
    public interface IConditionControl : IConditionSettings
    {
        void SetSelectableItems(string[] selectableItems, int rowCount);
        IConditionRule CreateRule();
    }

    /// <summary>
    /// 실제 조건 계산을 수행하는 전략 인터페이스입니다.
    /// </summary>
    public interface IConditionRule : IConditionSettings
    {
        int AppliedConditionIndex { get; set; }
        bool Evaluate(ConditionEvaluationContext conditionContext);
        ConditionPaintInstruction CreatePaintInstruction();
    }
}
