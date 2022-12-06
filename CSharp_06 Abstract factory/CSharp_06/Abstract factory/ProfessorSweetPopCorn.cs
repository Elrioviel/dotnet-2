using System;

namespace Abstract_factory
{
    class ProfessorSweetPopCorn : ISweetPopCorn
    {
        public void GetDBIngredients()
        {
            Console.WriteLine("Getting ingredients from database...");
        }

        public void MakeSweetPopCorn()
        {
            Console.WriteLine("Making sweet popcorn...");
        }
    }
}
