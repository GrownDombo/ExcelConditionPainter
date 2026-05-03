using System.ComponentModel;
using System.Drawing;

namespace ExcelConditionPainter
{
    /// <summary>
    /// 사용자가 추가할 수 있는 조건 종류입니다.
    /// </summary>
    public enum ConditionRuleType
    {
        [Description("중복값을 제외한 순차별 - (다수 컬럼 선택시 AND 검색")]
        Order = 0,
        [Description("중복값이 있는 Cell 검색 - (다수 컬럼 선택시 AND 검색")]
        Duplicate = 1,
        [Description("총 구매 수량이 기준 수량보다 많은 소비자 검색 - (다수 컬럼 선택시 AND 검색")]
        Quantity,
        [Description("특정 옵션을 구매한 소비자 검색 - (다수 옵션 선택시 OR 검색")]
        OptionBuyOrder
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
        // 조건 우선순위입니다.
        int PriorityLevel { get; set; }
        // 글자색/배경색 중 적용할 대상입니다.
        PaintTarget PaintTarget { get; set; }
        // 조건에 적용할 색상입니다.
        Color SelectedColor { get; set; }
    }

    /// <summary>
    /// WinForms 조건 컨트롤이 제공해야 하는 설정 수집 기능입니다.
    /// </summary>
    public interface IConditionControl : IConditionSettings
    {
        /// <summary>
        /// 조건에서 선택 가능한 항목을 설정합니다.
        /// </summary>
        void SetSelectableItems(string[] selectableItems, int rowCount);

        /// <summary>
        /// 현재 UI 상태로 계산 Rule을 생성합니다.
        /// </summary>
        IConditionRule CreateRule();
    }

    /// <summary>
    /// 실제 조건 계산을 수행하는 전략 인터페이스입니다.
    /// </summary>
    public interface IConditionRule : IConditionSettings
    {
        // 조건이 실제로 적용된 순번입니다.
        int AppliedConditionIndex { get; set; }

        /// <summary>
        /// 조건을 평가하고 결과 컨텍스트에 적용 대상을 등록합니다.
        /// </summary>
        bool Evaluate(ConditionEvaluationContext conditionContext);

        /// <summary>
        /// GridPainter가 사용할 색칠 지시를 생성합니다.
        /// </summary>
        ConditionPaintInstruction CreatePaintInstruction();
    }
}
