/// Model danych
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Models
{
    /// <summary>
    /// Model danych
    /// Klasa modelu danych do zestawienia
    /// </summary>

    public class Dane
    {
        ZbierzDaneZBazy ZB = new ZbierzDaneZBazy();
        public Dane()
        {
            Firmy = new List<string>();
        }
        public List<string> ZaktualizujListeFirm()
        {
            List<string> list = new List<string>();
            foreach(var item in ZB.GetComNames())
            {
                list.Add(item.Nazwa);
            }
            return list;
        }
        public List<string> ZaktualizujListeWalut()
        {
            List<string> list = new List<string>();
            foreach (var item in ZB.GedWaluty())
            {
                list.Add(item.NazwaW);
            }
            return list;
        }
        public string WybranaWaluta { get; set; }
        public List<string> Waluty { get; set; }
        public string WybranaFirma { get; set; }
        public List<string> Firmy { get; set; }
    }
}
