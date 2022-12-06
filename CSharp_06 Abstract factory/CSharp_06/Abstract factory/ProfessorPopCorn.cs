namespace Abstract_factory
{
    class ProfessorPopCorn : IPopCornFactory
    {
        public ISaltedPopCorn CreateSaltedPopCorn()
        {
            return new ProfessorSaltedPopCorn();
        }

        public ISweetPopCorn CreateSweetPopCorn()
        {
            return new ProfessorSweetPopCorn();
        }
    }
}
