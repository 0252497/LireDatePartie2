/* Fichier pour les attributs, les méthodes et les propriétés de la classe Calendrier. */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Prog2.JourDeLaSemaine;
using static System.Console;

namespace Prog2
{
    public class Calendrier : ICalendrier
    {
        // Pour le nombre de rangées et de colonnes du calendrier :
        public const int NbRangées = 6; 
        public const int NbColonnes = 7;

        // Pour l'année minimale et maximale :
        public const int AnnéeMin = 1582;
        public const int AnnéeMax = 9999;

        /// <summary>
        /// Pour l'année.
        /// </summary>
        public int Année { get; }

        /// <summary>
        /// Pour le mois.
        /// </summary>
        public Mois Mois { get; }

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
            if (AnnéeMin > année || année > AnnéeMax)
            {
                throw new ArgumentOutOfRangeException(nameof(Année), $"## Invalide : {année}");

            }

            Année = année;

            if (Mois.Janvier > mois || mois > Mois.Décembre)
            {
                throw new ArgumentOutOfRangeException(nameof(Mois), $"## Invalide : {mois}");
            }

            Mois = mois;

            Jours = new int[NbRangées, NbColonnes];
            RemplirTableau();
        }

        /// <summary>
        /// Renvoie le mois en version numérique.
        /// </summary>
        public int MoisNumérique 
            => (int)Mois;

        public int NbJours 
            => Année.NbJoursDsMois(MoisNumérique);

        public int NbSemaines
        {
            get
            {
                Localiser(new Date(Année, Mois, NbJours), out int rangée,
                    out int colonne);

                return rangée + 1;
            }
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

        public override string ToString()
        {
            return $"Calendrier {Mois} {Année}"; ;
        }

        // Hérité de Object :
        public override bool Equals(object obj)
            => obj is Calendrier calendrier &&
               Equals(calendrier);

        public override int GetHashCode() 
            => Année * 100 + MoisNumérique;

        // Implémentation de IEquatable :
        public bool Equals(ICalendrier calendrier)
            => Année == calendrier.Année &&
               Mois == calendrier.Mois;

        public static bool operator ==(Calendrier calendrier1, Calendrier calendrier2) 
            => Equals(calendrier1, calendrier2);

        public static bool operator !=(Calendrier calendrier1, Calendrier calendrier2) 
            => !(calendrier1 == calendrier2);
    }
}
