using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Prog2
{
    [TestClass]
    public partial class TesterIEnumerableUtil
    {
        [TestMethod]
        public void _01_EnTexte()
        {
            var entiers = new[] { 1, 2, 3 };
            AreEqual("1 2 3", entiers.EnTexte());
            AreEqual("1 2 3", entiers.EnTexte(null));
            AreEqual("1-2-3", entiers.EnTexte("-"));
            AreEqual("1-2-3", entiers.EnTexte("-", null));
            AreEqual("1-2-3", entiers.EnTexte("-", null, null));
            AreEqual("[1-[2-[3", entiers.EnTexte("-", "["));
            AreEqual("[1]-[2]-[3]", entiers.EnTexte("-", "[", "]"));
            AreEqual("[1]-[2]-[3]", "123".EnTexte("-", "[", "]"));
        }

    }
}
