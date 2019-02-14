using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using static Prog2.Date;


namespace Prog2
{

    public partial class TesterDateBase
    {
        [TestMethod]
        public void _31_EstBissextile()
        {
            foreach(var année in new[] { 1600, 1996, 2000, 2016, 2020, 2024, 2400, })
            {
                IsTrue(année.EstBissextile(), $"L'année {année} est bissextile");

            }
            foreach (var année in new[] { 1000, 1900, 1999, 2001, 2019, 2100, 2200, 3000 })
            {
                IsFalse(année.EstBissextile(), $"L'année {année} n'est pas bissextile");
            }
        }

    }
}
