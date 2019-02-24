using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using System.Collections.Generic;
using System.Linq;
using static Prog2.NomsDesMois;


namespace Prog2
{

    public partial class TesterDateBase
    {

 
        [TestMethod]
        public void _56d_NuméroDuMois4()
        {
            TesterNuméroDuMoisInsemsibleAuxAccents(NuméroDuMois4);
            AreEqual(0, NuméroDuMois4("déc"));
        }

    }
}
