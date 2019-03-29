/* Programme qui fait afficher diverses dates. Si un fichier texte est passé en argument, le programme
 * analyse les dates contenues dans ce fichier et produit un fichier html descrivant les dates traitées.
 * Il permet aussi d'intercepter les exceptions qui pourraient survenir durant son exécution.
 * 
 * Auteure : Véronique Giguère
 * Création : 5 mars 2019
 */
using System;
using static Prog2.ConsolePlus;
using static System.Console;
using static System.ConsoleColor;
using static Prog2.DateUtil;
using static Prog2.Date;
using System.IO;

namespace Prog2
{
    static class AfficherDates
    {
        static void Main(string[] args)
        {
            string nomFichier = "Dates.txt";

            try
            {
                MainSwitch(args, ref nomFichier);
            }
            catch (FileNotFoundException)
            {
                MessageErreur($"Le nom '{nomFichier}' est introuvable.");
            }
            // --- catchall ---
            catch (Exception ex)
            #if DEBUG
            when (!ex.Message.StartsWith("##"))
            #endif
            {
                MessageErreur(ex.Message);
            }
        }

        private static void MainSwitch(string[] args, ref string nomFichier)
        {
            switch (args.Length)
            {
                case 0:
                    // --- Aucun argument, on se rabat sur l'ancien programme ---
                    AncienMain();
                    break;

                case 1:
                    // --- On affiche le contenu du fichier spécifié en argument ---
                    nomFichier = args[0];

                    string[] lignes = File.ReadAllLines(nomFichier);

                    StreamWriter html = new StreamWriter(nomFichier + ".html");

                    html.Write(@"<html>");
                    html.Write(@"<head>");
                    html.Write(@"<link rel='stylesheet' href='styles.css'/>");
                    html.Write(@"</head>"); 
                    html.Write(@"<body>");
                    html.Write(@"<h1>Dates et événements</h1>");
                    html.Write(@"<table>");
                    html.Write(@"<thead>");
                    html.Write(@"<tr>");
                    html.Write(@"<th>Évènement</th>");
                    html.Write(@"<th>Année</th>");
                    html.Write(@"<th>Mois</th>");
                    html.Write(@"<th>Jour</th>");
                    html.Write(@"</tr>");
                    html.Write(@"</thead>");

                    html.Write(@"<tbody>");

                    for (int i = 0; i != lignes.Length; ++i)
                    {
                        if (lignes[i] != null && lignes[i] != "")
                        {
                            string[] parties = lignes[i].Split(new[] { ':' }, 
                                StringSplitOptions.RemoveEmptyEntries);

                            if (!(1 > parties.Length || parties.Length >= 3))
                            {
                                if (TryParse(parties[0], out Date date))
                                {
                                    html.Write(@"<tr>");

                                    if (parties.Length != 1)
                                    {
                                        Afficher(EnTexte(date), parties[1], 1, DarkYellow, Cyan);

                                        html.Write(@"<td>" + $"{parties[1]}" + "</td>");
                                    }
                                    else
                                    {
                                        Afficher(EnTexte(date), " ???", 1, DarkYellow, Cyan);

                                        html.Write(@"<td>" + "???" + "</td>");
                                    }

                                    html.Write(@"<td>" + $"{date.Année}" + "</td>");
                                    html.Write(@"<td>" + $"{date.Mois}" + "</td>");
                                    html.Write(@"<td>" + $"{date.Jour}" + "</td>");

                                    html.Write(@"</tr>");
                                }
                                else
                                {
                                    MessageErreur($"Date invalide: {lignes[i]}");
                                }
                            }
                            else
                            {
                                MessageErreur($"Format erroné: {lignes[i]}");
                            }
                        }
                    }

                    html.Write(@"</tbody>");
                    html.Write(@"</table>");
                    html.Write(@"</body>");
                    html.Write(@"</html>");

                    html.Flush();

                    html.Close();

                    MessageOk($"\nFichier HTML généré: {nomFichier}.html");
                    break;

                default:
                    // --- Message d'usage ---
                    ColorWriteLine(Yellow, "USAGE : AfficherDate [NomFichier]");
                    break;
            }
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
            ColorWriteLine(Yellow, "\nMort de MJ:\t\t{0}", EnTexte(DateDécèsMJ, "/"));
            ColorWriteLine(Cyan, "\nExplosion de la NC:\t{0}", EnTexte(DateExplosionNC, "."));

            var aprèsDemain = New(
                DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
            var avantHier = New(
                DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);

            ColorWriteLine(Magenta, $"\nAvant-hier:\t\t{avantHier.Décrémenter(2).EnTexteLong()}");
            ColorWriteLine(Yellow, $"Hier:\t\t\t{Hier.EnTexteLong()}");
            ColorWriteLine(Green, $"Aujourd'hui:\t\t{Aujourdhui.EnTexteLong()}");
            ColorWriteLine(Cyan, $"Demain:\t\t\t{Demain.EnTexteLong()}");
            ColorWriteLine(Magenta, $"Après-demain:\t\t{aprèsDemain.Incrémenter(2).EnTexteLong()}");
            ColorWriteLine(DarkYellow, $"\nDate par défaut:        {new Date {Année = 2019, JourDeLAnnée = 100}.EnTexteLong()}");

            Poursuivre();
        }
    }
}
