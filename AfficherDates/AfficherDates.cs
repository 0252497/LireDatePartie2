/* Programme qui fait afficher diverses dates. */
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
using static Prog2.Date;

namespace Prog2
{
    static class AfficherDates
    {
        static void Main(string[] args)
        {
            var badAttentatWTC = New(11, 09, 2001);

            // Parfaitement équivalent :
            var D1 = New(année: 2001, mois: 09, jour: 11);
            var D2 = New(jour: 11, mois: 09, année: 2001);
            var D3 = New(mois: 09, jour: 11, année: 2001);
            var D4 = New(2001, jour: 11, mois: 09);

            // Pour vérifier nos affichages!
            Title = "AfficherDates";
            ColorWriteLine(Green, "\nAttentat du WTC:\t{0}", EnTexte(DateAttentatWTC));
            ColorWriteLine(Yellow, "\nMort de MJ:\t\t{0}", EnTexte(DateDecesMJ, "/"));
            ColorWriteLine(Cyan, "\nExplosion de la NC:\t{0}", EnTexte(DateExplosionNC, "."));
            
            var aprèsDemain = New(
                DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
            var avantHier = New(
                DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
            var hier = Hier();
            var demain = Demain();

            ColorWriteLine(Blue, "\nAvant-hier:\t\t{0}", avantHier.Décrémenter(2).EnTexteLong());
            ColorWriteLine(DarkYellow, "Hier:\t\t\t{0}", Hier().EnTexteLong());
            ColorWriteLine(Magenta, "Aujourd'hui:\t\t{0}", aujourdhui.EnTexteLong());
            ColorWriteLine(DarkBlue, "Demain:\t\t\t{0}", Demain().EnTexteLong());
            ColorWriteLine(DarkMagenta, "Après-demain:\t\t{0}", aprèsDemain.Incrémenter(2).EnTexteLong());

            Poursuivre();
        }
    }
}
