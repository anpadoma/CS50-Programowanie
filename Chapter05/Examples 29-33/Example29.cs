using System;
using System.Collections.Generic;

namespace Chapter05
{
    class Example29
    {
        //Listing 5.29
        public static IEnumerable<int> Numbers(int start, int count)
        {
            for (int i = 0; i < count; ++i)
            {
                yield return start + i;
            }
        }

        public static void InvokeNumbers()
        {
            foreach (int i in Numbers(1, 7))
            {
                Console.WriteLine(i);
            }
        }
    }
}
