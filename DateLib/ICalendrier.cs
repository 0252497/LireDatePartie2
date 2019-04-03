using System;

namespace Prog2
{
    public interface ICalendrier : IEquatable<ICalendrier>
    {
        int this[int rangée, int colonne] { get; }

        int Année { get; }
        Mois Mois { get; }
        int MoisNumérique { get; }
        int NbJours { get; }

        int NbSemaines { get; }

        bool Localiser(Date date, out int rangée, out int colonne);
    }
}