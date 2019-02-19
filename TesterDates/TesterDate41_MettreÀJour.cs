using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using static Prog2.Date;


namespace Prog2
{

    public partial class TesterDateBase
    {
        [TestMethod]
        public void _41_MettreÀJour()
        {
            var D1 = D(2001, 9, 11);
            D1.MettreÀJour();
            AreEqual(DateTime.Today.Year, D1.Année);
            AreEqual(DateTime.Today.Month, D1.Mois);
            AreEqual(DateTime.Today.Day, D1.Jour);
        }

    }
}
