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

        public string CreateSzolgaltato(Szolgaltato szolgaltato)
        {

            MySqlConnection connection = new MySqlConnection();
            string connectionString = "SERVER =localhost;DATABASE=kockasfuzet;UID=root;PASSWORD=;";
            connection.ConnectionString = connectionString;
            connection.Open();
            string sql = "INSERT INTO `szolgaltato`(`RovidNev`, `Nev`, `Ugyfelszolgalat`) VALUES (@RovidNev,@Nev,@Ugyfelszolgalat)";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@RovidNev",szolgaltato.RovidNev);
            command.Parameters.AddWithValue("Nev",szolgaltato.Nev);
            command.Parameters.AddWithValue("@Ugyfelszolgalat",szolgaltato.Ugyfelszolgalat);
            int sorokSzama = command.ExecuteNonQuery();
            connection.Close();
            string valasz = sorokSzama > 0 ? "Sikeres rögzítés" : "Sikertelen rögzítés";
            return valasz;
        }
        
    }
}
