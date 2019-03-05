using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Prog2
{
    [TestClass]
    public class TesterBoolUtil
    {
        [TestMethod]
        public void _01_OuiNon()
        {
            AreEqual("oui", true.OuiNon());
            AreEqual("non", false.OuiNon());
        }

        [TestMethod]
        public void _02_VraiFaux()
        {
            AreEqual("vrai", true.VraiFaux());
            AreEqual("faux", false.VraiFaux());
        }

        [TestMethod]
        public void _03_TryParseBool()
        {
            foreach(var mot in new[] { "vrai", "v", "oui", "o", "yes", "y", "true", "t", "1", "Vrai", "VRAI", " vrai "})
            {
                IsTrue(mot.TryParseBool(out bool b), $"<{mot}> est un booléen valide");
                IsTrue(b, $"<{mot}> est vrai, pas faux");
            }
            foreach (var mot in new[] { "faux", "f", "non", "n", "no", "false", "0", "FAUX", " faux " })
            {
                IsTrue(mot.TryParseBool(out bool b));
                IsFalse(b, $"<{mot}> est faux, pas vrai");
            }
            foreach (var mot in new[] { "fau", "", "vraie", "2"})
            {
                IsFalse(mot.TryParseBool(out bool _), $"<{mot}> est un booléen invalide");
            }
        }

    }
}
