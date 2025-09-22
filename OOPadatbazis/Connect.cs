using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPadatbazis
{
   public class Connect
    {
        public MySqlConnection Connection;
        private string _host;
        private string _database;
        private string _user;
        private string _password;
        private string ConnectionString;
        public Connect(string database)
        {
            _host = "localhost";
            _database = database;
            _user = "root";
            _password = "";

            ConnectionString = $"SERVER={_host};DATABASE={_database};UID={_user};PASSWORD={_password};SslMode=None";
            Connection = new MySqlConnection(ConnectionString);
            try
            {
                Connection.Open();
                Console.WriteLine("Sikeres csatlakozás");
                Connection.Close();
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}
