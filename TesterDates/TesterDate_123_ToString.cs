using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
namespace Prog2
{
    public partial class TesterDateBase
    {
        [TestMethod]
        public void __123a_DateToString()
        {
            AreEqual("1999-02-03", D(1999,2,3).ToString());
        }

        [TestMethod]
        public void __123b_CalendrierToString()
        {
            AreEqual("Calendrier Août 1999", new Calendrier(1999, Mois.Août).ToString());
        }

    }
}
