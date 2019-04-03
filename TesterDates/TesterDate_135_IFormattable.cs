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
        public void __135_IFormattable()
        {
            IsTrue(new Date() is IFormattable);

            var d = D(1999, 1, 12);
            AreEqual("1999-01-12", $"{d:G}");
            AreEqual("1999-01-12", $"{d:-}");
            AreEqual("1999-01-12", $"{d}");
            AreEqual("12 janvier 1999", $"{d:L}");
            AreEqual("1999 01 12", $"{d:S}");
            AreEqual("1999.01.12", $"{d:.}");
            AreEqual("1999/01/12", $"{d:/}");
            ThrowsException<FormatException>(() => $"{d:Z}");
        }

    }
}
