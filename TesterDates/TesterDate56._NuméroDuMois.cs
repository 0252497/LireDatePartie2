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
        public void _56a_NuméroDuMois1()
        {
            TesterNuméroDuMois(NuméroDuMois1);
            AreEqual(0, NuméroDuMois1("Janvier"));
        }

        [TestMethod]
        public void _56b_NuméroDuMois2()
        {
            TesterNuméroDuMois(NuméroDuMois2);
            AreEqual(0, NuméroDuMois2("Janvier"));
        }

        [TestMethod]
        public void _56c_NuméroDuMois3()
        {
            TesterNuméroDuMoisInsemsibleÀLaCasse(NuméroDuMois3);
            AreEqual(0, NuméroDuMois3("decembre"));
        }

    }
}
