namespace Abstract_factory
{
    class Client
    {
        private ISaltedPopCorn productA;
        private ISweetPopCorn productB;

        public Client(IPopCornFactory factory)
        {
            productA = factory.CreateSaltedPopCorn();
            productB = factory.CreateSweetPopCorn();
        }
    }
}
