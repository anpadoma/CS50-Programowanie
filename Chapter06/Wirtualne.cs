using System;

namespace Chapter06
{
    public class BaseWithVirtual
    {
        public virtual void ShowMessage()
        {
            Console.WriteLine("Witamy w metodzie BaseWithVirtual");
        }
    }

    public class Wirtualne
    {
        public static void CallVirtualMethod(BaseWithVirtual o)
        {
            o.ShowMessage();
        }
    }

    public class DeriveWithoutOverride : BaseWithVirtual
    {
        
    }

    public class DeriveAndOverride : BaseWithVirtual
    {
        public override void ShowMessage()
        {
            Console.WriteLine("Ta metoda przesłania metodę wirtualną!");
        }
    }
}
