using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using static Prog2.Date;


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

            IsFalse(D1 == Cloner(D1), "Cloner doit créer un nouvel objet");
            IsTrue(SontÉgales(D1, Cloner(D1)));
            IsTrue(SontÉgales(D3, Cloner(D1, année: 2002)));
            IsTrue(SontÉgales(D4, Cloner(D1, mois: 8)));
            IsTrue(SontÉgales(D5, Cloner(D1, jour: 10)));
            IsTrue(SontÉgales(D6, Cloner(D1, année: 2002, jour: 10)));
            IsTrue(SontÉgales(D7, Cloner(D1, année: 2002, mois: 8, jour: 10)));
        }

    }
}
