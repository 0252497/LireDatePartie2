using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using static Prog2.Date;


namespace Prog2
{

    public partial class TesterDateBase
    {
        [TestMethod]
        public void _46_Demain()
        {
            var demain = Demain();
            IsTrue(demain == Demain(), "Il faut retourner le même objet à chaque appel");
            var d2 = Aujourdhui();
            d2.Incrémenter();
            AreEqual(EnTexte(d2), EnTexte(demain));
        }

        [TestMethod]
        public void _47_Hier()
        {
            var hier = Hier();
            IsTrue(hier == Hier(), "Il faut retourner le même objet à chaque appel");
            var d2 = Aujourdhui();
            d2.Décrémenter();
            AreEqual(EnTexte(d2), EnTexte(hier));
        }

    }
}
