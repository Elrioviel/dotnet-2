using System;

namespace Hello_World
{
    class Program
    {
        static string GetUserDomainName()
        {
            string userName = Environment.UserDomainName;
            return userName;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello {0}", GetUserDomainName());
        }
    }
}
