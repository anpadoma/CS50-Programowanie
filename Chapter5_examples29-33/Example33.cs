using System;
using System.Collections.Generic;
using System.Numerics;

namespace Iterators
{
    class Example33
    {
        //Listing 5-33
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
            for (int i = 0; i < count; ++i)
            {
                yield return v1;
                var tmp = v2;
                v1 = tmp;
            }
        }

        public static void IteratorWithException()
        {
            IEnumerable<BigInteger> sequence = null;
            try
            {
                sequence = Fibonacci(-1);
            }
            catch (Exception x)
            {
                Console.WriteLine(x);
            }
            if (sequence != null)
            {
                foreach (BigInteger n in sequence)
                {
                    Console.WriteLine(n);
                }
            }
        }
    }
}
