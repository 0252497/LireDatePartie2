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
        public static readonly Date aujourdhui = New(
            DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
        private static readonly Date demain = New(
            DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
        private static readonly Date hier = New(
            DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
        public int Jour;
        public int Mois;

        // --- Méthodes ---
        /// <summary>
        /// Retourne la date d'aujourd'hui.
        /// </summary>
        /// <returns>aujourd'hui</returns>
        public static Date Aujourdhui()
        {
            aujourdhui.MettreÀJour();
            return aujourdhui;
        }
        /// <summary>
        /// Pour cloner une date en modifiant certains attributs au besoin.
        /// </summary>
        /// <param name="date">date à cloner</param>
        /// <param name="année">année modifiée au besoin</param>
        /// <param name="mois">mois modifié au besoin</param>
        /// <param name="jour">jour modifié au besoin</param>
        /// <returns>la date clonée</returns>
        public Date Cloner(/* Date this*/ int année = 0, int mois = 0, int jour = 0)
        {
            Date clone = New(this.Année, this.Mois, this.Jour); // On clone la date entrée

            if (année > 0)
            {
                clone.Année = année;
            }

            if (mois > 0)
            {
                clone.Mois = mois;
            }

            if (jour > 0)
            {
                clone.Jour = jour;
            }

            return clone;
        }

        /// <summary>
        /// Retranche des jours à la date.
        /// </summary>
        /// <param name="décrément">nombre de jours à enlever</param>
        public void Décrémenter(/* Date this */ int décrément = 1)
        {
            for (int i = 0; i < décrément; ++i)
            {
                if (EstValide(this.Année, this.Mois, this.Jour - 1))
                {
                    --this.Jour;
                }
                else
                {
                    if (this.Mois <= 1)
                    {
                        this.Mois = 12;
                        --this.Année;
                    }
                    else
                    {
                        --this.Mois;
                    }

                    this.Jour = DateUtil.NbJoursDsMois(this.Année, this.Mois);
                }
            }
        }

        /// <summary>
        /// Retourne la date de demain.
        /// </summary>
        /// <returns>la date de demain</returns>
        public static Date Demain()
        {
            demain.MettreÀJour();
            demain.Incrémenter();
            return demain;
        }
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
        /// Pour savoir si une date est spéciale. Une date est spéciale si le mois et le jour sont
        /// identiques.
        /// </summary>
        /// <returns>vrai si elle est spéciale</returns>
        public bool EstSpéciale(/* Date this */)
            => this.Jour == this.Mois;

        /// <summary>
        /// Pour savoir si une date est très spéciale. Une date est très spéciale si le jour, le mois et
        /// les deux derniers chiffres de l'année sont identiques.
        /// </summary>
        /// <returns>vrai si elle est très spéciale</returns>
        public bool EstTrèsSpéciale(/* Date this */)
            => this.EstSpéciale() && this.Mois == this.Année % 100;

        /// <summary>
        /// Détermine si une date est valide.
        /// </summary>
        /// <param name="année">l'année</param>
        /// <param name="mois">le mois</param>
        /// <param name="jour">le jour</param>
        /// <returns>vrai si la date est valide</returns>
        public static bool EstValide(int année, int mois, int jour)
            => 1 <= jour && jour <= DateUtil.NbJoursDsMois(année, mois) && 1 <= mois && mois <= 12;

        /// <summary>
        /// Retourne la date de hier.
        /// </summary>
        /// <returns>la date de hier</returns>
        public static Date Hier()
        {
            hier.MettreÀJour();
            hier.Décrémenter();
            return hier;
        }

        /// <summary>
        /// Ajoute des jours à la date
        /// </summary>
        /// <param name="incrément">nombre de jours à ajouter</param>
        public void Incrémenter(/* Date this*/ int incrément = 1)
        {
            for (int i = 0; i < incrément; ++i)
            {
                if (EstValide(this.Année, this.Mois, this.Jour + 1))
                {
                    ++this.Jour;
                }
                else
                {
                    if (this.Mois >= 12)
                    {
                        this.Jour = 1;
                        this.Mois = 1;
                        this.Année += 1;
                    }
                    else
                    {
                        this.Jour = 1;
                        this.Mois += 1;
                    }
                }
            }
        }

        /// <summary>
        /// Pour aider à construire une nouvelle date.
        /// </summary>
        /// <param name="année">l'année</param>
        /// <param name="mois">le mois, 1 = janvier</param>
        /// <param name="jour">le jour du mois</param>
        /// <returns>une nouvelle date ou null si la date n'est pas valide</returns>
        public static Date New(int année, int mois, int jour) 
            => !EstValide(année, mois, jour) ? null : new Date { Année = année, Mois = mois, Jour = jour };

        public void MettreÀJour(/* Date this*/)
        {
            this.Année = DateTime.Today.Year;
            this.Mois = DateTime.Today.Month;
            this.Jour = DateTime.Today.Day;
        }

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