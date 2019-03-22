using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
namespace Prog2
{
    public partial class TesterDateBase
    {
        [TestMethod]
        public void __102_ConstructeurCalendrier()
        {
            var c = new Calendrier(1582, Mois.Décembre);
            AreEqual(1582, c.Année);
            AreEqual(Mois.Décembre, c.Mois);

            c = new Calendrier(9999, Mois.Janvier);
            AreEqual(9999, c.Année);
            AreEqual(Mois.Janvier, c.Mois);

            ThrowsException<ArgumentOutOfRangeException>(() => new Calendrier(1581, Mois.Décembre));
            ThrowsException<ArgumentOutOfRangeException>(() => new Calendrier(10000, Mois.Janvier));
            ThrowsException<ArgumentOutOfRangeException>(() => new Calendrier(2000, default(Mois)));
            ThrowsException<ArgumentOutOfRangeException>(() => new Calendrier(2000, Mois.Décembre + 1));
        }

    }
}
