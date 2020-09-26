/// Pobieranie danych
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;

namespace Projekt.Models
{
    /// <summary>
    /// Pobieranie danych
    /// Model pobierania informacji z bazy danych
    /// </summary>
    public class ZbierzDaneZBazy
    {
        /// <summary>
        /// Nazwy
        /// </summary>
       public string Nazwa { get; set; }
       public List<ZbierzDaneZBazy> GetComNames()
        {

            String sql = "SELECT * FROM Firma";
            var model = new List<ZbierzDaneZBazy>();
            using (SqlConnection con = new SqlConnection(GetConnectionString.ConString()))
            {
                con.ConnectionString = "Data Source=LAPTOP-ASA6V7LH\\SQLEXPRESS;Initial Catalog=BDW;Integrated Security=True";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var view = new ZbierzDaneZBazy();
                    view.Nazwa = rdr["Nazwa"].ToString();
                    model.Add(view);
                }

            }
            return model;
        }

        /// <summary>
        /// Waluty
        /// </summary>
        public string SymbolW { get; set; }
        public string NazwaW { get; set; }
        public List<ZbierzDaneZBazy> GedWaluty()
        {

            String sql = "SELECT * FROM Waluta";
            var model = new List<ZbierzDaneZBazy>();
            using (SqlConnection con = new SqlConnection(GetConnectionString.ConString()))
            {
                con.ConnectionString = "Data Source=LAPTOP-ASA6V7LH\\SQLEXPRESS;Initial Catalog=BDW;Integrated Security=True";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var view = new ZbierzDaneZBazy();
                    view.SymbolW = rdr["SymbolW"].ToString();
                    view.NazwaW = rdr["NazwaW"].ToString();
                    model.Add(view);
                }

            }
            return model;
        }

        /// <summary>
        /// Nominał
        /// </summary>
        public string NazwaN { get; set; }
        public List<ZbierzDaneZBazy> GetNominal()
        {

            String sql = "SELECT * FROM Nominal";
            var model = new List<ZbierzDaneZBazy>();
            using (SqlConnection con = new SqlConnection(GetConnectionString.ConString()))
            {
                con.ConnectionString = "Data Source=LAPTOP-ASA6V7LH\\SQLEXPRESS;Initial Catalog=BDW;Integrated Security=True";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var view = new ZbierzDaneZBazy();
                    view.NazwaN = rdr["NazwaN"].ToString();
                    model.Add(view);
                }

            }
            return model;
        }

        /// <summary>
        /// Firmy
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public int GetIDFirmy(string Data)
        {
            string value = string.Empty;
            String sql = $"SELECT IDFirmy FROM Firma WHERE Nazwa='{Data}'";
            using (SqlConnection con = new SqlConnection(GetConnectionString.ConString()))
            {
                con.ConnectionString = "Data Source=LAPTOP-ASA6V7LH\\SQLEXPRESS;Initial Catalog=BDW;Integrated Security=True";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var view = new ZbierzDaneZBazy();
                    value = rdr["IDFirmy"].ToString();
                }

            }
            return Int32.Parse(value);
        }
         public int GetIDWaluty(string Data)
        {
            string value = string.Empty;
            String sql = $"SELECT IDWaluty FROM Waluta WHERE NazwaW='{Data}'";
            using (SqlConnection con = new SqlConnection(GetConnectionString.ConString()))
            {
                con.ConnectionString = "Data Source=LAPTOP-ASA6V7LH\\SQLEXPRESS;Initial Catalog=BDW;Integrated Security=True";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var view = new ZbierzDaneZBazy();
                    value = rdr["IDWaluty"].ToString();
                }

            }
            return Int32.Parse(value);
        }
        public string NazwaZ(int IDFimry)
        {
            DateTime now = DateTime.Now;
            string value = IDFimry + "_" + "Zest" + "_" + now.Year + "_" + now.Month + "_" + now.Day;
            return value;
        }
    }
}
