using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPadatbazis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kérem az adatbázis nevét");
            string dbName=Console.ReadLine();

            Console.WriteLine("Kérem a felhasználó nevét");
            string userName = Console.ReadLine();

            Console.WriteLine("Kérem a felhasználó jelszavát");
            string userPassword = Console.ReadLine();

            Connect c=new Connect(dbName, userName, userPassword);


        }
    }
}
