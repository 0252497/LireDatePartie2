﻿/* Programme qui fait afficher diverses dates. */
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

                    StreamWriter html = new StreamWriter(nomFichier + ".html");

                    html.Write(@"<html>" + html.NewLine + @"<body style='font-family:Arial'>" + html.NewLine);
                    html.Write(@"<h1 style='padding-left:5px'>Dates et événements</h1>");
                    html.Write(@"<table width='100%' cellpadding='15' style='margin-top:10px'");
                    html.Write(@"<thead >" + html.NewLine + "<tr style='background-color:#D3D3D3'>");
                    html.Write(@"<th style='text-align:left'>Évènement</th>");
                    html.Write(@"<th style='text-align:left'>Année</th>");
                    html.Write(@"<th style ='text-align:left'>Mois</th>");
                    html.Write(@"<th style = 'text-align:left'>Jour</th>");
                    html.Write(@"<tr>" + html.NewLine + "</thead>" + html.NewLine + "<tbody>");

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
                                    html.Write(@"<tr border'0'>");

                                    if (parties.Length != 1)
                                    {
                                        Afficher(EnTexte(date), parties[1], 1, Yellow, Cyan);

                                        html.Write(
                                            @"<td>" + html.NewLine + $"{parties[1]}" + html.NewLine +
                                            "</td>");
                                    }
                                    else
                                    {
                                        Afficher(EnTexte(date), " ???", 1, Yellow, Cyan);

                                        html.Write(
                                            @"<td>" + html.NewLine + "???" + html.NewLine + "</td>");
                                    }

                                    html.Write(
                                            @"<td>" + html.NewLine + $"{date.Année}" + html.NewLine +
                                            "</td>");
                                    html.Write(
                                        @"<td>" + html.NewLine + $"{date.Mois}" + html.NewLine +
                                        "</td>");
                                    html.Write(
                                        @"<td>" + html.NewLine + $"{date.Jour}" + html.NewLine +
                                        "</td>");

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

                    html.Write(
                        @"</tbody>" + html.NewLine +  "</table>" + html.NewLine + "</body>" + 
                        html.NewLine + "</html>");

                    html.Flush();

                    html.Close();

                    MessageOk($"Fichier HTML généré: {nomFichier}.html");
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
