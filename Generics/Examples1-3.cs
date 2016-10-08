using System;
using System.Collections.Generic;

namespace Generics
{
    public class NamedContainer<T>
    {
        public NamedContainer(T item, string name)
        {
            Item = item;
            Name = name;
        }

        public T Item { get; private set; }
        public string Name { get; private set; }
    }

    class Example1_3
    {
        public static void UseGenericClass()
        {
            //Listing 4-2
            var a = new NamedContainer<int>(42, "Oto odpowiedż");
            var b = new NamedContainer<int>(99, "Liczba czerwonych");
            var c = new NamedContainer<string>("Programowanie w c#", "Tytuł książki");

            ShowContainer(a);
            ShowContainer(b);
            ShowContainer(c);

            //Listing 4-3
            // a i b pochodzą z listingu 4-2
            var namedInts = new List<NamedContainer<int>> {a, b};
            var namedNamedItem = new NamedContainer<NamedContainer<int>>(a, "Wrapped");

            ShowContainer(namedInts[0]);
            ShowContainer(namedInts[1]);
            ShowContainer(namedNamedItem);
            ShowContainer(namedNamedItem.Item);

        }

        private static void ShowContainer<T>(NamedContainer<T> container)
        {
            Console.WriteLine("{0}: {1} ({2})", container.Name, container.Item, typeof(T).Name);
        }
    }
}
