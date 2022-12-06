using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Abstract_factory
{
    class ProfessorSaltedPopCorn : ISaltedPopCorn
    {
        public void GetDBIngredients()
        {
            Console.WriteLine("Getting ingredients from database...");
        }

        public void MakeSaltedPopCorn()
        {
            Console.WriteLine("Making salted popcorn...");
        }
    }
}