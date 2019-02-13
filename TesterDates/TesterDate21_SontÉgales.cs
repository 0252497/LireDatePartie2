using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using static Prog2.Date;


namespace Prog2
{

    public partial class TesterDateBase
    {
        [TestMethod]
        public void _21_SontÉgales()
        {
            var D1 = D(2001, 9, 11);
            var D2 = D(2001, 9, 11);
            var D3 = D(2002, 9, 11);
            var D4 = D(2001, 8, 11);
            var D5 = D(2001, 9, 10);

            IsTrue(SontÉgales(D1, D2));
            IsFalse(SontÉgales(D1, D3));
            IsFalse(SontÉgales(D1, D4));
            IsFalse(SontÉgales(D1, D5));

            //IsFalse(SontÉgales(D1, null));
            //IsFalse(SontÉgales(null, D1));
            //IsFalse(SontÉgales(null, null));
        }

    }
}
