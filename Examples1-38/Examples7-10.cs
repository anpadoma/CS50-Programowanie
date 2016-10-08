using System;
using System.Runtime.InteropServices;

namespace Delegates
{
    //Listing 9-7
    public class ThresholdComparer
    {
        public int Threshold { get; set; }

        public bool IsGreaterThan(int value)
        {
            return value > Threshold;
        }

        public Predicate<int> GetIsGreaterThanPredicate()
        {
            return IsGreaterThan;
        } 
    }
    
    class Examples7_10
    {
        public static void CreateDelegate()
        {
            //Listing 9-8
            var zeroThreshold = new ThresholdComparer {Threshold = 0};
            var tenThreshold = new ThresholdComparer {Threshold = 10};
            var hundredThreshold = new ThresholdComparer {Threshold = 100};

            Predicate<int> greaterThanzero = zeroThreshold.IsGreaterThan;
            Predicate<int> greaterThanTen = tenThreshold.IsGreaterThan;
            Predicate<int> greaterThanHundred = hundredThreshold.IsGreaterThan;

            //Listing 9-10
            Predicate<int> megaPredicate1 = greaterThanTen + greaterThanzero + greaterThanHundred;

            Predicate<int> megaPredicate2 = greaterThanzero;
            megaPredicate2 += greaterThanTen;
            megaPredicate2 += greaterThanHundred;
        }

        public static void DynamicCreate()
        {
            var zeroThreshold = new ThresholdComparer {Threshold = 0};

            //Listing 9-9
            var greaterThanZero =
                (Predicate<int>) Delegate.CreateDelegate(typeof (Predicate<int>), zeroThreshold, "IsGreaterThan");
        }
    }
}
