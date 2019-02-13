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
        public string T(int année, int mois, int jour)
            => EnTexte(D(année, mois, jour ));

        [TestMethod]
        public void _11_EnTexte()
        {
            AreEqual("1999-12-31", T(1999, 12, 31));
            AreEqual("1999-01-01", T(1999, 1, 1));
            AreEqual("0888-01-01", T(888, 1, 1));
        }

    }
}
