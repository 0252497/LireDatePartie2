using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
namespace Prog2
{
    public partial class TesterDateBase
    {
        static string TT(object o) => DateUtil.EnTexte(o).ToLower();

        [TestMethod]
        public void __111_EnTexteObject()
        {
            AreEqual("3", TT(3));
            AreEqual("null", TT(null));
            AreEqual("oui", TT(true));
            AreEqual("non", TT(false));
            AreEqual("12 septembre 2001", TT(new Date(2001, 09, 12)));
            AreEqual("calendrier septembre 2001", TT(new Calendrier(2001, Mois.Septembre)));
        }

    }
}
