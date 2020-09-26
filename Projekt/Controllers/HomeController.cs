/// Klasa kontrolera

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Projekt.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Routing;

namespace Projekt.Controllers
{
    /// <summary>
    /// Kontroler zdarzen
    /// Klasa kontrolera zdarzen zachodzacych w aplikacji
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Dodanie firmy
        /// </summary>
        /// <returns></returns>
        public IActionResult DodajFirme()
        {
            return View();
        }

        /// <summary>
        /// Podsumowanie kwoty
        /// Podlicza kwote
        /// </summary>
        /// <param name="zest"></param>
        /// <returns></returns>
        public IActionResult OPodsumowanie(Zestawienie zest)
        {
            zest.PelnaCena = zest.oblPelnaCena();
            var a = zest.IDFirmy;
            SaveToCookie(zest);
            return View(zest);
        }

        /// <summary>
        /// Dane w cookie
        /// Przechowuje dane w pliku cookie
        /// </summary>
        /// <param name="zest"></param>
        public void SaveToCookie(Zestawienie zest)
        {
            HttpContext.Session.SetString("il_N1", zest.il_N1.ToString());
            HttpContext.Session.SetString("il_N2", zest.il_N2.ToString());
            HttpContext.Session.SetString("il_N3", zest.il_N3.ToString());
            HttpContext.Session.SetString("il_N4", zest.il_N4.ToString());
            HttpContext.Session.SetString("il_N5", zest.il_N5.ToString());
            HttpContext.Session.SetString("il_N6", zest.il_N6.ToString());
            HttpContext.Session.SetString("il_N7", zest.il_N7.ToString());
            HttpContext.Session.SetString("il_N8", zest.il_N8.ToString());
            HttpContext.Session.SetString("il_N9", zest.il_N9.ToString());
            HttpContext.Session.SetString("il_N10", zest.il_N10.ToString());
            HttpContext.Session.SetString("il_N11", zest.il_N11.ToString());
            HttpContext.Session.SetString("il_N12", zest.il_N12.ToString());
            HttpContext.Session.SetString("il_N13", zest.il_N13.ToString());
            HttpContext.Session.SetString("il_N14", zest.il_N14.ToString());
            HttpContext.Session.SetString("il_N15", zest.il_N15.ToString());
            HttpContext.Session.SetString("IDFirmy", zest.IDFirmy.ToString());
            HttpContext.Session.SetString("IDWaluty", zest.IDWaluty.ToString());
            HttpContext.Session.SetString("NazwaZ", zest.NazwaZ.ToString());
        }
         /// <summary>
         /// Zapisanie do bazy
         /// Dokonuje zapisu do bazy danych
         /// </summary>
         /// <param name="zest"></param>
         /// <returns></returns>
        public IActionResult Zakonczenie(Zestawienie zest)
        {
            zest.il_N1 = Int32.Parse(HttpContext.Session.GetString("il_N1"));
            zest.il_N2 = Int32.Parse(HttpContext.Session.GetString("il_N1"));
            zest.il_N3 = Int32.Parse(HttpContext.Session.GetString("il_N1"));
            zest.il_N4 = Int32.Parse(HttpContext.Session.GetString("il_N1"));
            zest.il_N5 = Int32.Parse(HttpContext.Session.GetString("il_N1"));
            zest.il_N6 = Int32.Parse(HttpContext.Session.GetString("il_N1"));
            zest.il_N7 = Int32.Parse(HttpContext.Session.GetString("il_N1"));
            zest.il_N8 = Int32.Parse(HttpContext.Session.GetString("il_N1"));
            zest.il_N9 = Int32.Parse(HttpContext.Session.GetString("il_N1"));
            zest.il_N10 = Int32.Parse(HttpContext.Session.GetString("il_N1"));
            zest.il_N11 = Int32.Parse(HttpContext.Session.GetString("il_N1"));
            zest.il_N12 = Int32.Parse(HttpContext.Session.GetString("il_N1"));
            zest.il_N13 = Int32.Parse(HttpContext.Session.GetString("il_N1"));
            zest.il_N14 = Int32.Parse(HttpContext.Session.GetString("il_N1"));
            zest.il_N15 = Int32.Parse(HttpContext.Session.GetString("il_N1"));

            zest.IDFirmy = Int32.Parse(HttpContext.Session.GetString("IDFirmy"));
            zest.IDWaluty = Int32.Parse(HttpContext.Session.GetString("IDWaluty"));
            zest.NazwaZ = HttpContext.Session.GetString("NazwaZ");
            int result = zest.SaveDetails();
            if (result > 0)
            {
                HttpContext.Session.SetString("Podsumowanie", "Zapisano Poprawnie!");
            }
            else
            {
                HttpContext.Session.SetString("Podsumowanie", "Bład");
            }
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Powrot
        /// Przycisk powrotu
        /// </summary>
        /// <returns></returns>
        public IActionResult powrotDoZestawienie()
        {
            return RedirectToAction("Zestawienie");
        }

        /// <summary>
        /// Zestawienie
        /// Zestawienie po wyborze firmy i waluty
        /// </summary>
        /// <returns></returns>
        public IActionResult Zestawienie()
        {
            if (HttpContext.Session.GetString("WybranFirma") != null && HttpContext.Session.GetString("WybranWaluta") != null)
            {
                ViewBag.NazwaFirmy = HttpContext.Session.GetString("WybranFirma").ToString();
                ViewBag.NazwaWaluty = HttpContext.Session.GetString("WybranWaluta").ToString();
            }
            else
            {
                HttpContext.Session.SetString("Blad", "Nie wybrano Firmy lub Waluty!");
                return RedirectToAction("Index");
            }
            var model = new Zestawienie();
            model.Nominaly = model.ZaktualizujListeNominalow();
            model.waluty = model.ZaktualizujListeWalut();
            foreach(var item in model.waluty)
            {
                if (item.Key.ToString().Equals(HttpContext.Session.GetString("WybranWaluta")))
                {
                    model.wybranaWaluta = item.Value;
                }
            }
            return View(model);
        }

        /// <summary>
        /// Index
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            
            if (HttpContext.Session.GetString("Podsumowanie") != null)
            {
                ViewBag.Info = "Zapisano!";
            }
            if (HttpContext.Session.GetString("Blad") != null)
            {
                ViewBag.Error = "Nie wybrano Firmy lub Waluty!";
            }
            if (HttpContext.Session.GetString("NowaFirmaInfo") != null)
            {
                ViewBag.NowaFirmaInfo = HttpContext.Session.GetString("NowaFirmaInfo");
            }
            var model = new Dane();
            model.Firmy = model.ZaktualizujListeFirm();
            model.Waluty = model.ZaktualizujListeWalut();
            return View(model);
        }

        /// <summary>
        /// Pobranie nazw firm
        /// Pobiera nazwy i dane firm z bazy danych
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IActionResult CollectCompanyName(Dane model)
        {
            if (HttpContext.Session.GetString("Blad") != null)
            {
                HttpContext.Session.Remove("Blad");
            }
            try
            {
                HttpContext.Session.SetString("WybranFirma", model.WybranaFirma);
                HttpContext.Session.SetString("WybranWaluta", model.WybranaWaluta);
            }
            catch
            {
                HttpContext.Session.SetString("Blad", "Nie wybrano Firmy lub Waluty!"); 
                return RedirectToAction("Index");
            }
            return RedirectToAction("Zestawienie");
        }

        /// <summary>
        /// Warosci
        /// </summary>
        /// <returns></returns>
        public IActionResult Podsumowanie()
        {
            ZbierzDaneZBazy ZB = new ZbierzDaneZBazy();
            Zestawienie zest = new Zestawienie();

            zest.il_N1 = Int32.Parse(HttpContext.Request.Form["1"]);
            zest.il_N2 = Int32.Parse(HttpContext.Request.Form["2"]);
            zest.il_N3 = Int32.Parse(HttpContext.Request.Form["3"]);
            zest.il_N4 = Int32.Parse(HttpContext.Request.Form["4"]);
            zest.il_N5 = Int32.Parse(HttpContext.Request.Form["5"]);
            zest.il_N6 = Int32.Parse(HttpContext.Request.Form["6"]);
            zest.il_N7 = Int32.Parse(HttpContext.Request.Form["7"]);
            zest.il_N8 = Int32.Parse(HttpContext.Request.Form["8"]);
            zest.il_N9 = Int32.Parse(HttpContext.Request.Form["9"]);
            zest.il_N10 = Int32.Parse(HttpContext.Request.Form["10"]);
            zest.il_N11 = Int32.Parse(HttpContext.Request.Form["11"]);
            zest.il_N12 = Int32.Parse(HttpContext.Request.Form["12"]);
            zest.il_N13 = Int32.Parse(HttpContext.Request.Form["13"]);
            zest.il_N14 = Int32.Parse(HttpContext.Request.Form["14"]);
            zest.il_N15 = Int32.Parse(HttpContext.Request.Form["15"]);
            
            zest.IDFirmy = ZB.GetIDFirmy(HttpContext.Session.GetString("WybranFirma"));
            zest.IDWaluty = ZB.GetIDWaluty(HttpContext.Session.GetString("WybranWaluta"));
            zest.NazwaZ = ZB.NazwaZ(zest.IDFirmy);
                
            return RedirectToAction("OPodsumowanie",new RouteValueDictionary(zest));
        }

        /// <summary>
        /// Dodanie nowej firmy
        /// Dodane nowej firmy i informacji o niej do bazy
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddCompany()
        {
            Firmy firmy = new Firmy();
            string nazwa = HttpContext.Request.Form["txtNazwa"].ToString();
            string adres = HttpContext.Request.Form["txtAdres"].ToString();
            string miasto = HttpContext.Request.Form["txtMiasto"].ToString();
            string kod = HttpContext.Request.Form["txtKod"].ToString();
            string bank = HttpContext.Request.Form["txtBank"].ToString();
            string konto = HttpContext.Request.Form["txtKonto"].ToString();
            int result = firmy.SaveDetails(nazwa, adres, miasto, kod, bank, konto);
            if (result > 0)
            {
                HttpContext.Session.SetString("NowaFirmaInfo", "Firma zostala dodana poprawnie");
            }
            else
            {
                HttpContext.Session.SetString("NowaFirmaInfo", "Bład");
            }
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Error
        /// Blad wynikajacy z zlego wyboru akcji
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
