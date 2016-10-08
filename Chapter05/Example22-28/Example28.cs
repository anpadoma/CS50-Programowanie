using System;
using System.Collections.Generic;

namespace Chapter05
{
    class Example28
    {
        public static void FailToAddItemToArray()
        {
            try
            {
                //Listing 5-28
                IList<int> array = new[] {1, 2, 3};
                array.Add(4); //to wywołanie spowoduje zgłoszenie wyjątku!
            }
            catch (Exception x)
            {
                Console.WriteLine(x);
            }
        }
    }
}
