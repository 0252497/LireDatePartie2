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
        public void _87_Constructeurs()
        {
            var D1 = new Date(2001, 9, 11);
            var D2 = new Date(2001, Mois.Septembre, 11);
            var D3 = new Date("11 sept 2001");
            var D4 = Date.New(2001, 9, 11);
            var D5 = new Date { Année = 2001, Mois = 9, Jour = 11 };
            var D6 = new Date { Année = 2001, JourDeLAnnée = 254 };

            foreach(var date in new[] { D1, D2, D3, D4, D5, D6})
            {
                AreEqual("2001-09-11", Date.EnTexte(date));
            }
        }

        [TestMethod]
        public void _88_ConstructionsErronées()
        {
            ThrowsException<ArgumentOutOfRangeException>(()=>
                new Date(2018, 13, 1));
            ThrowsException<ArgumentOutOfRangeException>(() =>
                new Date(2018, (Mois)0, 1));
            ThrowsException<ArgumentException>(() =>
                new Date("2018-02-30"));
            ThrowsException<ArgumentOutOfRangeException>(() =>
                new Date { Mois = 13});
            ThrowsException<ArgumentOutOfRangeException>(() =>
                new Date { Jour = 32 });
        }



    }
}
