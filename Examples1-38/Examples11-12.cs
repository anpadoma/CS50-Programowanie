using System;
using System.CodeDom;
using System.IO.Pipes;

namespace Delegates
{
    class Examples11_12
    {
        //Listing 9-11
        public static void CallMeRightBack(Predicate<int> userCallback)
        {
            bool result = userCallback(42);
            Console.WriteLine(result);
        }

        //Listing 9-12
        public static void TestForMajority(Predicate<int> userCallbacks)
        {
            int trueCount = 0;
            int falseCount = 0;
            foreach (Predicate<int> p in userCallbacks.GetInvocationList())
            {
                bool result = p(42);
                if (result)
                {
                    trueCount += 1;
                }
                else
                {
                    falseCount += 1;
                }
            }
            if (trueCount > falseCount)
            {
                Console.WriteLine("Większość predykatów zwróciła wartość: prawda.");
            }
            else if (falseCount > trueCount)
            {
                Console.WriteLine("Większość predykatów zwróciła wartość: false.");
            }
            else
            {
                Console.WriteLine("Jest remis!");
            }
        }

        public static bool DirectCall1(int s)
        {
            return s < 10;
        }

        public static bool DirectCall2(int s)
        {
            return s > 20;
        }

        public static bool DirectCall3(int s)
        {
            return s > 0;
        }

        public static void TestCall()
        {
            Predicate<int> ps = DirectCall1;
            ps += DirectCall2;
            ps += DirectCall3;
            TestForMajority(ps);
        }
    }
}
