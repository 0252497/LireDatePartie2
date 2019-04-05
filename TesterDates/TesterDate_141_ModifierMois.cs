using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using System.Collections.Generic;
using System.Linq;


namespace Prog2
{

    public partial class TesterDateBase
    {
        [TestMethod]
        public void __141_ModifierMois()
        {
            var d = D(1999, 1, 12);
            var dd = d.ModifierMois(mois => mois + 5);
            AreEqual(6, d.Mois);

            // Une méthode fluide doit retourner this.
            AreSame(d, dd);

            // Le mois modifié doit donner une date valide
            ThrowsException<ArgumentOutOfRangeException>(
                () => d.ModifierMois(mois => mois - 100));

            // DateConstante n'est pas modifiable!
            ThrowsException<DateConstanteException>(
                () => new DateConstante(1999, 1, 12).ModifierMois(mois => mois + 1));
        }

    }
}
