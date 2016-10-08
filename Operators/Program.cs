using System;
using System.Collections.Generic;

namespace Operators
{
    class Program
    {
        static void Main()
        {
            //Examples18_19.IndexedWhere();
            //Examples18_19.UseOfType();
            //Examples20_25.IndexedSelect();
            //Examples20_25.IndexedSelectAfterWhere();
            //Examples20_25.IndexedSelectBeforeWhere();
            //Examples20_25.MappingItems();
            //Examples26_30.SelectManyQueryExpression();
            //Examples26_30.SelectManyDirect();
            //Examples26_30.FlattenArray();
            //Examples26_30.FlattenArrayDirect();
            //Examples31_34.OrderByQueryExpression();
            //Examples31_34.MultipleOrderingQueryEspression();
            //Examples31_34.MultipleOrderingdirect();
            //Examples35_38.SingleOperator();
            //Examples35_38.SingleWithPredicate();
            //Examples35_38.SelectFirstFromOrderedCollection();
            Examples35_38.UsingElementAtTheSlowWay();
        }
    }

    //Listing 10-19
    public static class ShowExtension
    {
        public static void Show(this IEnumerable<Course> courses)
        {
            foreach (Course c in courses)
            {
                Console.WriteLine("{0}{1}: {2}", c.Category, c.Number, c.Title);
            }
        }

        public static void Show<T>(this IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
