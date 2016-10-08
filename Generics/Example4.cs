using System;

namespace Generics
{
    //Listing 4-4
    //Ten przykład sluży wyłącznie do celów demonstarcyjnych
    //W rzeczywistym programie lepiej skorzystać z typu Lazy<T>.
    public static class Deferred<T> where T : new()
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new T();
                }
                return _instance;
            }
        }
    }

    class Example4
    {
        public static void UseDeferred()
        {
            var item1 = Deferred<MyType>.Instance;
            var item2 = Deferred<MyType>.Instance;
            Console.WriteLine(ReferenceEquals(item1, item2));

            //Jak to należy robić
            //(To nie ma związku z Deferred<MyType> a zatem pierwsze wywołanie
            //spowoduje wykonanie konstruktora MyType po raz drugi
            var item3 = _lazy.Value;
            var item4 = _lazy.Value;
            Console.WriteLine(ReferenceEquals(item3, item4));

            Console.WriteLine(ReferenceEquals(item1, item3));
        }

        private static Lazy<MyType> _lazy = new Lazy<MyType>(); 
        private class MyType
        {
            public MyType()
            {
                Console.WriteLine("Tworzenie obiektu MyType");
            }
        }
    }
}
