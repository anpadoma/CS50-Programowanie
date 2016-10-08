using Chapter05.Annotations;

namespace Chapter05
{
    interface IBase1
    {
        [UsedImplicitly]
        void Base1Method();
    }

    interface IBase2
    {
        [UsedImplicitly]
        void Base2Method();
    }

    interface IBoth : IBase1, IBase2
    {
        [UsedImplicitly]
        void Method3();
    }

    class Interfejsy : IBoth
    {
        public void Base1Method()
        {
            throw new System.NotImplementedException();
        }

        public void Base2Method()
        {
            throw new System.NotImplementedException();
        }

        public void Method3()
        {
            throw new System.NotImplementedException();
        }
    }
}
