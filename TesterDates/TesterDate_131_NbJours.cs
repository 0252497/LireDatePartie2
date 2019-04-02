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
        public void __131_NbJours()
        {
            AreEqual(31, (new Calendrier(2000, Mois.Janvier) as ICalendrier).NbJours);
            AreEqual(29, (new Calendrier(2000, Mois.Février) as ICalendrier).NbJours);
            AreEqual(30, (new Calendrier(2000, Mois.Avril) as ICalendrier).NbJours);
        }

    }
}
