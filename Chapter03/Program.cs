using System;

namespace Chapter03
{
    internal class Program
    {
        private static void Main()
        {
            //var c1 = new Counter();
            //var c2 = c1;
            //c1++;
            
            //Console.WriteLine("c1: " + c1.Count);
            //c1++;
            //Console.WriteLine("c1: " + c1.Count);
            //c1 = c1.GetNextValue();
            //Console.WriteLine("c1: " +c1.Count);

            //c2++;
            //Console.WriteLine("c2: " + c2.Count);

            //c1++;
            //Console.WriteLine("c1: " + c1.Count);
            Console.WriteLine("Początek metody Main");
            InitializationTestClass.Foo();
            Console.WriteLine("Tworzenie obiektu nr 1");
            InitializationTestClass i = new InitializationTestClass();
            Console.WriteLine("Tworzenie obiektu nr 2");
            i = new InitializationTestClass();
        }
    }
}
