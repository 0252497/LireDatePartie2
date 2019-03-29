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
        public void _89B2_DateImmutable()
        {
            var immutable = new Date(2001, 9, 11, false);
            ThrowsException<InvalidOperationException>(() => immutable.Année = 2000);
            ThrowsException<InvalidOperationException>(() => immutable.Mois = 10);
            ThrowsException<InvalidOperationException>(() => immutable.MoisTypé = Mois.Août);
            ThrowsException<InvalidOperationException>(() => immutable.Jour = 5);
            ThrowsException<InvalidOperationException>(() => immutable.JourDeLAnnée = 155);
            ThrowsException<InvalidOperationException>(() => immutable.Incrémenter());
            ThrowsException<InvalidOperationException>(() => immutable.Décrémenter());
            ThrowsException<InvalidOperationException>(() => immutable.MettreÀJour());
            immutable.EstMutable = true;
            immutable.Année = 2002;
            immutable = new Date("2001-09-11", false);
            ThrowsException<InvalidOperationException>(() => immutable.Année = 2000);
            immutable = new Date(2001, Mois.Septembre, 11, false);
            ThrowsException<InvalidOperationException>(() => immutable.Année = 2000);
            immutable = Date.New(2001, Mois.Septembre, 11, false);
            ThrowsException<InvalidOperationException>(() => immutable.Année = 2000);
        }

    }
}
