using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using static Prog2.Date;


namespace Prog2
{

    public partial class TesterDateBase
    {
        [TestMethod]
        public void _24_Aujourdhui()
        {
            var D1 = Aujourdhui;
            var D2 = Aujourdhui;
            IsTrue(D1 == D2, "Il faut retourner le même objet");
            AreEqual(DateTime.Today.Year, D1.Année);
            AreEqual(DateTime.Today.Month, D1.Mois);
            AreEqual(DateTime.Today.Day, D1.Jour);
        }

    }
}
