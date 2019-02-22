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
        public string TL(int année, int mois, int jour)
            => D(année, mois, jour).EnTexteLong();

        [TestMethod]
        public void _55_EnTexteLong()
        {
            AreEqual("31 décembre 1999", TL(1999, 12, 31));
            AreEqual("1 janvier 888", TL(888, 1, 1));
        }

    }
}
