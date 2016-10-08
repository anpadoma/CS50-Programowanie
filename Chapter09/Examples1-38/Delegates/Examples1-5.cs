using System;

namespace Delegates
{
    class Examples1_5
    {
        //Listing 9-1
        public static int GetIndexOfFirstNonEmptyBin(int[] bins)
        {
            return Array.FindIndex(bins, IsGreaterThanZero);
        }

        private static bool IsGreaterThanZero(int value)
        {
            return value > 0;
        }

        //Listing 9-2
        public static int FindIndex<T>(
            T[] array,
            Predicate<T> match)
        {
            return Array.FindIndex(array, match);
        }

        public static void ExplicitConstruction()
        {
            var p = new Predicate<int>(IsGreaterThanZero);
        }

        public static void ImplicitConstruction()
        {
            Predicate<int> p = IsGreaterThanZero;
        }
    }
}
