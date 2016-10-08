using System;
using System.IO;

namespace Chapter07
{
    class SampleUsing
    {
        public static void Sample()
        {
            using (Stream source = File.OpenRead(@"C:\temp\File.txt"))
            using (Stream copy = File.Create(@"C:\temp\Copy.txt"))
            {
               source.CopyTo(copy);
            }

            foreach (string file in Directory.EnumerateFiles(@"c:\temp"))
            {
                Console.WriteLine(file);
            }
        }
    }
}
