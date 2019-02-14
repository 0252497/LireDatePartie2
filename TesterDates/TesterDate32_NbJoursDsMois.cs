using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using static Prog2.Date;


namespace Prog2
{

    public partial class TesterDateBase
    {
        [TestMethod]
        public void _32_NbJoursDsMois()
        {
            int nbJours(int année, int mois)
                => année.NbJoursDsMois(mois);

            foreach(var mois in new[] { 1, 3, 5, 7, 8, 10, 12})
            {
                AreEqual(31, nbJours(2000,mois), $"Le mois {mois} a 31 jours");
            }
            foreach (var mois in new[] { 4, 6, 9, 11 })
            {
                AreEqual(30, nbJours(2000,mois), $"Le mois {mois} a 30 jours");
            }
            foreach (var année in new[] { 1600, 1996, 2000, 2016, 2020, 2024, 2400, })
            {
                AreEqual(29, nbJours(année,2), $"En {année}, février à 29 jours");
            }
            foreach (var année in new[] { 1000, 1900, 1999, 2001, 2019, 2100, 2200, 3000 })
            {
                AreEqual(28, nbJours(année,2), $"En {année}, février à 28 jours");
            }
            foreach (var mois in new[] { -100, -1, 0, 13, 14, 100 })
            {
                AreEqual(0, nbJours(2000, mois), $"Le mois {mois} n'existe pas");
            }
        }

    }
}
