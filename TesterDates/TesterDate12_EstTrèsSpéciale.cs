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
            IsTrue(D(2001, 01, 01).EstTrèsSpéciale());
            IsTrue(D(2012, 12, 12).EstTrèsSpéciale());
            IsTrue(D(1905, 05, 05).EstTrèsSpéciale());
            IsTrue(D(808, 08, 08).EstTrèsSpéciale());
        }

    }
}
