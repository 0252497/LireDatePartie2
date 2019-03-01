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
        public void _61_MoisTypé()
        {
            AreEqual(Mois.Janvier, D(2001, 01, 01).MoisTypé());
            AreEqual(Mois.Décembre, D(2001, 12, 01).MoisTypé());
        }

    }
}
