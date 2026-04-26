using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ExcelConditionPainter
{
    public enum eConditions
    {
        [Description("중복값을 제외한 선착순 - (다수 컬럼 선택시 ▶AND 검색)")]
        Order = 0,
        [Description("중복값이 있는 Cell 검색 - (다수 컬럼 선택시 ▶AND 검색)")]
        Duplicate = 1,
        [Description("총 구매 수량이 기준 수량보다 많은 소비자 검색 - (다수 컬럼 선택시 ▶AND 검색)")]
        Quantity,
        [Description("특정 옵션을 구매한 소비자 검색 - (다수 옵션 선택시 ▶OR 검색)")]
        OptionBuyOrder
    }
    public enum eConditionType
    {
        Font = 0,
        Fill = 1,
    }
    public interface ICondtionsCommon
    {
        int Level { get; set; }
        eConditionType ConditionType { get; set; }
        Color SelectColor { get; set; }
    }
    public interface ICondtions : ICondtionsCommon
    {
        int nAppliedConditionIndex { get; set; } // 유효하게 적용된 조건의 순서 -> 한번셋팅되면 바꿀 있으면 안됨 
        void SetOptionRange(string[] arrCols, int nRowCnt);
        bool CondtionResult(cConditionCalculator userSetDataCol);
        void PaintRows(DataGridViewRow row);
        
    }
}
