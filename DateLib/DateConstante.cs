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

        public override Date Cloner(int année = 0, int mois = 0, int jour = 0)
        {
            Date clone = (Date)MemberwiseClone(); // On clone la date entrée

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

        public override Date Décrémenter(int incrément = 1)
        {
            throw OpérationInvalide();
        }

        public override Date Incrémenter(int incrément = 1)
        {
            throw OpérationInvalide();
        }

        //public override int Mois
        //{
        //    get => base.Mois;
        //    set => throw OpérationInvalide();
        //}

        //public override int Jour
        //{
        //    get => base.Jour;
        //    set => throw OpérationInvalide();
        //}

        //public override int Année
        //{
        //    get => base.Année;
        //    set => throw OpérationInvalide();
        //}

        private int JourDeLAnnéeCaché = 0;

        public override int JourDeLAnnée
        {
            get
            {
                if (JourDeLAnnéeCaché == 0)
                    JourDeLAnnéeCaché = base.JourDeLAnnée;
                return JourDeLAnnéeCaché;
            }
        }

        public override Date MettreÀJour()
        {
            throw OpérationInvalide();
        }

        private Exception OpérationInvalide() 
            => new DateConstanteException();
    }
}
