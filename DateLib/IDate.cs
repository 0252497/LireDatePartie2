/* Classe pour l'interface IDate. */
namespace Prog2
{
    public interface IDate
    {
        int Année { get; set; }

        bool EstMutable { get; set; }

        int Jour { get; set; }

        int JourDeLAnnée { get; set; }

        JourDeLaSemaine JourDeLaSemaine { get; }
        int Mois { get; set; }

        Mois MoisTypé { get; set; }
    }
}