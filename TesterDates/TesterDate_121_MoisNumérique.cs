using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
namespace Prog2
{
    public partial class TesterDateBase
    {
        [TestMethod]
        public void __121_MoisNumérique()
        {
            AreEqual(3, new Calendrier(2019, Mois.Mars).MoisNumérique);
            AreEqual(11, new Calendrier(2019, Mois.Novembre).MoisNumérique);
        }

    }
}
