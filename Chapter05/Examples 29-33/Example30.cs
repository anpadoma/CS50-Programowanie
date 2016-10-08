using System;
using System.Collections.Generic;

namespace Chapter05
{
    class Example30
    {
        public static IEnumerable<int> ThreeNumbers()
        {
            yield return 1;
            yield return 2;
            yield return 3;
        }

        public static void InvokeThreeNumbers()
        {
            foreach (var i in ThreeNumbers())
            {
                Console.WriteLine(i);
            }
        }
    }
}
