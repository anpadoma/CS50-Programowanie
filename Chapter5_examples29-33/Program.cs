using System;
using System.Collections.Generic;

namespace Iterators
{
    class Program
    {
        //Listing 5-29
        public static IEnumerable<int> Number(int start, int count)
        {
            for (int i = 0; i < count; ++i)
            {
                yield return start + i;
            }
        } 

        static void Main(string[] args)
        {
            //Example32.UseHandWrittenEnumerable();
            //Example30.InvokeSimpleIterator();
            Example33.IteratorWithException();
        }
    }
}
