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
        public void _63_NuméroDuMois()
        {
            TesterNuméroDuMoisCommencePar(DateUtil.NuméroDuMois);
        }

    }
}
