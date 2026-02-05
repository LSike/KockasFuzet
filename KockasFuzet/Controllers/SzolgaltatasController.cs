using KockasFuzet.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KockasFuzet.Controllers
{
    internal class SzolgaltatasController
    {
        public List<Szolgaltatas> GetSzolgaltatasList()
        {
            MySqlConnection connection = new MySqlConnection();
            string connectionString = "SERVER =localhost;DATABASE=kockasfuzet;UID=root;PASSWORD=;";
            connection.ConnectionString = connectionString;
            try
            {
                connection.Open();
                string sql = "SELECT * FROM szolgaltatas";
                MySqlCommand command = new MySqlCommand(sql, connection);
                List<Szolgaltatas> eredmeny = new List<Szolgaltatas>();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    eredmeny.Add(new Szolgaltatas()
                    {
                        Id = reader.GetInt32("Id"),
                        Nev = reader.GetString("Nev")                        
                    });
                }
                connection.Close();
                return eredmeny;
            }
            catch (Exception)
            {
                //Console.WriteLine("Hiba történt: " + ex.Message);
                return new List<Szolgaltatas>();
            }
        }

        public List<int> GetSzolgaltatasIdList()
        {
            MySqlConnection connection = new MySqlConnection();
            string connectionString = "SERVER =localhost;DATABASE=kockasfuzet;UID=root;PASSWORD=;";
            connection.ConnectionString = connectionString;
            try
            {
                connection.Open();
                string sql = "SELECT Id FROM szolgaltatas";
                MySqlCommand command = new MySqlCommand(sql, connection);
                List<int> eredmeny = new List<int>();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    eredmeny.Add(reader.GetInt32("Id"));                       
                }
                connection.Close();
                return eredmeny;
            }
            catch (Exception)
            {
                //Console.WriteLine("Hiba történt: " + ex.Message);
                return new List<int>();
            }
        }

        public Szolgaltatas GetSzolgaltatasById(int id)
        {
            MySqlConnection connection = new MySqlConnection();
            string connectionString = "SERVER =localhost;DATABASE=kockasfuzet;UID=root;PASSWORD=;";
            connection.ConnectionString = connectionString;
            try
            {
                connection.Open();
                string sql = "SELECT * FROM szolgaltatas WHERE Id = @Id";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", id);
                Szolgaltatas eredmeny = new Szolgaltatas();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    eredmeny.Id = reader.GetInt32("Id");
                    eredmeny.Nev = reader.GetString("Nev");
                }
                connection.Close();
                return eredmeny;
            }
            catch (Exception)
            {
                //Console.WriteLine("Hiba történt: " + ex.Message);
                return null;
            }
        }

        public string CreateSzolgaltatas(Szolgaltatas szolgaltatas)
        {
            MySqlConnection connection = new MySqlConnection();
            string connectionString = "SERVER =localhost;DATABASE=kockasfuzet;UID=root;PASSWORD=;";
            connection.ConnectionString = connectionString;
            try
            {
                connection.Open();
                string sql = "INSERT INTO `szolgaltatas`(`Id`, `Nev`) VALUES (@Id,@Nev)";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", szolgaltatas.Id);
                command.Parameters.AddWithValue("@Nev", szolgaltatas.Nev);
                int sorokSzama = command.ExecuteNonQuery();
                connection.Close();
                string valasz = sorokSzama > 0 ? "Sikeres rögzítés" : "Sikertelen rögzítés";
                return valasz;
            }
            catch (Exception ex)
            {
                return "Hiba történt: " + ex.Message;
            }
        }

        public string UpdateSzolgaltatas(Szolgaltatas szolgaltatas)
        {
            MySqlConnection connection = new MySqlConnection();
            string connectionString = "SERVER =localhost;DATABASE=kockasfuzet;UID=root;PASSWORD=;";
            connection.ConnectionString = connectionString;
            try
            {
                connection.Open();
                string sql = "UPDATE `szolgaltatas` SET `Nev` = @Nev WHERE `Id` = @Id";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", szolgaltatas.Id);
                command.Parameters.AddWithValue("@Nev", szolgaltatas.Nev);
                int sorokSzama = command.ExecuteNonQuery();
                connection.Close();
                string valasz = sorokSzama > 0 ? "Sikeres frissítés" : "Sikertelen frissítés";
                return valasz;
            }
            catch (Exception ex)
            {
                return "Hiba történt: " + ex.Message;
            }
        }

        public string DeleteSzolgaltatas(int id)
        {
            MySqlConnection connection = new MySqlConnection();
            string connectionString = "SERVER =localhost;DATABASE=kockasfuzet;UID=root;PASSWORD=;";
            connection.ConnectionString = connectionString;
            try
            {
                connection.Open();
                string sql = "DELETE FROM `szolgaltatas` WHERE `Id` = @Id";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", id);
                int sorokSzama = command.ExecuteNonQuery();
                connection.Close();
                string valasz = sorokSzama > 0 ? "Sikeres törlés" : "Sikertelen törlés";
                return valasz;
            }
            catch (Exception ex)
            {
                return "Hiba történt: " + ex.Message;
            }
        }
    }
}
