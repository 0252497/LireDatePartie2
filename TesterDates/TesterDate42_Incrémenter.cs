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
        string Inc(int année, int mois, int jour)
        {
            var d = D(année, mois, jour);
            d.Incrémenter();
            return EnTexte(d);
        }

        [TestMethod]
        public void _42_Incrémenter()
        {
            AreEqual("1999-01-02", Inc(1999, 01, 01));
            AreEqual("1999-01-31", Inc(1999, 01, 30));
            AreEqual("1999-02-01", Inc(1999, 01, 31));
            AreEqual("1999-05-01", Inc(1999, 04, 30));
            AreEqual("1999-03-01", Inc(1999, 02, 28));
            AreEqual("2000-02-29", Inc(2000, 02, 28));
            AreEqual("2000-03-01", Inc(2000, 02, 29));
            AreEqual("2000-01-01", Inc(1999, 12, 31));
        }

    }
}
