using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using System.Collections.Generic;
using System.Linq;


namespace Prog2
{

    public partial class TesterDateBase
    {
   
        [TestMethod]
        public void _81_EstNoël()
        {
            IsTrue(D(2001, 12, 25).EstNoël);
            IsFalse(D(2001, 12, 24).EstNoël);
            IsFalse(D(2001, 11, 25).EstNoël);
        }

        [TestMethod]
        public void _82_EstStJean()
        {
            IsTrue(D(2010, 6, 24).EstStJean);
            IsFalse(D(2010, 6, 25).EstStJean);
            IsFalse(D(2010, 5, 24).EstStJean);
        }

        [TestMethod]
        public void _83_EstJourDeLAn()
        {
            IsTrue(D(2019, 1, 1).EstJourDeLAn);
            IsFalse(D(2019, 1, 2).EstJourDeLAn);
            IsFalse(D(2019, 2, 1).EstJourDeLAn);
        }

        [TestMethod]
        public void _84_MoisTypéSet()
        {
            var date = D(2001, 9, 11);
            AreEqual(Mois.Septembre, date.MoisTypé);
            date.MoisTypé = Mois.Octobre;
            AreEqual(Mois.Octobre, date.MoisTypé);
            ThrowsException<ArgumentOutOfRangeException>(
                () => date.MoisTypé = (Mois)13);
        }

        [TestMethod]
        public void _85_JourDeLAnnéeGet()
        {
            AreEqual(1, D(2001, 1, 1).JourDeLAnnée);
            AreEqual(59, D(2001, 2, 28).JourDeLAnnée);
            AreEqual(365, D(2001, 12, 31).JourDeLAnnée);
            AreEqual(366, D(2004, 12, 31).JourDeLAnnée);
            AreEqual(304, D(2001, 10, 31).JourDeLAnnée);
            AreEqual(305, D(2004, 10, 31).JourDeLAnnée);
        }

        [TestMethod]
        public void _86_JourDeLAnnéeSet()
        {
            var d = D(2001, 1, 10);
            AreEqual(10, d.JourDeLAnnée);
            d.JourDeLAnnée = 1;
            AreEqual(1, d.JourDeLAnnée);
            d.JourDeLAnnée = 59;
            AreEqual(59, d.JourDeLAnnée);
            AreEqual("2001-02-28", Date.EnTexte(d));
            d.JourDeLAnnée = 304;
            AreEqual(304, d.JourDeLAnnée);
            AreEqual("2001-10-31", Date.EnTexte(d));
            d.Année = 2004;
            d.JourDeLAnnée = 305;
            AreEqual(305, d.JourDeLAnnée);
            AreEqual("2004-10-31", Date.EnTexte(d));
            ThrowsException<ArgumentOutOfRangeException>(
                () => d.JourDeLAnnée = 0);
            ThrowsException<ArgumentOutOfRangeException>(
                () => d.JourDeLAnnée = 400);
        }

        //[TestMethod]
        //public void _87B_FailleDeSécurité()
        //{
        //    var d = D(2004, 2, 29);
        //    ThrowsException<ArgumentOutOfRangeException>(
        //        () => d.Année = 2003);
        //    d = D(2004, 3, 31);
        //    ThrowsException<ArgumentOutOfRangeException>(
        //        () => d.Mois = 4);
        //}



    }
}
