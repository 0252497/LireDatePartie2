using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
namespace Prog2
{
    public partial class TesterDateBase
    {
        [TestMethod]
        public void __104_LocaliserDateDansCalendrier()
        {
            var cal = new Calendrier(2001, Mois.Septembre);
            int rangée, colonne;
            IsFalse(cal.Localiser(null, out rangée, out colonne));
            IsFalse(cal.Localiser(new Date(2001, 08, 31), out rangée, out colonne));
            IsFalse(cal.Localiser(new Date(2001, 10, 01), out rangée, out colonne));
            IsTrue(cal.Localiser(new Date(2001, 09, 01), out rangée, out colonne));
            AreEqual(0, rangée);
            AreEqual(6, colonne);
            IsTrue(cal.Localiser(new Date(2001, 09, 30), out rangée, out colonne));
            AreEqual(5, rangée);
            AreEqual(0, colonne);
            IsTrue(cal.Localiser(new Date(2001, 09, 12), out rangée, out colonne));
            AreEqual(2, rangée);
            AreEqual(3, colonne);
        }

    }
}
