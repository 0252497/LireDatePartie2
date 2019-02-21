using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using System.Collections.Generic;
using System.Linq;
using static Prog2.DateUtil;
using static Prog2.Date;


namespace Prog2
{

    public partial class TesterDateBase
    {
        [TestMethod]
        public void _51_Fluidification()
        {
            var d = D(2001, 09, 11);
            AreSame(d, d.MettreÀJour());
            AreSame(d, d.Incrémenter());
            AreSame(d, d.Décrémenter());
        }

    }
}
