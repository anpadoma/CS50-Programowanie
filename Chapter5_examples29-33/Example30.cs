using System;
using System.Collections.Generic;

namespace Iterators
{
    class Example30
    {
        //Listing 5-30
        public static IEnumerable<int> ThreeNumbers()
        {
            //yield return 1;
            yield return 2;
            yield return 3;
        }

        public static void InvokeSimpleIterator()
        {
            foreach (int i in ThreeNumbers())
            {
                Console.WriteLine(i);
            }
        }
    }
}
