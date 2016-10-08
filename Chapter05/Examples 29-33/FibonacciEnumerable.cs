using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Chapter05
{
    class FibonacciEnumerable : IEnumerable<BigInteger>, IEnumerator<BigInteger>
    {
        private BigInteger _v1;
        private BigInteger _v2;
        private bool _first = true;

        public BigInteger Current
        {
            get { return _v1; }
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
            if (_first)
            {
                _v1 = 1;
                _v2 = 1;
                _first = false;
            }
            else
            {
                var tmp = _v2;
                _v2 = _v1 + _v2;
                _v1 = tmp;
            }
            return true;
        }

        public void Reset()
        {
            _first = true;
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
}
