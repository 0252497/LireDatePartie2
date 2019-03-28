using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
namespace Prog2
{
    public partial class TesterDateBase
    {
        [TestMethod]
        public void __122_Dupliquer()
        {
            Date date = D(2001, 9, 11);
            Date clone = date.Dupliquer(); 
            AreEqual(date.EnTexteLong(), clone.EnTexteLong());
            IsFalse(clone == date);
        }

    }
}
