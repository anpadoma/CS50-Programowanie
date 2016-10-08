using System;
using System.Globalization;

namespace DeferredQueries
{
    class Program
    {
        static void Main()
        {
            //Listing 10-14
            var commaCulture =
                from culture in CultureInfo.GetCultures(CultureTypes.AllCultures)
                where culture.NumberFormat.NumberDecimalSeparator == ","
                select culture;

            object[] numbers = {1, 100, 100.3, 100000.4};
            foreach (object number in numbers)
            {
                foreach (CultureInfo culture in commaCulture)
                {
                    Console.WriteLine(string.Format(culture, "{0}: {1:c}", culture.Name, number));
                }
            }
        }
    }
}
