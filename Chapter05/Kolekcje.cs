using System;
using System.Collections.Generic;
using System.Numerics;

namespace Chapter05
{
    class Kolekcje
    {
        private static IEnumerable<int> Numbers(int start, int count)
        {
            for (var i = 0; i < count; ++i)
            {
                yield return start + i;
            }
        } 
        public static void kolekcje_przyklady()
        {
            foreach (var i in Numbers(1, 5))
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("Fibonacci = {0}",Fibonacci(1));
        }

        public static IEnumerable<BigInteger> Fibonacci(int count)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException("count");
            }
            return FibonacciCore(count);
        }

        private static IEnumerable<BigInteger> FibonacciCore(int count)
        {
            BigInteger v1 = 1;
            BigInteger v2 = 1;
            for (int i = 0; i < count; i++)
            {
                yield return v1;
                var tmp = v2;
                v2 = v1 + v2;
                v1 = tmp;
            }
        }
    }
}
