using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Prog2
{
    public partial class TesterIEnumerableUtil
    {
        [TestMethod]
        public void _02_Jusqua()
        {
            // Fonctionnement attendu
            AreEqual("10", 10.Jusqua(10).EnTexte());
            AreEqual("10", 10.Jusqua(10, 2).EnTexte());
            AreEqual("10 11 12 13", 10.Jusqua(13).EnTexte());
            AreEqual("10 15 20 25", 10.Jusqua(29, 5).EnTexte());
            AreEqual("", 10.Jusqua(13, -2).EnTexte());
            AreEqual("10 9 8 7", 10.Jusqua(7).EnTexte());
            AreEqual("10 7 4 1", 10.Jusqua(0, -3).EnTexte());
            AreEqual("", 10.Jusqua(0, 3).EnTexte());

            // Avez-vous vraiment codé avec une fonction génératrice?
            var jusqua = 10.Jusqua(20);
            IsNotInstanceOfType(jusqua, typeof(ICollection<int>));
            IsTrue(jusqua.GetType().Name.StartsWith("<Jusqua>"));
        }

    }
}
