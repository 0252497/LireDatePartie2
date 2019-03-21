using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
namespace Prog2
{
    public partial class TesterDateBase
    {
        [TestMethod]
        public void __101_JourDeLaSemaine()
        {
            AreEqual("Lundi", D(1867, 07, 01).JourDeLaSemaine.ToString());
            AreEqual("Mardi", D(2001, 09, 11).JourDeLaSemaine.ToString());
            AreEqual("Jeudi", D(2001, 02, 01).JourDeLaSemaine.ToString());
            AreEqual("Vendredi", D(1999, 12, 31).JourDeLaSemaine.ToString());
            AreEqual("Samedi", D(2000, 01, 01).JourDeLaSemaine.ToString());
        }

    }
}
