using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelConditionPainter
{
    public abstract class ConditionGroupCalculation
    {
        public readonly string FirstRowPrimaryValue;

        public readonly HashSet<string> OtherPrimaryValues;
        protected ConditionGroupCalculation(string firstRowPrimaryValue)
        {
            FirstRowPrimaryValue = firstRowPrimaryValue;
            OtherPrimaryValues = new HashSet<string>();
        }
        public void AddPrimaryValue(string primaryValue)
        {
            OtherPrimaryValues.Add(primaryValue);
        }
    }
    public class QuantityConditionCalculation : ConditionGroupCalculation
    {
        public int TotalGoodsCount { get; private set; }
        public QuantityConditionCalculation(string firstRowPrimaryValue, int totalGoodsCount) : base(firstRowPrimaryValue)
        {
            TotalGoodsCount = totalGoodsCount;
        }
        public void AddAdditionalData(string primaryValue, int amount)
        {
            base.AddPrimaryValue(primaryValue);
            TotalGoodsCount += amount;
        }
    }
    public class DistinctOrderConditionCalculation : ConditionGroupCalculation
    {
        public DistinctOrderConditionCalculation(string firstRowPrimaryValue) : base(firstRowPrimaryValue)
        {

        }
        public void AddAdditionalData(string primaryValue)
        {
            base.AddPrimaryValue(primaryValue);
        }
    }
}
