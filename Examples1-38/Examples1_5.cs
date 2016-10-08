using System;

namespace Delegates
{
    public class Examples1_5
    {
        //Listing 9-1
        public static int GetIndexOfFirstNonEmpty(int[] bins)
        {
            return Array.FindIndex(bins, IsGreaterThanzero);
        }

        private static bool IsGreaterThanzero(int value1)
        {
            return value1 > 0;
        }


        //Listing 9-2
        //(w tekście książki ten przykład ma jedynie pokazać jak wygląda sygnatura
        //metody Array.FindIndex. Dlatego też tutaj jedynie wywołujemy tę metodę.)
        public static int FindIndex<T>(
            T[] array,
            Predicate<T> match
            )
        {
            return Array.FindIndex(array, match);
        }

        //Kod umieszczony w komentarzu gdyż pokazuje jak wygląda definiacja typu w CLR
        //Listing 9-3
        //public delegate bool Predicate<in T>(T obj)
        //<in T> mówi o kontrawariantnym argumencie typu T
        //zgodność z Predicate<T> - wymagana niejawna konwersja referencji

        public static void ExplicitConstruction()
        {
            //listing 9-4
            var p = new Predicate<int>(IsGreaterThanzero);
        }

        public static void ImplicitConstruction()
        {
            //Listing 9-5
            Predicate<int> p = IsGreaterThanzero;
        }


    }
}
