using System.Collections.Generic;

namespace ExcelConditionPainter
{
    /// <summary>
    /// 같은 그룹으로 묶인 행들의 대표 기본키와 추가 기본키를 보관합니다.
    /// </summary>
    public abstract class ConditionGroupCalculation
    {
        // 그룹에서 처음 발견된 행의 기본키입니다.
        public readonly string FirstRowPrimaryValue;
        // 같은 그룹에 추가로 포함된 행들의 기본키입니다.
        public readonly HashSet<string> OtherPrimaryValues;

        /// <summary>
        /// 그룹 대표 기본키를 기준으로 계산 객체를 만듭니다.
        /// </summary>
        protected ConditionGroupCalculation(string firstRowPrimaryValue)
        {
            FirstRowPrimaryValue = firstRowPrimaryValue;
            OtherPrimaryValues = new HashSet<string>();
        }

        /// <summary>
        /// 같은 그룹에 속한 추가 기본키를 저장합니다.
        /// </summary>
        public void AddPrimaryValue(string primaryValue)
        {
            OtherPrimaryValues.Add(primaryValue);
        }
    }

    /// <summary>
    /// 그룹별 총 상품 수량을 누적하는 계산 결과입니다.
    /// </summary>
    public class QuantityConditionCalculation : ConditionGroupCalculation
    {
        // 그룹에 포함된 전체 상품 수량입니다.
        public int TotalGoodsCount { get; private set; }

        /// <summary>
        /// 첫 행 기본키와 초기 상품 수량으로 수량 계산을 시작합니다.
        /// </summary>
        public QuantityConditionCalculation(string firstRowPrimaryValue, int totalGoodsCount) : base(firstRowPrimaryValue)
        {
            TotalGoodsCount = totalGoodsCount;
        }

        /// <summary>
        /// 같은 그룹의 기본키와 상품 수량을 추가합니다.
        /// </summary>
        public void AddAdditionalData(string primaryValue, int amount)
        {
            AddPrimaryValue(primaryValue);
            TotalGoodsCount += amount;
        }
    }

    /// <summary>
    /// 중복을 제외한 주문 순서 계산 결과입니다.
    /// </summary>
    public class DistinctOrderConditionCalculation : ConditionGroupCalculation
    {
        /// <summary>
        /// 첫 행 기본키로 주문 순서 계산을 시작합니다.
        /// </summary>
        public DistinctOrderConditionCalculation(string firstRowPrimaryValue) : base(firstRowPrimaryValue)
        {
        }

        /// <summary>
        /// 같은 그룹에 속한 기본키를 추가합니다.
        /// </summary>
        public void AddAdditionalData(string primaryValue)
        {
            AddPrimaryValue(primaryValue);
        }
    }
}
