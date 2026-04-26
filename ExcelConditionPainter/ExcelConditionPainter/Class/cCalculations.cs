using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelConditionPainter
{
    public abstract class cCalculations
    {
        public readonly string FirstRowPrimaryValue;

        public readonly HashSet<string> hsOtherPrimaryValue;
        protected cCalculations(string firstRowPrimaryValue)
        {
            FirstRowPrimaryValue = firstRowPrimaryValue;
            hsOtherPrimaryValue = new HashSet<string>();
        }
        public void AddPrimaryValue(string PrimaryValue)
        {
            hsOtherPrimaryValue.Add(PrimaryValue);
        }
    }
    public class cQuantityOptionCal : cCalculations
    {
        public int TotalGoodsCount { get; private set; }
        public cQuantityOptionCal(string firstRowPrimaryValue, int totalGoodsCount) : base(firstRowPrimaryValue)
        {
            TotalGoodsCount = totalGoodsCount;
        }
        public void AddEdtionData(string PrimaryValue, int amount)
        {
            base.AddPrimaryValue(PrimaryValue);
            TotalGoodsCount += amount;
        }
    }
    public class cOrderExceptDuplOptionCal : cCalculations
    {
        public cOrderExceptDuplOptionCal(string firstRowPrimaryValue) : base(firstRowPrimaryValue)
        {

        }
        public void AddEdtionData(string PrimaryValue)
        {
            base.AddPrimaryValue(PrimaryValue);
        }
    }
}
