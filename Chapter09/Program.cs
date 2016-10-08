using System;

namespace Chapter09
{
    class Program
    {
        static void Main()
        {
            Predicate<int> p1 = Test.IsGreaterThanZero;
            Predicate<int> p2 = Test.IsLessThanZero;

            var zeroThreshold = new ThresholdComparer {Threshold = 0};
            var tenThreshold = new ThresholdComparer {Threshold = 10};
            var hundredThreshold = new ThresholdComparer {Threshold = 100};

            //Predicate<int> greaterThanzero = zeroThreshold.IsGreaterThan;
            var greaterThanzero =
                (Predicate<int>) Delegate.CreateDelegate(typeof (Predicate<int>), zeroThreshold, "IsGreaterThan");
            Predicate<int> greaterThanTen = tenThreshold.IsGreaterThan;
            Predicate<int> greaterThanOneHundred = hundredThreshold.IsGreaterThan;

            Predicate<object> po = IsLongstring;
            Predicate<string> ps = po;
            Console.WriteLine(ps("Zbyt krótki."));

            //Spowoduje błąd kompilacji
            Predicate<string> pred = IsLongstring;
            //Func<string, bool> f = pred;
            
            //można tak:
            var pred2 = new Func<string, bool>(pred.Invoke);
            //lub tak:
            var pred3 =
                (Func<string, bool>) Delegate.CreateDelegate(typeof (Func<string, bool>), pred.Target, pred.Method);

            //Bezargumentowe wyrażenie lambda
            Func<bool> isAfternoon = () => DateTime.Now.Hour >= 12;
            Console.WriteLine(isAfternoon.Invoke());
        }

        public static bool IsLongstring(object o)
        {
            var s = o as string;
            return s != null && s.Length > 20;
        }

        public static int GetIndexOfFirstNonEmptyBin(int[] bins)
        {
            return Array.FindIndex(bins, value => value > 0);
        }
    }

    internal class Test
    {
        public static bool IsGreaterThanZero(int value)
        {
            return value > 0;
        }

        public static bool IsLessThanZero(int value)
        {
            return value < 0;
        }
    }

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
}
