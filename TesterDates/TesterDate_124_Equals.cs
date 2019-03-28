using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
namespace Prog2
{
    public partial class TesterDateBase
    {
        [TestMethod]
        public void __124a_DateEquals()
        {
            AreEqual(D(1999, 2, 3), D(1999,2,3));
            AreNotEqual(D(1999, 2, 4), D(1999, 2, 3));
            AreNotEqual(D(1999, 4, 3), D(1999, 2, 3));
            AreNotEqual(D(1998, 2, 3), D(1999, 2, 3));
        }

        [TestMethod]
        public void __124b_DateGetHashCode()
        {
            AreEqual(D(1999, 2, 3).GetHashCode(), D(1999, 2, 3).GetHashCode());
            AreNotEqual(D(1999, 2, 4).GetHashCode(), D(1999, 2, 3).GetHashCode());
            AreNotEqual(D(1999, 4, 3).GetHashCode(), D(1999, 2, 3).GetHashCode());
            AreNotEqual(D(1998, 2, 3).GetHashCode(), D(1999, 2, 3).GetHashCode());
        }

        [TestMethod]
        public void __124c_CalendrierEquals()
        {
            AreEqual(new Calendrier(1999, Mois.Août), new Calendrier(1999, Mois.Août));
            AreNotEqual(new Calendrier(1999, Mois.Mars), new Calendrier(1999, Mois.Août));
            AreNotEqual(new Calendrier(1998, Mois.Août), new Calendrier(1999, Mois.Août));
            IsTrue(new Calendrier(1999, Mois.Août) == new Calendrier(1999, Mois.Août));
            IsFalse(new Calendrier(1999, Mois.Août) != new Calendrier(1999, Mois.Août));
        }

        [TestMethod]
        public void __124d_CalendrierGetHashCode()
        {
            AreEqual(new Calendrier(1999, Mois.Août).GetHashCode(), new Calendrier(1999, Mois.Août).GetHashCode());
            AreNotEqual(new Calendrier(1999, Mois.Mars).GetHashCode(), new Calendrier(1999, Mois.Août).GetHashCode());
            AreNotEqual(new Calendrier(1998, Mois.Août).GetHashCode(), new Calendrier(1999, Mois.Août).GetHashCode());
        }

    }
}
