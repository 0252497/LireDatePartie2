using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using System.Collections.Generic;
using System.Linq;
using static Prog2.DateUtil;
using static Prog2.Date;


namespace Prog2
{

    public partial class TesterDateBase
    {

        string Inc(int année, int mois, int jour, int inc)
        {
            var d = D(année, mois, jour);
            d.Incrémenter(inc);
            return EnTexte(d);
        }

        [TestMethod]
        public void _43_IncrémenterPlus()
        {
            AreEqual("1999-01-01", Inc(1999, 01, 01, 0));
            AreEqual("1999-01-02", Inc(1999, 01, 01, 1));
            AreEqual("1999-01-03", Inc(1999, 01, 01, 2));
            AreEqual("1999-02-01", Inc(1999, 01, 01, 31));
            AreEqual("1999-03-01", Inc(1999, 01, 01, 59));
            AreEqual("1999-04-01", Inc(1999, 01, 01, 90));
            AreEqual("1999-05-01", Inc(1999, 01, 01, 120));
            AreEqual("2000-01-01", Inc(1999, 01, 01, 365));
            AreEqual("2001-01-01", Inc(1999, 01, 01, 365+366));
        }

    }
}
