using System;

namespace Delegates
{
    class Example23
    {
        //Listing 23
        public static int GetIndexOfFirstNonEmptyBin(int[] bins)
        {
            return Array.FindIndex(
                bins,
                delegate(int value) { return value > 0; }
                );
        }
    }
}
