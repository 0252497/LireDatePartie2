﻿/* Fichier pour les attributs, les méthodes et les propriétés de la classe Calendrier. */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Prog2.JourDeLaSemaine;
using static System.Console;

namespace Prog2
{
    public class Calendrier
    {
        // Pour le nombre de rangées et de colonnes du calendrier :
        public const int NbRangées = 6; 
        public const int NbColonnes = 7;

        private int _année;
        private Mois _mois;

        /// <summary>
        /// Pour l'année.
        /// </summary>
        public int Année
        {
            get => _année;
            set
            {
                if (1582 > value || value > 9999)
                    throw new ArgumentOutOfRangeException(nameof(Année), $"## Invalide : {value}");
                _année = value;
            }
        }

        /// <summary>
        /// Pour le mois.
        /// </summary>
        public Mois Mois
        {
            get => _mois;
            set
            {
                if ((int)value > 12 || 1 > (int)value)
                    throw new ArgumentOutOfRangeException(nameof(Mois), $"## Invalide : {value}");
                _mois = value;
            }
        }

        /// <summary>
        /// Pour le jour, représenté par calendrier[rangée, colonne].
        /// </summary>
        private int[,] Jours { get; }

        /// <summary>
        /// Constructeur pour la classe Calendrier.
        /// </summary>
        /// <param name="année">l'année</param>
        /// <param name="mois">le mois</param>
        public Calendrier(int année, Mois mois)
        {
            Année = année;
            Mois = mois;
            Jours = new int[NbRangées, NbColonnes];
            RemplirTableau();
        }

        /// <summary>
        /// Indexation de la classe Calendrier.
        /// </summary>
        /// <param name="rangée">la rangée</param>
        /// <param name="colonne">la colonne</param>
        /// <returns>le jour et sa position</returns>
        public int this[int rangée, int colonne]
            => Jours[rangée, colonne];

        // --- Méthodes ---

        /// <summary>
        /// Localise la position (rangée et colonne) d'une date dans le calendrier.
        /// </summary>
        /// <param name="date">la date à localiser</param>
        /// <param name="rangée">la rangée trouvée (première = 0)</param>
        /// <param name="colonne">la colonne trouvée (première = 0)</param>
        /// <returns>vrai si la date se trouve dans le calendrier</returns>
        public bool Localiser(Date date, out int rangée, out int colonne)
        {
            // La rangée et la colonne à rechercher :
            colonne = 0;    
            rangée = 0;

            if (date != null && Année == date.Année && Mois == date.MoisTypé)
            {
                // Le jour de la semaine de la date correspond à sa colonne :
                colonne = date.JourDeLaSemaine != Dimanche ? (int)date.JourDeLaSemaine : 0;

                // Recherche de sa rangée :
                for (int i = 0; i < NbRangées; ++i)
                {
                    if (Jours[i, colonne] == date.Jour)
                    {
                        rangée = i;
                        return true;
                    }
                }

                return false;
            }
            else
            {
                return false;
            }
        }

        private void RemplirTableau()
        {
            // La date du premier du mois de la date entrée :
            Date datePremier = new Date(Année, Mois, 1);

            // On commence à la rangée zéro, et la colonne de début correspond au jour du premier 
            // du mois :
            int rangée = 0; 
            int colonne = datePremier.JourDeLaSemaine != Dimanche ? (int)datePremier.JourDeLaSemaine : 0;

            // Pour trouver toutes les positions de chaque jour du mois :
            for (int i = 1; i <= Année.NbJoursDsMois((int)Mois); ++i)
            {
                Jours[rangée, colonne] = i;

                datePremier.Incrémenter();

                ++colonne;

                if (datePremier.JourDeLaSemaine == Dimanche)
                {
                    ++rangée;
                    colonne = 0;
                }
            }
        }
    }
}
