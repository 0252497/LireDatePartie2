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
            {
                MessageErreur(ex.Message);
            }
        }

        private static void MainSwitch(string[] args, ref string nomFichier)
        {
            var texte = "bidon";

            switch (args.Length)
            {
                case 0:
                    // --- Aucun argument, on se rabat sur l'ancien programme ---
                    texte = File.ReadAllText(nomFichier);
                    ColorWriteLine(DarkCyan, texte);
                    AncienMain();
                    break;

                case 1:
                    // --- On affiche le contenu du fichier spécifié en argument ---
                    nomFichier = args[0];

                    string[] lignes = File.ReadAllLines(nomFichier);


                    var html = new StreamWriter(nomFichier + ".html", true, Encoding.UTF8);

                    for (int i = 0; i != lignes.Length; i++)
                    {
                        if (lignes[i] != null && lignes[i] != "")
                        {
                            string[] parties = lignes[i].Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                            
                            if (3 <= parties.Length || parties.Length < 1) 
                            {
                                MessageErreur($"Format erroné: {lignes[i]}");
                            }
                            else
                            {
                                
                                if (!TryParse(parties[0], out Date date))
                                {
                                    MessageErreur($"Date invalide: {lignes[i]}");
                                }
                                else
                                {
                                    if (parties.Length != 1)
                                    {
                                        html.Write($"{parties[1]}");
                                    }
                                    else
                                    {
                                        html.Write("???");
                                    }
                                    
                                    html.Write(@"<html>" + html.NewLine + @"<body>" + html.NewLine);
                                    html.Write(@"<h1><span style = 'font-family:Verdana'>Dates et événements</span></ h1>");
                                    html.Write(@"<table width='100%' cellpadding='10' style='margin-top:10px' cellspacing='3' border='1' rules='all'>
                                    <thead>
                                        <tr>
                                            <th>Événement</th>
                                            <th>Année</th>
                                            <th>Mois</th>
                                            <th>Jour</th>
                                        <tr>
                                    </thead>

                                    <tbody>
                                        <tr>
                                            <td>");

                                    html.Write(@"</td>
                                                <td>");
                                    html.Write(date.Année);
                                    html.Write(@"</td>
                                                <td>");
                                    html.Write(date.Mois);
                                    html.Write(@"</td>
                                                <td>");
                                    html.Write(date.Jour);
                                    html.Write(@"</td>
                                        <tr>
                                    </tbody>

                                        </table>" + html.NewLine + "</body>" + html.NewLine + "</html>");
                                    if (parties.Length != 1)
                                    {
                                        Afficher(EnTexte(date), parties[1], 1, Yellow, Cyan);

                                    }
                                    else
                                    {
                                        Afficher(EnTexte(date), " ???", 1, Yellow, Cyan);
                                    }

                                    html.Flush();

                                    html.Close();
                                }
                            }
                        }
                    }
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
