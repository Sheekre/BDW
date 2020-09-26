///Model zestawienia
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Models
{
/// <summary>
/// Model zestawienia
/// </summary>
 
    public class Zestawienie
    {
        public Zestawienie()
        {
            this.checkifCorrect = false;
        }
        public bool checkifCorrect { get; set; }
        public double PelnaCena { get; set; }

        ZbierzDaneZBazy ZB = new ZbierzDaneZBazy();
        public Dictionary<int,string> ZaktualizujListeNominalow()
        {
            int i = 1;
            Dictionary<int,string> list = new Dictionary<int,string>();
            foreach (var item in ZB.GetNominal())
            {
                list.Add(i,item.NazwaN);
                i++;
            }
            return list;
        }
        public Dictionary<string, string> ZaktualizujListeWalut()
        {
            Dictionary<string, string> list = new Dictionary<string, string>();
            foreach (var item in ZB.GedWaluty())
            {
                list.Add(item.NazwaW, item.SymbolW);
            }
            return list;
        }
        public string wybranaWaluta { get; set; }
        public Dictionary<string,string> waluty { get; set; }
        public Dictionary<int,string> Nominaly { get; set; }
        //Nominal
        public int IDNominal { get; set; }
        public string NazwaN { get; set; }
        //Do Zestawienia
        public string NazwaZ { get; set; }
        public int IDFirmy { get; set; }
        public int IDWaluty { get; set; }
        public int il_N1 { get; set; }
        public int il_N2 { get; set; }
        public int il_N3 { get; set; }
        public int il_N4 { get; set; }
        public int il_N5 { get; set; }
        public int il_N6 { get; set; }
        public int il_N7 { get; set; }
        public int il_N8 { get; set; }
        public int il_N9 { get; set; }
        public int il_N10 { get; set; }
        public int il_N11 { get; set; }
        public int il_N12 { get; set; }
        public int il_N13 { get; set; }
        public int il_N14 { get; set; }
        public int il_N15 { get; set; }
        public double oblPelnaCena()
        {
            return (il_N1 * 0.01) + (il_N2 * 0.02) + (il_N3 * 0.05) + (il_N4 * 0.1) + (il_N5 * 0.2) + (il_N6 * 0.5) + (il_N7 * 1) + (il_N8 * 2) + (il_N9 * 5) + (il_N10 * 10) + (il_N11 * 20) +
                (il_N12 * 50) + (il_N13 * 100) + (il_N14 * 200) + (il_N15 * 500);
        }
        public int SaveDetails()
        {
            SqlConnection con = new SqlConnection(GetConnectionString.ConString());
            con.ConnectionString = "Data Source=LAPTOP-ASA6V7LH\\SQLEXPRESS;Initial Catalog=BDW;Integrated Security=True";
            string query = "INSERT INTO Zestawienie(NazwaZ,IDFirmy,IDWaluty,il_N1, il_N2, il_N3,il_N4,il_N5,il_N6,il_N7,il_N8,il_N9,il_N10,il_N11,il_N12,il_N13,il_N14,il_N15) values ('" + NazwaZ + "','" + IDFirmy + "','" + IDWaluty + "'" +
                ",'" + il_N1 + "','" + il_N2 + "','" + il_N3 + "','" + il_N4 + "','" + il_N5 + "','" + il_N6 + "','" + il_N7 + "','" + il_N8 + "','" + il_N9 + "','" + il_N10 + "','" + il_N11 + "','" + il_N12 + "','" + il_N13 + "','" + il_N14 + "','" + il_N15 + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}
