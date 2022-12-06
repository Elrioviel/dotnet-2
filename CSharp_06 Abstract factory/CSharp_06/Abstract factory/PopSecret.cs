namespace Abstract_factory
{
    class PopSecret : IPopCornFactory
    {
        public ISaltedPopCorn CreateSaltedPopCorn()
        {
            return new SecretSaltedPopCorn();
        }

        public ISweetPopCorn CreateSweetPopCorn()
        {
            return new SecretSweetPopCorn();
        }
    }
}
