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
using System.IO;

namespace Prog2
{
    static class AfficherDates
    {
        static void Main(string[] args)
        {
            string nomFichier = "MonFichier.txt";

            try
            {
                nomFichier = MainSwitch(args, nomFichier);
            }
            catch(ArgumentException ex)
            {
                MessageErreur(ex.Message);
            }
            catch (FileNotFoundException exception)
            {
                MessageErreur($"Le nom '{nomFichier}' est introuvable.");
                ColorWriteLine(Magenta, "\nMESSAGE:\n{0}", exception.Message);
                ColorWriteLine(Yellow, "\nSTACK TRACE:\n{0}", exception.StackTrace);
            }
        }

        private static string MainSwitch(string[] args, string nomFichier)
        {
            var texte = "bidon";

            switch (args.Length)
            {
                case 0:
                    // --- Aucun argument, on se rabat sur l'anicien programme ---
                    texte = File.ReadAllText(nomFichier);
                    ColorWriteLine(DarkCyan, texte);
                    AncienMain();
                    break;

                case 1:
                    // --- On affiche le contenu du fichier spécifié en argument ---
                    nomFichier = args[0];
                    texte = File.ReadAllText(nomFichier);
                    ColorWriteLine(Magenta, texte);
                    break;

                default:
                    // --- Message d'usage ---
                    ColorWriteLine(Yellow, "USAGE : AfficherDate [NomFichier]");
                    break;
            }

            return nomFichier;
        }

        private static void AncienMain()
        {
            var badAttentatWTC = New(11, 09, 2001);

            // Parfaitement équivalent :
            var D1 = New(année: 2001, mois: 09, jour: 11);
            var D2 = New(jour: 11, mois: 09, année: 2001);
            var D3 = New(mois: 09, jour: 11, année: 2001);
            var D4 = New(2001, jour: 11, mois: 09);

            // Pour vérifier nos affichages!
            Title = "AfficherDates";
            ColorWriteLine(Green, "Attentat du WTC:\t{0}", EnTexte(DateAttentatWTC));
            ColorWriteLine(Yellow, "\nMort de MJ:\t\t{0}", EnTexte(DateDecesMJ, "/"));
            ColorWriteLine(Cyan, "\nExplosion de la NC:\t{0}", EnTexte(DateExplosionNC, "."));

            var aprèsDemain = New(
                DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
            var avantHier = New(
                DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);

            ColorWriteLine(Magenta, "\nAvant-hier:\t\t{0}", avantHier.Décrémenter(2).EnTexteLong());
            ColorWriteLine(Yellow, "Hier:\t\t\t{0}", Hier().EnTexteLong());
            ColorWriteLine(Green, "Aujourd'hui:\t\t{0}", Aujourdhui().EnTexteLong());
            ColorWriteLine(Cyan, "Demain:\t\t\t{0}", Demain().EnTexteLong());
            ColorWriteLine(Magenta, "Après-demain:\t\t{0}", aprèsDemain.Incrémenter(2).EnTexteLong());

            Poursuivre();
        }
    }
}
