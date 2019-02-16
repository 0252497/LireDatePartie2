using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using static Prog2.Date;

namespace Prog2
{

    public partial class TesterDateBase
    {
        [TestMethod]
        public void _33_EstValide()
        {
            void estValide(int année, int mois, int jour)
            {
                IsTrue(EstValide(année, mois, 1));
                IsTrue(EstValide(année, mois, jour));
                IsTrue(!EstValide(année, mois, 0));
                IsTrue(!EstValide(année, mois, jour+1));
            }

            foreach (var mois in new[] { 1, 3, 5, 7, 8, 10, 12})
            {
                estValide(2000, mois, 31);
            }
            foreach (var mois in new[] { 4, 6, 9, 11 })
            {
                estValide(2000, mois, 30);
            }
            foreach (var année in new[] { 1600, 1996, 2000, 2016, 2020, 2024, 2400, })
            {
                estValide(année, 2, 29);
            }
            foreach (var année in new[] { 1000, 1900, 1999, 2001, 2019, 2100, 2200, 3000 })
            {
                estValide(année, 2, 28);
            }
            foreach (var mois in new[] { -100, -1, 0, 13, 14, 100 })
            {
                IsTrue(!EstValide(2000, mois, 1));
            }
        }

    }
}
