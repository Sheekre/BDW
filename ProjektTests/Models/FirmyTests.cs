using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projekt.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt.Models.Tests
{
    [TestClass()]
    public class FirmyTests
    {
        /// <summary>
        /// Testy jednostkowe
        /// Zawiera 2 metody sprawdzajace czy dane zostana zapisane do bazy
        /// </summary>

        [TestMethod()]
        public void SaveDetailsTest()
        {
            // Metoda 1
            Firmy firmy = new Firmy();
            string nazwa = "firma testowa";
            string adres = "chmaja";
            string miasto = "rzeszow";
            string kod = "35-021";
            string bank = "pko";
            string konto = "111111111111111";
            int result = firmy.SaveDetails(nazwa, adres, miasto, kod, bank, konto);
           

            Assert.IsTrue(result > 0);



            // Metoda 2
            Firmy firmy2 = new Firmy();
            string nazwa2 = "firma testowa";
            string adres2 = null;
            string miasto2 = "rzeszow";
            string kod2 = null;
            string bank2 = null;
            string konto2 = "111111111111111";
            int result2 = firmy2.SaveDetails(nazwa2, adres2, miasto2, kod2, bank2, konto2);


            Assert.IsTrue(result2 <= 0);
        }
    }
}