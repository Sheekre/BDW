/// Model firmy
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Models
{
    /// <summary>
    /// Model firmy
    /// Klasa modelu firmy i jej informacji
    /// </summary>
    /// <param name="nazwa">Nazwa firmy.</param>
    /// <param name="adres">Adres firmy, miasto oraz numer.</param>
    /// <param name="miasto">Miasto polozenia firmy.</param>
    /// <param name="kod">Kod pocztowy.</param>
    /// <param name="bank">Nazwa banku, w ktorej firma ma konto.</param>
    /// <param name="konto">Numer konta bakowego.</param>
    public class Firmy
    {
        public int SaveDetails(string nazwa, string adres, string miasto, string kod, string bank, string konto)
        {
            if (nazwa != null && adres != null && miasto != null && kod != null && bank != null && konto != null)
            {
                SqlConnection con = new SqlConnection(GetConnectionString.ConString());
                con.ConnectionString = "Data Source=LAPTOP-ASA6V7LH\\SQLEXPRESS;Initial Catalog=BDW;Integrated Security=True";
                string query = "INSERT INTO Firma(Nazwa, Adres, Miasto, Kod, Bank ,Konto) values ('" + nazwa + "','" + adres + "'," +
                    "'" + miasto + "','" + kod + "','" + bank + "','" + konto + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                return i;
            }
            else
                return 0;
        }
    }


}
