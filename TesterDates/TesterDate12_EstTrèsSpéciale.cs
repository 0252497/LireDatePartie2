using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using static Prog2.DateUtil;
using static Prog2.Date;


namespace Prog2
{

    public partial class TesterDateBase
    {

        [TestMethod]
        public void _12_EstTrèsSpéciale()
        {
            IsTrue(EstTrèsSpéciale(D(2001, 01, 01)));
            IsTrue(EstTrèsSpéciale(D(2012, 12, 12)));
            IsTrue(EstTrèsSpéciale(D(1905, 05, 05)));
            IsTrue(EstTrèsSpéciale(D(808, 08, 08)));
        }

    }
}
