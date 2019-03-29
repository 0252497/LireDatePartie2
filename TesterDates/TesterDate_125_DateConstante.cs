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
        public void __125_DateConstante()
        {
            Date dateConst = new DateConstante(2001, 9, 11);
            ThrowsException<DateConstanteException>(() => dateConst.Année = 2000);
            ThrowsException<DateConstanteException>(() => dateConst.Mois = 10);
            ThrowsException<DateConstanteException>(() => dateConst.MoisTypé = Mois.Août);
            ThrowsException<DateConstanteException>(() => dateConst.Jour = 5);
            ThrowsException<DateConstanteException>(() => dateConst.JourDeLAnnée = 155);
            ThrowsException<DateConstanteException>(() => dateConst.Incrémenter());
            ThrowsException<DateConstanteException>(() => dateConst.Décrémenter());
            ThrowsException<DateConstanteException>(() => dateConst.MettreÀJour());
            IsTrue(DateUtil.DateAttentatWTC is DateConstante);
            IsTrue(DateUtil.DateDécèsMJ is DateConstante);
            IsTrue(DateUtil.DateExplosionNC is DateConstante);
        }

    }
}
