using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Prog2
{
    public partial class TesterDateBase
    {
        [TestMethod]
        public void _91_ComparerAvec()
        {
            AreEqual(0, D(1999, 12, 31).ComparerAvec(D(1999, 12, 31)));
            AreEqual(1, D(1999, 12, 31).ComparerAvec(D(1998, 12, 31)));
            AreEqual(-1, D(1999, 12, 31).ComparerAvec(D(2000, 12, 31)));
            AreEqual(1, D(1999, 12, 30).ComparerAvec(D(1999, 11, 30)));
            AreEqual(-1, D(1999, 11, 30).ComparerAvec(D(1999, 12, 30)));
            AreEqual(1, D(1999, 12, 31).ComparerAvec(D(1999, 12, 30)));
            AreEqual(-1, D(1999, 12, 30).ComparerAvec(D(1999, 12, 31)));
            AreEqual(1, D(2000, 1, 1).ComparerAvec(D(1999, 12, 31)));
            AreEqual(-1, D(1999, 12, 31).ComparerAvec(D(2000, 1, 1)));
        }

    }
}
