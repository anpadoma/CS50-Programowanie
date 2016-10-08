using System;

namespace Events
{
    //Listing 9-39
    public class Eventful
    {
        public event Action<string> Announcement;

        public void Announce(string message)
        {
            if (Announcement != null)
            {
                Announcement(message);
            }
        }
    }
    
    class Examples39_43
    {
        public static void HandlingEvents()
        {
            //Listing 9-40
            var source = new Eventful();
            source.Announcement += m => Console.WriteLine("Zdarzenie Announcement: " + m);

            //Zgłaszamy
            source.Announce("Oto oświadczenie. I to już wszystko.");
        }
    }
}
