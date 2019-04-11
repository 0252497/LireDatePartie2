using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using static Prog2.IntUtil;

namespace Prog2
{
    [TestClass]
    public partial class TesterIntUtil
    {
        [TestMethod]
        public void _01_ComparerAvec()
        {
            AreEqual(1, 10.ComparerAvec(9));
            AreEqual(0, 10.ComparerAvec(10));
            AreEqual(-1, 10.ComparerAvec(11));
        }
    }
}
