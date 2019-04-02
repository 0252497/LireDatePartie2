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
        public void __132_NbSemaines()
        {
            AreEqual(6, (new Calendrier(2019, Mois.Mars) as ICalendrier).NbSemaines);
            AreEqual(5, (new Calendrier(2019, Mois.Février) as ICalendrier).NbSemaines);
            AreEqual(4, (new Calendrier(2015, Mois.Février) as ICalendrier).NbSemaines);
        }

    }
}
