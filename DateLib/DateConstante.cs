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
        public DateConstante(int année, int mois, int jour, bool estMutable = true) : base(année, mois, jour, estMutable)
        {
        }

        public override Date Incrémenter(int incrément = 1)
        {
            throw OpérationInvalide();
        }

        public override Date Décrémenter(int incrément = 1)
        {
            throw OpérationInvalide();
        }

        public override int Mois
        {
            get => base.Mois;
            set => throw OpérationInvalide();
        }
        

        private Exception OpérationInvalide() 
            => new InvalidOperationException("## Date constante nom modifiable");
    }
}
