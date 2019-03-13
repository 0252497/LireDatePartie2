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
        [TestMethod]
        public void _25_EnTexte__DateParDéfaut()
        {
            AreEqual(EnTexte(Aujourdhui), EnTexte());
            AreEqual(EnTexte(Aujourdhui, "."), EnTexte(séparateur:"."));
        }

    }
}
