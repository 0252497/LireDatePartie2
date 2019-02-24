using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using System.Collections.Generic;
using System.Linq;


namespace Prog2
{

    public partial class TesterDateBase
    {
        static int NoMois(string strMois)
        {
            if (DateUtil.TryParseMois(strMois, out int mois))
                return mois;
            return 0;
        }

        [TestMethod]
        public void _57_TryParseMois()
        {
            TesterNuméroDuMoisCommencePar(NoMois);
            AreEqual(1, NoMois("1"));
            AreEqual(12, NoMois("12"));
            AreEqual(0, NoMois("13"));
            AreEqual(0, NoMois("0"));
            AreEqual(0, NoMois("-2"));
            AreEqual(12, NoMois(" 12 "));
            AreEqual(0, NoMois("  "));
        }

    }
}
