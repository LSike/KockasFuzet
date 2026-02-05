using KockasFuzet.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KockasFuzet.Controllers
{
    internal class SzamlaController
    {
        public List<Szamla> GetSzamalakLista()
        {
            MySqlConnection connection = new MySqlConnection();
            string connectionString = "SERVER =localhost;DATABASE=kockasfuzet;UID=root;PASSWORD=;";
            connection.ConnectionString = connectionString;
            try
            {
                connection.Open();
                string sql = "SELECT * FROM szamla";
                MySqlCommand command = new MySqlCommand(sql, connection);
                List<Szamla> eredmeny = new List<Szamla>();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    eredmeny.Add(new Szamla()
                    {
                        Id = reader.GetInt32("Id"),
                        SzolgaltatasAzon = reader.GetInt32("SzolgaltatasAzon"),
                        SzolgaltatoRovid = reader.GetString("SzolgaltatoRovid"),
                        Tol = reader.GetDateTime("tol"),
                        Ig = reader.GetDateTime("ig"),
                        Osszeg = reader.GetInt32("Osszeg"),
                        Hatarido = reader.GetDateTime("Hatarido"),
                        Befizetve = reader.IsDBNull(7) ? DateTime.MinValue : reader.GetDateTime("befizetve"),
                        Megjegyzes = reader.IsDBNull(8) ? "" : reader.GetString("Megjegyzes")
                    });
                }
                connection.Close();
                return eredmeny;
            }
            catch (Exception)
            {
                //Console.WriteLine("Hiba történt: " + ex.Message);
                return new List<Szamla>();
            }
        }

        public Szamla GetSzamlaById(int id)
        {
            MySqlConnection connection = new MySqlConnection();
            string connectionString = "SERVER =localhost;DATABASE=kockasfuzet;UID=root;PASSWORD=;";
            connection.ConnectionString = connectionString;
            try
            {
                connection.Open();
                string sql = "SELECT * FROM szamla WHERE Id = @Id";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", id);
                Szamla eredmeny = new Szamla();
                MySqlDataReader reader = command.ExecuteReader();
                reader.Read();
                eredmeny.Id = reader.GetInt32("id");
                eredmeny.SzolgaltatasAzon = reader.GetInt32("SzolgaltatasAzon");
                eredmeny.SzolgaltatoRovid = reader.GetString("SzolgaltatoRovid");
                eredmeny.Tol = reader.GetDateTime("tol");
                eredmeny.Ig = reader.GetDateTime("ig");
                eredmeny.Osszeg = reader.GetInt32("Osszeg");
                eredmeny.Hatarido = reader.GetDateTime("Hatarido");
                eredmeny.Befizetve = reader.IsDBNull(7) ? DateTime.MinValue : reader.GetDateTime("befizetve");
                eredmeny.Megjegyzes = reader.IsDBNull(8) ? "" : reader.GetString("Megjegyzes");
                connection.Close();
                return eredmeny;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public string CreateSzamla(Szamla szamla)
        {
            MySqlConnection connection = new MySqlConnection();
            string connectionString = "SERVER =localhost;DATABASE=kockasfuzet;UID=root;PASSWORD=;";
            connection.ConnectionString = connectionString;
            try
            {
                connection.Open();
                string sql = "INSERT INTO `szamla`(`Id`, `SzolgaltatasAzon`, `SzolgaltatoRovid`, `Tol`, `Ig`, `Osszeg`, `Hatarido`, `Befizetve`, `Megjegyzes`) VALUES (null, @SzolgaltatasAzon, @SzolgaltatoRovid, @Tol, @Ig, @Osszeg, @Hatarido, @Befizetve, @Megjegyzes)";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@SzolgaltatasAzon", szamla.SzolgaltatasAzon);
                command.Parameters.AddWithValue("@SzolgaltatoRovid", szamla.SzolgaltatoRovid);
                command.Parameters.AddWithValue("@Tol", szamla.Tol);
                command.Parameters.AddWithValue("@Ig", szamla.Ig);
                command.Parameters.AddWithValue("@Osszeg", szamla.Osszeg);
                command.Parameters.AddWithValue("@Hatarido", szamla.Hatarido);
                command.Parameters.AddWithValue("@Befizetve", szamla.Befizetve);
                command.Parameters.AddWithValue("@Megjegyzes", szamla.Megjegyzes);
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

        public string UpdateSzamla(Szamla szamla)
        {
            throw new NotImplementedException();
        }

        public string DeleteSzamla(int id)
        {
            throw new NotImplementedException();
        }
    }
}
