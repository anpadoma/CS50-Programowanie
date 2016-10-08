using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Iterators
{
    //Listing 5-32
    public class FibonacciEnumerable : IEnumerable<BigInteger>, IEnumerator<BigInteger>
    {
        private BigInteger v1;
        private BigInteger v2;
        private bool first = true;

        public BigInteger Current
        {
            get { return v1; }
        }

        public void Dispose()
        {
            
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public bool MoveNext()
        {
            if (first)
            {
                v1 = 1;
                v2 = 1;
                first = false;
            }
            else
            {
                var tmp = v2;
                v2 = v1 + v2;
                v1 = tmp;
            }
            return true;
        }

        public void Reset()
        {
            first = true;
        }

        public IEnumerator<BigInteger> GetEnumerator()
        {
            return new FibonacciEnumerable();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    class Example32
    {
        public static void UseHandWrittenEnumerable()
        {
            int count = 0;
            foreach (BigInteger n in new FibonacciEnumerable())
            {
                Console.WriteLine(n);
                if (++count == 100) { break;}
            }
        }
    }
}
