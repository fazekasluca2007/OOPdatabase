using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPadatbazis.Services
{
    internal class TableCars : ISqlStatements
    {
        Connect conn = new Connect();
        public object AddNewRecord(object newCar)
        {
            conn.Connection.Open();
            string sql = "INSERT INTO `cars`( `brand`, `type`, `mDate`) VALUES(@brand,@type, @mDate)";
            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);
            var car = newCar.GetType().GetProperties();
            cmd.Parameters.AddWithValue("@brand", car[0].GetValue(newCar));
            cmd.Parameters.AddWithValue("@type", car[1].GetValue(newCar));
            cmd.Parameters.AddWithValue("@mDate", car[2].GetValue(newCar));
            cmd.ExecuteNonQuery();
            conn.Connection.Close();
            return car;
        }

        public object DeleteRecord(int id)
        {
            conn.Connection.Open();
            string sql = "DELETE FROM cars WHERE id=@id";
            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            conn.Connection.Close();
            return new { Message = "Sikeres törlés" };
        }

        public List<object> GetAllRecords()
        {
            List<object> result = new List<object>();

            conn.Connection.Open();
            string sql = "SELECT * FROM cars";

            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);

            MySqlDataReader dr = cmd.ExecuteReader();

            //dr.Read();
            while (dr.Read())
            {
                var car = new
                {
                    Id = dr.GetInt32("id"),
                    brand = dr.GetString("brand"),
                    type = dr.GetString("type"),
                    mDate = dr.GetDateTime("mDate")

                };
                result.Add(car);
            }
            conn.Connection.Close();


            return result;
        }

        public object GetById(int id)
        {
            conn.Connection.Open();


            string sql = "SELECT * FROM cars WHERE id=@id";
            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);
            cmd.Parameters.AddWithValue("@id", id);
            MySqlDataReader dr = cmd.ExecuteReader();
            dr.Read();

            var car = new
            {
                Id = dr.GetInt32("id"),
                brand = dr.GetString("brand"),
                type = dr.GetString("type"),
                mDate = dr.GetDateTime("mDate")
            };

            conn.Connection.Close();
            return car;

        }

        public object UpdateRecord(int id, object updatecar)
        {
            conn.Connection.Open();
            string sql = "UPDATE `cars` SET `brand`=@brand,`type`=@author,`mDate`=@mDate WHERE id=@id";
            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);
            var car = updatecar.GetType().GetProperties();
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@brand", car[0].GetValue(updatecar));
            cmd.Parameters.AddWithValue("@type", car[1].GetValue(updatecar));
            cmd.Parameters.AddWithValue("@mDate", car[2].GetValue(updatecar));
            cmd.ExecuteNonQuery();
            conn.Connection.Close();
            return new
            {
                Message = "Sikeres frissítés"
            };
        }
    }
}
