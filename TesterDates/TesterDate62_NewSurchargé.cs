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
        public void _62_NewSurchargé()
        {
            IsTrue(Date.SontÉgales(Date.New(2001, 01, 01), Date.New(2001, Mois.Janvier, 01)));
            IsTrue(Date.SontÉgales(Date.New(2001, 12, 01), Date.New(2001, Mois.Décembre, 01)));
        }

    }
}
