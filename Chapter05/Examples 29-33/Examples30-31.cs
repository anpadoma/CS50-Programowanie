using System;
using System.Collections.Generic;
using System.Numerics;

namespace Chapter05
{
    class Examples30_31
    {
        //Listing 5-30
        public static IEnumerable<int> ThreeNumbers()
        {
            yield return 1;
            yield return 2;
            yield return 3;
        }

        public static void InvokeSimpleIterator()
        {
            foreach (var i in ThreeNumbers())
            {
                Console.WriteLine(i);
            }
        }

        //Listing 5-31
        public static IEnumerable<BigInteger> Fibonacci()
        {
            BigInteger v1 = 1;
            BigInteger v2 = 1;

            while (true)
            {
                yield return v1;
                var temp = v2;
                v2 = v1 + v2;
                v1 = temp;
            }
        }

        public static void InvokeEndlessIterator()
        {
            //ten kod mógłby działać dowolnie długo, ale zatrzymamy go
            //po wyliczeniu 100 elementów
            int count = 0;
            foreach (BigInteger n in Fibonacci())
            {
                Console.WriteLine(n);
                if (++count == 100) { break;}
            }
        }

    }
}
