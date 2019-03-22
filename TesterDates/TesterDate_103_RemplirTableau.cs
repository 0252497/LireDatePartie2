using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
namespace Prog2
{
    public partial class TesterDateBase
    {
        static void testerTableauCalendrier(int année, Mois mois, int début, int fin)
        {
            int i = 1;
            var cal = new Calendrier(année, mois);
            for(int rangée = 0; rangée < Calendrier.NbRangées; rangée++)
                for(int colonne = 0; colonne < Calendrier.NbColonnes; colonne ++, i++)
                    AreEqual(i >= début && i <= fin ? i - début + 1 : 0, cal[rangée, colonne], 
                        $"calendrier[{rangée},{colonne}] ne doit pas égalé {cal[rangée, colonne]}");
        }

        [TestMethod]
        public void __103_RemplirTableau()
        {
            testerTableauCalendrier(2018, Mois.Décembre, 7, 37);
            testerTableauCalendrier(2019, Mois.Janvier, 3, 33);
            testerTableauCalendrier(2051, Mois.Janvier, 1, 31);
            testerTableauCalendrier(2001, Mois.Septembre, 7, 36);
        }

    }
}
