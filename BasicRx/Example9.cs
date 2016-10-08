using System;
using System.IO;
using System.Reactive.Linq;

namespace BasicRx
{
    class Example9
    {
        //Uwaga: ten orak kolejny przykład korzystają z plików DLL biblioteki Rx,
        //które można pobrać z internetu.
        //Jeżeli podczas kompilacji pojawią się błędy, to należy pobrać
        //i zainstalować Rx 2.0 SDK

        //Listing 11-9
        private static IObservable<string> GetFilePusher(string path)
        {
            return Observable.Create<string>(observer =>
            {
                using (var sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        observer.OnNext(sr.ReadLine());
                    }
                }
                observer.OnCompleted();
                return () => { };
            });
        }

        public static void UseFilePusher()
        {
            var source = GetFilePusher(@"..\..\Program.cs");
            var subscriber = new MySubscriber<string>();
            source.Subscribe(subscriber);
        }
 
    }
}
