using System;

namespace Chapter07
{
    public struct DisposableValue :IDisposable
    {
        private bool _disposedYet;

        public void Dispose()
        {
            if (!_disposedYet)
            {
                Console.WriteLine("zwalniamy po raz pierwszy.");
                _disposedYet = true;
            }
            else
            {
                Console.WriteLine("Obiekt już został zwolniony.");
            }
        }
    }

    public class DisposeValue
    {
        static void CallDispose(IDisposable o)
        {
            o.Dispose();
        }

        public static void Sample()
        {
            var dv = new DisposableValue();
            Console.WriteLine("Przekazujemy zmienną wartościową:");
            CallDispose(dv);
            CallDispose(dv);
            CallDispose(dv);

            IDisposable id = dv;
            Console.WriteLine("Przekazujemy zmienną typu interfejsu:");
            CallDispose(id);
            CallDispose(id);
            CallDispose(id);

            Console.WriteLine("wywołujemy metodę Dispose bezpośrednio na zmiennej typu wartościowego:");
            dv.Dispose();
            dv.Dispose();
            dv.Dispose();
            CallDispose(dv);
        }
    }
}
