using System;
using System.Collections.Generic;

namespace BasicRx
{
    //Listing 11-7
    public class KeyWatcher : IObservable<char>
    {
        private readonly List<Subscription> _subscriptions = new List<Subscription>();

        public IDisposable Subscribe(IObserver<char> observer)
        {
            var sub = new Subscription(this, observer);
            _subscriptions.Add(sub);
            return sub;
        }

        public void Run()
        {
            while (true)
            {
                char c = Console.ReadKey(true).KeyChar;
                //Pętla operuje po tablicy reprezentującej listę subskrybentów,
                //aby zapewnić obsługę anulowania subskrypcji w trakcie rozsyłania
                //powiadomień.
                foreach (Subscription sub in _subscriptions.ToArray())
                {
                    sub.Observer.OnNext(c);
                }
            }
        }

        private void RemoveSubscription(Subscription sub)
        {
            _subscriptions.Remove(sub);
        }

        private class Subscription : IDisposable
        {
            private KeyWatcher _parent;

            public Subscription(KeyWatcher parent, IObserver<char> observer)
            {
                _parent = parent;
                Observer = observer;
            }

            public IObserver<char> Observer { get; set; }

            public void Dispose()
            {
                if (_parent != null)
                {
                    _parent.RemoveSubscription(this);
                    _parent = null;
                }
            }
        }
    }

    class Examples7_8
    {
        public static void ObserveKeyWatcherIndefinitely()
        {
            //Listing 11-8
            var sub = new MySubscriber<char>();
            var source = new KeyWatcher();
            source.Subscribe(sub);
            source.Run();
        }
    }
}
