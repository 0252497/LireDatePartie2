using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Prog2.ConsolePlus;
using static System.Console;
using static System.ConsoleColor;
using System.Diagnostics;
using static Prog2.DateUtil;

namespace Prog2
{
    static class AfficherDates
    {
        static void Main(string[] args)
        {
            var badAttentatWTC = Date.New(11, 09, 2001);

            // Parfaitement équivalent :
            var D1 = Date.New(année: 2001, mois: 09, jour: 11);
            var D2 = Date.New(jour: 11, mois: 09, année: 2001);
            var D3 = Date.New(mois: 09, jour: 11, année: 2001);
            var D4 = Date.New(2001, jour: 11, mois: 09);

            // Parfaitement équivalent? ok on va valider ça!
            Debug.Assert(Date.SontÉgales(dateAttentatWTC, D1));
            Debug.Assert(Date.SontÉgales(dateAttentatWTC, D2));
            Debug.Assert(Date.SontÉgales(dateAttentatWTC, D3));
            Debug.Assert(Date.SontÉgales(dateAttentatWTC, D4));
            Debug.Assert(!Date.SontÉgales(dateAttentatWTC, badAttentatWTC));

            // Pour vérifier nos affichages!
            Title = "AfficherDates";
            ColorWriteLine(Green, "\nAttentat du WTC:\t{0}", Date.EnTexte(dateAttentatWTC, "/"));
            ColorWriteLine(Yellow, "\nMort de MJ:\t\t{0}", Date.EnTexte(dateDecesMJ, "/"));
            ColorWriteLine(Cyan, "\nExplosion de la NC:\t{0}", Date.EnTexte(dateExplosionNC, "/"));
            ColorWriteLine(Magenta, "\nAujourd'hui:\t\t{0}", Date.EnTexte());
            Poursuivre();
        }
    }
}
