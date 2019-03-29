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
        public void __126_ClonageDateConstante()
        {
            Date date = new Date(2001, 9, 11);
            Date dateConst = new DateConstante(2001, 9, 11);
            Date cloneConst = dateConst.Cloner(1999, 8);
            AreEqual("Date", date.Cloner().GetType().Name);
            AreEqual("DateConstante", cloneConst.GetType().Name);
            AreEqual("1999-08-11", cloneConst.ToString());
            ThrowsException<ArgumentOutOfRangeException>(() => dateConst.Cloner(1999, 2, 31));
        }

    }
}
