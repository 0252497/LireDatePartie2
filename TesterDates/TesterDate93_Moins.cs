using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Prog2
{
    public partial class TesterDateBase
    {
        [TestMethod]
        public void _93_Moins()
        {
            AreEqual(0, Date.Aujourdhui.Moins(Date.Aujourdhui));
            AreEqual(1, Date.Demain.Moins(Date.Aujourdhui));
            AreEqual(2, Date.Demain.Moins(Date.Hier));
            AreEqual(-1, Date.Hier.Moins(Date.Aujourdhui));
            AreEqual(-2, Date.Hier.Moins(Date.Demain));
            AreEqual(360, D(2017, 8, 10).Moins(D(2016, 8, 15)));
            AreEqual(361, D(2017, 2, 10).Moins(D(2016, 2, 15)));
            AreEqual(-535976, D(1066, 8, 29).Moins(D(2534, 2, 10)));
        }

    }
}
