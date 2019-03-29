/* Fichier pour les attributs, les méthodes et les propriétés de la classe DateConstante. */
using static System.Enum;
using static Prog2.ConsolePlus;
using static System.ConsoleColor;
using static Prog2.Date;
using static Prog2.Mois;
using static System.Console;
using static Prog2.Calendrier;
using System;

namespace Prog2
{
    public class DateConstante : Date
    {
        public DateConstante(int année, int mois, int jour) 
            : base(année, mois, jour)
        {
        }

        private int JourDeLAnnéeCaché = 0;

        /// <summary>
        /// L'année.
        /// </summary>
        public override int Année
        {
            get => base.Année;
            set => throw OpérationInvalide();
        }

        /// <summary>
        /// Le jour.
        /// </summary>
        public override int Jour
        {
            get => base.Jour;
            set => throw OpérationInvalide();
        }
        /// <summary>
        /// Le jour de l'année. 
        /// </summary>
        public override int JourDeLAnnée
        {
            get
            {
                if (JourDeLAnnéeCaché == 0)
                    JourDeLAnnéeCaché = base.JourDeLAnnée;
                return JourDeLAnnéeCaché;
            }
        }

        /// <summary>
        /// Le mois.
        /// </summary>
        public override int Mois
        {
            get => base.Mois;
            set => throw OpérationInvalide();
        }

        /// <summary>
        /// Pour cloner une date constante.
        /// </summary>
        /// <param name="année"></param>
        /// <param name="mois"></param>
        /// <param name="jour"></param>
        /// <returns></returns>
        public override Date Cloner(int année = 0, int mois = 0, int jour = 0)
        {
            var annéeClone = Année;
            var moisClone = Mois;
            var jourClone = Jour;

            if (année > 0)
            {
                annéeClone = année;
            }

            if (mois > 0)
            {
                moisClone = mois;
            }

            if (jour > 0)
            {
                jourClone = jour;
            }

            return new DateConstante(annéeClone, moisClone, jourClone);
        }

        public override Date Décrémenter(int décrément = 1)
        {
            throw OpérationInvalide();
        }

        public override Date Incrémenter(int incrément = 1)
        {
            throw OpérationInvalide();
        }

        public override Date MettreÀJour()
        {
            throw OpérationInvalide();
        }

        private Exception OpérationInvalide() 
            => new DateConstanteException();
    }
}
