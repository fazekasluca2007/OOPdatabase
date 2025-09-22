using OOPadatbazis.Services;
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
            
            ISqlStatements sqlStatements = new TableCars();
            Console.Write("Kérem az adatbázist , amibőla lekérdezést szeretné: ");
            string table=Console.ReadLine();
            Console.Write("Válasszon lekérdezést. ");


            /*foreach (var item in sqlStatements.GetAllBooks())
            {
                var book= item.GetType().GetProperties();
                Console.WriteLine($"{book[0].Name}={book[0].GetValue(item)}, {book[1].Name}={book[1].GetValue(item)}");

            }*/
            /*Feladat2
            Console.Write("Kérem a rekord id-t: ");
            var item=sqlStatements.GetById(int.Parse(Console.ReadLine()));
            var book = item.GetType().GetProperties();
            Console.WriteLine($"{book[1].Name}={book[1].GetValue(item)}");*/

            /*Feladat3
             * Console.WriteLine("Kérem a könyv címét: ");
            string cim=Console.ReadLine();
            Console.WriteLine("Kérem a könyv szerzőjét: ");
            string szerzo = Console.ReadLine();
            Console.WriteLine("Kérem a könyv kiadási évét: ");
            string datum = Console.ReadLine();

            var book = new
            {
                Title = cim,
                Author = szerzo,
                Release = datum,

            };

            sqlStatements.AddNewRecord(book);*/
           
            Console.WriteLine("Kérem az autó márkáját: ");
            string marka = Console.ReadLine();
            Console.WriteLine("Kérem az autó típusát: ");
            string tipus = Console.ReadLine();
            Console.WriteLine("Kérem a dátumot: ");
            string datum = Console.ReadLine();

            var car = new
            {
                Brand = marka,
                Type = tipus,
                mDate = datum,

            };
            Console.WriteLine(sqlStatements.AddNewRecord(car));




        }
    }
}
