﻿/* Fichier pour les attributs et les méthodes de la classe Date. */
using System;

namespace Prog2
{
    /// <summary>
    /// Classe Date.
    /// </summary>
    public class Date
    {
        // --- Attributs ---
        public int Année;
        public int Mois;
        public int Jour;
        private static readonly Date aujourdhui = New(
            DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);

        // --- Méthodes ---
        /// <summary>
        /// Retourne la date d'aujourd'hui.
        /// </summary>
        /// <returns>aujourd'hui</returns>
        public static Date Aujourdhui() 
            => aujourdhui;

        /// <summary>
        /// Fais afficher la date, soit le mois, le jour et l'année. Si aucune date n'est précisée, on fera 
        /// afficher la date d'aujourd'hui.
        /// </summary>
        /// <param name="date">la date</param>
        /// <param name="séparateur">le séparateur</param>
        /// <returns>la date à afficher</returns>
        public static string EnTexte(Date date = null, string séparateur = "-")
        {
            if (date != null)
            {
                return string.Format(
                    "{0:D4}{3}{1:D2}{3}{2:D2}", date.Année, date.Mois, date.Jour, séparateur);
            }
            else
            {
                return string.Format(
                    "{0:D4}{3}{1:D2}{3}{2:D2}", aujourdhui.Année, aujourdhui.Mois, aujourdhui.Jour, 
                    séparateur);
            }
        }
        
        /// <summary>
        /// Pour aider à construire une nouvelle date.
        /// </summary>
        /// <param name="année">l'année</param>
        /// <param name="mois">le mois, 1 = janvier</param>
        /// <param name="jour">le jour du mois</param>
        /// <returns>une nouvelle date</returns>
        public static Date New(int année, int mois, int jour)
            => new Date { Année = année, Mois = mois, Jour = jour };

        /// <summary>
        /// Pour vérifier que deux dates sont pareilles.
        /// </summary>
        /// <param name="date1">première date</param>
        /// <param name="date2">deuxième date</param>
        /// <returns>vrai si égales</returns>
        public static bool SontÉgales(Date date1, Date date2)
            => date1.Année == date2.Année && date1.Mois == date2.Mois && date1.Jour == date2.Jour;
    }
}