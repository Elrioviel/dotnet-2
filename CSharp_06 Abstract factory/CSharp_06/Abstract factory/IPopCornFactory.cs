namespace Abstract_factory
{
    interface IPopCornFactory
    {
        public ISaltedPopCorn CreateSaltedPopCorn();
        public ISweetPopCorn CreateSweetPopCorn();
    }
}
