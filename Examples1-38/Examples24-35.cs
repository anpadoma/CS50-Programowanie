using System;
using System.Diagnostics;

namespace Delegates
{
    class Examples24_35
    {
        //Listing 9-24
        public static int GetIndexOdFirstNonEmptyBin(int[] bins)
        {
            return Array.FindIndex(
                bins,
                value => value > 0
                );
        }

        public static void VariousFormsOfLambda()
        {
            //Listing 9-25
            Predicate<int> p1 = value => value > 0;
            Predicate<int> p2 = (value) => value > 0;
            Predicate<int> p3 = (int value) => value > 0;
            Predicate<int> p4 = value => { return value > 0; };
            Predicate<int> p5 = (value) => { return value > 0; };
            Predicate<int> p6 = (int value) => { return value > 0; };

            //Listing 9-26
            Func<bool> isAfternoon = () => DateTime.Now.Hour >= 12;
        }

        public static void AnonymousMethod()
        {
            //Listing 9-27
            EventHandler clickHandler = delegate { Debug.WriteLine("Kliknięto przycisk!"); };
        }

        public static Predicate<int> IsGreaterThan(int threshold)
        {
            //Listing 9-28
            return value => value > threshold;
        }

        public static void UseDelegateThatCaptures()
        {
            //Listing 9-29
            Predicate<int> greaterThan = IsGreaterThan(10);
            bool result = greaterThan(200);
            
        }

        //Listing 9-31
        static void Calculate(int[] nums)
        {
            int zeroCount = 0;
            int[] nonZeroNums = Array.FindAll(
                nums,
                v =>
                {
                    if (v == 0)
                    {
                        zeroCount += 1;
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                });
            Console.WriteLine("Liczba elementów o wartości 0: {0}, pierwszy element różny od 0: {1}", zeroCount, nonZeroNums[0]);
        }

        public static void CalculateTest()
        {
            int[] naumsInts = {10, 0, 23, 0, 89, 23, 0};
            Calculate(naumsInts);
        }

        //Listing 9-33
        public static void Caught()
        {
            var greaterThanN = new Predicate<int>[11];
            for (int i = 0; i < greaterThanN.Length; ++i)
            {
                //Nieprawidłowe użycie zmiennej i
                greaterThanN[i] = value => value > i;
            }
            Console.WriteLine(greaterThanN[5](20));
            Console.WriteLine(greaterThanN[5](6));
        }

        public static void AvoidingCaptureProblem()
        {
            var greaterThanN = new Predicate<int>[10];
            //Listing 9-34
            for (int i = 0; i < greaterThanN.Length; ++i)
            {
                int current = i;
                greaterThanN[i] = value => value > current;
            }
            Console.WriteLine(greaterThanN[5](20));
            Console.WriteLine(greaterThanN[5](6));
        }

        public static void MultipleCapture()
        {
            var greaterThanN = new Predicate<int>[10];
            //Listing 9-35
            int offset = 10;
            for (int i = 0; i < greaterThanN.Length; ++i)
            {
                int current = i;
                greaterThanN[i] = value => value > (current + offset);
            }
            Console.WriteLine(greaterThanN[5](2));
        }
    }
}
