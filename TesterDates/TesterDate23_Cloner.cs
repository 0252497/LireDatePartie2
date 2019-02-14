using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using static Prog2.Date;
using static Prog2.DateUtil;

namespace Prog2
{

    public partial class TesterDateBase
    {
        [TestMethod]
        public void _23_Cloner()
        {
            var D1 = D(2001, 9, 11);
            var D2 = D(2001, 9, 11);
            var D3 = D(2002, 9, 11);
            var D4 = D(2001, 8, 11);
            var D5 = D(2001, 9, 10);
            var D6 = D(2002, 9, 10);
            var D7 = D(2002, 8, 10);

            IsFalse(D1 == D1.Cloner(), "Cloner doit créer un nouvel objet");
            IsTrue(SontÉgales(D1, D1.Cloner()));
            IsTrue(SontÉgales(D3, D1.Cloner()));
            IsTrue(SontÉgales(D4, D1.Cloner()));
            IsTrue(SontÉgales(D5, D1.Cloner()));
            IsTrue(SontÉgales(D6, D1.Cloner()));
            IsTrue(SontÉgales(D7, D1.Cloner()));
        }

    }
}
