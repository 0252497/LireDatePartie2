using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using static Prog2.Date;

namespace Prog2
{

    public partial class TesterDateBase
    {
        [TestMethod]
        public void _34_New()
        {
            IsTrue(SontÉgales(D(2001, 9, 11), New(2001, 9, 11)));
            IsNull(New(2001, 9, 32));
        }

    }
}
