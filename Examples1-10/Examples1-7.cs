using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace QueryExpression
{
    class Examples1_7
    {
        public static void LinqQueryExpression()
        {
            //Listing 10-1
            IEnumerable<CultureInfo> commaCultures =
                from culture in CultureInfo.GetCultures(CultureTypes.AllCultures)
                where culture.NumberFormat.NumberDecimalSeparator == ","
                select culture;

            foreach (CultureInfo culture in commaCultures)
            {
                Console.WriteLine(culture.Name);
            }
        }

        public static void WithoutLinq()
        {
            //Listing 10-2
            CultureInfo[] allCultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
            foreach (CultureInfo culture in allCultures)
            {
                if (culture.NumberFormat.NumberDecimalSeparator == ",")
                {
                    Console.WriteLine(culture.Name);
                }
            }
        }

        public static void ExtraOneProperty()
        {
            //Listing 10-3
            IEnumerable<string> commaCultures =
                from culture in CultureInfo.GetCultures(CultureTypes.AllCultures)
                where culture.NumberFormat.NumberDecimalSeparator == ","
                select culture.Name;
            foreach (string cultureName in commaCultures)
            {
                Console.WriteLine(cultureName);
            }
        }

        public static void ExpandedQuery()
        {
            //Listing 10-4
            IEnumerable<string> commaCultures =
                CultureInfo.GetCultures(CultureTypes.AllCultures)
                    .Where(culture => culture.NumberFormat.NumberDecimalSeparator == ",")
                    .Select(culture => culture.Name);

            foreach (string cultureName in commaCultures)
            {
                Console.WriteLine(cultureName);
            }
        }

        public static void ExpandTrivialSelect()
        {
            //Listing 10-5
            IEnumerable<CultureInfo> commaCultures =
                CultureInfo.GetCultures(CultureTypes.AllCultures)
                    .Where(culture => culture.NumberFormat.NumberDecimalSeparator == ",");

            foreach (CultureInfo culture in commaCultures)
            {
                Console.WriteLine(culture.Name);
            }
        }

        public static void LetClause()
        {
            //Listing 10-6
            IEnumerable<string> commaCultures =
                from culture in CultureInfo.GetCultures(CultureTypes.AllCultures)
                let numFormat = culture.NumberFormat
                where numFormat.NumberDecimalSeparator == ","
                select culture.Name;

            foreach (string cultureName in commaCultures)
            {
                Console.WriteLine(cultureName);
            }
        }

        public static void ExpandedLet()
        {
            //Listing 10-7
            IEnumerable<string> commaCulture =
                CultureInfo.GetCultures(CultureTypes.AllCultures)
                    .Select(culture => new {culture, numFormat = culture.NumberFormat})
                    .Where(vars => vars.numFormat.NumberDecimalSeparator == ",")
                    .Select(vars => vars.culture.Name);

            foreach (string cultureName in commaCulture)
            {
                Console.WriteLine(cultureName);
            }
        }
    }
}
