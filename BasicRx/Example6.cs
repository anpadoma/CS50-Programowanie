using System;
using System.IO;
using System.Runtime.InteropServices;

namespace BasicRx
{
    //Listing 11-6
    public class FilePusherWithErrorHandling : IObservable<string>
    {
        private string _path;

        public FilePusherWithErrorHandling(string path)
        {
            _path = path;
        }

        public IDisposable Subscribe(IObserver<string> observer)
        {
            StreamReader sr = null;
            string line = null;
            bool failed = false;

            try
            {
                while (true)
                {
                    try
                    {
                        if (sr == null)
                        {
                            sr = new StreamReader(_path);
                        }
                        if (sr.EndOfStream)
                        {
                            break;
                        }
                        line = sr.ReadLine();
                    }
                    catch (IOException x)
                    {
                        observer.OnError(x);
                        failed = true;
                        break;
                    }
                    observer.OnNext(line);
                }
            }
            finally
            {
                if (sr != null)
                {
                    sr.Dispose();
                }
            }
            if (!failed)
            {
                observer.OnCompleted();
            }
            return EmptyDisposable.Instance;
        }

        private class EmptyDisposable : IDisposable
        {
            public static EmptyDisposable Instance = new EmptyDisposable();
            public void Dispose() { }
        }
    }
    class Example6
    {
        public static void UseFilePusher()
        {
            var source = new FilePusherWithErrorHandling(@"NoSuchFile1.txt");
            var subscriber = new MySubscriber<string>();
            source.Subscribe(subscriber);
        }
    }
}
