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
        public string Déc(int année, int mois, int jour, int déc = 1)
        {
            var d = D(année, mois, jour);
            d.Décrémenter(déc);
            return EnTexte(d);
        }

        [TestMethod]
        public void _44_Décrémenter()
        {
            AreEqual("1999-01-01", Déc(1999, 01, 02));
            AreEqual("1999-01-30", Déc(1999, 01, 31));
            AreEqual("1999-01-31", Déc(1999, 02, 01));
            AreEqual("1999-04-30", Déc(1999, 05, 01));
            AreEqual("1999-02-28", Déc(1999, 03, 01));
            AreEqual("2000-02-28", Déc(2000, 02, 29));
            AreEqual("2000-02-29", Déc(2000, 03, 01));
            AreEqual("1999-12-31", Déc(2000, 01, 01));
        }

        [TestMethod]
        public void _45_DécrémenterPlus()
        {
            AreEqual("1999-01-01", Déc(1999, 01, 01, 0));
            AreEqual("1999-01-01", Déc(1999, 01, 02, 1));
            AreEqual("1999-01-01", Déc(1999, 01, 03, 2));
            AreEqual("1999-01-01", Déc(1999, 02, 01, 31));
            AreEqual("1999-01-01", Déc(1999, 03, 01, 59));
            AreEqual("1999-01-01", Déc(1999, 04, 01, 90));
            AreEqual("1999-01-01", Déc(1999, 05, 01, 120));
            AreEqual("1999-01-01", Déc(2000, 01, 01, 365));
            AreEqual("1999-01-01", Déc(2001, 01, 01, 365 + 366));
        }



    }
}
