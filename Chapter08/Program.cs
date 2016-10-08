using System;
using System.IO;

namespace Chapter08
{
    class Program
    {
        static void Main()
        {
            try
            {
                PrintFirstLineLenght(@"c:\temp\File1.txt");
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("NullReferenceException");
            }
        }

        static void PrintFirstLineLenght(string fineName)
        {
            try
                {
                    using (var r = new StreamReader(fineName))
                    {
                        try
                        {
                            Console.WriteLine(r.ReadLine().Length);
                        }
                        catch (IOException x)
                        {
                            Console.WriteLine("Błąd podczas odczytu pliku: '{0}", x.Message);
               
                        }
                    }
                }
            catch(FileNotFoundException x)
            {
                Console.WriteLine("Nie udało się odnaleźc pliku '{0}'", x.FileName);
            }
        }
    }
}
