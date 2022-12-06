using System;

namespace Abstract_factory
{
    class SecretSaltedPopCorn : ISaltedPopCorn
    {
        public void GetDBIngredients()
        {
            Console.WriteLine("Getting ingredients from database...");
        }

        public void MakeSaltedPopCorn()
        {
            Console.WriteLine("Making sweet popcorn...");
        }
    }
}
