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
        public const int NbRangées = 6;
        public const int NbColonnes = 7;

        private int _année;
        private Mois _mois;

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

        private int[,] Jours { get; }

        public Calendrier(int année, Mois mois)
        {
            Année = année;
            Mois = mois;
            Jours = new int[NbRangées, NbColonnes];
            RemplirTableau();
        }

        public int this[int rangée, int colonne]
            => Jours[rangée, colonne];

        private void RemplirTableau()
        {
            ////! Code temporaire

            //// Première case du tableau, en haut à gauche :
            //Jours[0, 0] = 1;

            //// Rangée 3, colonne 6 :
            //Jours[2, 5] = 20;

            //Jours[NbRangées - 1, NbColonnes - 1] = 42;

            //int jour = 22;

            //for (int colonne = 0; colonne < NbColonnes; ++colonne)
            //{
            //    Jours[3, colonne] = jour;
            //    ++jour;
            //}

            //jour = 5;

            //for (int rangée = 0; rangée < NbRangées; ++rangée)
            //{
            //    Jours[rangée, 4] = jour;
            //    jour += 7;
            //}

            Date datePremier = new Date(Année, Mois, 1);

            int rangée = 0;
            int colonne = (int)datePremier.JourDeLaSemaine;

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
