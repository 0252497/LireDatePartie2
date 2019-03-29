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
        public void __127_CacherJourDeLAnnée()
        {
            Date dateConst = new DateConstante(2000, 12, 31);
            for(int i = 0; i < 100000; i++)
                AreEqual(366, dateConst.JourDeLAnnée);
        }

    }
}
