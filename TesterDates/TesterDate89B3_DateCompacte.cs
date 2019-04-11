using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using System.Reflection;

namespace Prog2
{
    public partial class TesterDateBase
    {
        [TestMethod]
        public void _89B3_DateCompacte()
        {
            var fields = typeof(Mois).GetFields(
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            AreEqual(1, fields.Length);
            AreEqual(typeof(int), fields[0].FieldType);
        }

    }
}
