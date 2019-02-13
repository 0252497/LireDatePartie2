using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using static Prog2.Date;


namespace Prog2
{

    public partial class TesterDateBase
    {

        public string T(int année, int mois, int jour, string sép)
            => EnTexte(D(année, mois, jour), sép);

        [TestMethod]
        public void _22_EnTexte__AvecSéparateur()
        {
            AreEqual("1999.12.31", T(1999, 12, 31, "."));
            AreEqual("1999/01/01", T(1999, 1, 1, "/"));
            AreEqual("08880101", T(888, 1, 1, ""));
        }

    }
}
