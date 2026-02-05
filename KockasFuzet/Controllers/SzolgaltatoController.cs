using KockasFuzet.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KockasFuzet.Controllers
{
    internal class SzolgaltatoController
    {
        public List<Szolgaltato> GetSzolgaltatoList()
        {
            MySqlConnection connection = new MySqlConnection();
            string connectionString = "SERVER =localhost;DATABASE=kockasfuzet;UID=root;PASSWORD=;";
            connection.ConnectionString = connectionString;
            try
            {
                connection.Open();
                string sql = "SELECT * FROM szolgaltato";
                MySqlCommand command = new MySqlCommand(sql, connection);
                List<Szolgaltato> eredmeny = new List<Szolgaltato>();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    eredmeny.Add(new Szolgaltato()
                    {
                        RovidNev = reader.GetString("RovidNev"),
                        Nev = reader.GetString("Nev"),
                        Ugyfelszolgalat = reader.GetString("Ugyfelszolgalat")
                    });
                }
                connection.Close();
                return eredmeny;
            }
            catch (Exception)
            {
                //Console.WriteLine("Hiba történt: " + ex.Message);
                return new List<Szolgaltato>();
            }
        }

        public List<string> GetSzolgaltatoRovidList()
        {
            MySqlConnection connection = new MySqlConnection();
            string connectionString = "SERVER =localhost;DATABASE=kockasfuzet;UID=root;PASSWORD=;";
            connection.ConnectionString = connectionString;
            try
            {
                connection.Open();
                string sql = "SELECT RovidNev FROM szolgaltato";
                MySqlCommand command = new MySqlCommand(sql, connection);
                List<string> eredmeny = new List<string>();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    eredmeny.Add(reader.GetString("RovidNev"));
                }
                connection.Close();
                return eredmeny;
            }
            catch (Exception)
            {
                //Console.WriteLine("Hiba történt: " + ex.Message);
                return new List<string>();
            }
        }


        public Szolgaltato GetSzolgaltatoByRovidNev(string rovidNev)
        {
            MySqlConnection connection = new MySqlConnection();
            string connectionString = "SERVER =localhost;DATABASE=kockasfuzet;UID=root;PASSWORD=;";
            connection.ConnectionString = connectionString;
            try
            {
                connection.Open();
                string sql = "SELECT * FROM szolgaltato WHERE RovidNev = @RovidNev";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@RovidNev", rovidNev);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return new Szolgaltato()
                    {
                        RovidNev = reader.GetString("RovidNev"),
                        Nev = reader.GetString("Nev"),
                        Ugyfelszolgalat = reader.GetString("Ugyfelszolgalat")
                    };
                }
                connection.Close();
                return null;
            }
            catch (Exception)
            {
                //Console.WriteLine("Hiba történt: " + ex.Message);
                return null;
            }
        }

        public string CreateSzolgaltato(Szolgaltato szolgaltato)
        {
            MySqlConnection connection = new MySqlConnection();
            string connectionString = "SERVER =localhost;DATABASE=kockasfuzet;UID=root;PASSWORD=;";
            connection.ConnectionString = connectionString;
            try
            {
                connection.Open();
                string sql = "INSERT INTO `szolgaltato`(`RovidNev`, `Nev`, `Ugyfelszolgalat`) VALUES (@RovidNev,@Nev,@Ugyfelszolgalat)";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@RovidNev", szolgaltato.RovidNev);
                command.Parameters.AddWithValue("Nev", szolgaltato.Nev);
                command.Parameters.AddWithValue("@Ugyfelszolgalat", szolgaltato.Ugyfelszolgalat);
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
        public string UpdateSzolgaltato(Szolgaltato szolgaltato)
        {
            MySqlConnection connection = new MySqlConnection();
            string connectionString = "SERVER =localhost;DATABASE=kockasfuzet;UID=root;PASSWORD=;";
            connection.ConnectionString = connectionString;
            try
            {
                connection.Open();
                string sql = "UPDATE `szolgaltato` SET `RovidNev` = @RovidNev, `Nev` = @Nev, `Ugyfelszolgalat` = @Ugyfelszolgalat WHERE `Id` = @Id";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@RovidNev", szolgaltato.RovidNev);
                command.Parameters.AddWithValue("Nev", szolgaltato.Nev);
                command.Parameters.AddWithValue("@Ugyfelszolgalat", szolgaltato.Ugyfelszolgalat);
                int sorokSzama = command.ExecuteNonQuery();
                connection.Close();
                string valasz = sorokSzama > 0 ? "Sikeres módosítás" : "Sikertelen módosítás";
                return valasz;
            }
            catch (Exception ex)
            {
                return "Hiba történt: " + ex.Message;
            }
        }
        public string DeleteSzolgaltato(Szolgaltato szolgaltato)
        {
            MySqlConnection connection = new MySqlConnection();
            string connectionString = "SERVER =localhost;DATABASE=kockasfuzet;UID=root;PASSWORD=;";
            connection.ConnectionString = connectionString;
            try
            {
                connection.Open();
                string sql = "DELETE FROM `szolgaltato` WHERE `RovidNev` = @RovidNev";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@RovidNev", szolgaltato.RovidNev);
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
