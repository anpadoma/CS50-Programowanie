using System;

namespace Chapter03
{
    public class InitializationTestClass
    {
        public InitializationTestClass()
        {
            Console.WriteLine("Konstruktor");
        }

        static InitializationTestClass()
        {
            Console.WriteLine("Konstruktor statyczny");
        }

        public static int s1 = GetValue("Pole statyczne 1");
        public int ns1 = GetValue("Pole 1");
        public static int s2 = GetValue("Pole statyczne 2");
        public int ns2 = GetValue("Pole 2");

        private static int GetValue(string message)
        {
            Console.WriteLine(message);
            return 1;
        }

        public static void Foo()
        {
            Console.WriteLine("Metoda statyczna");
        }
    }
}
