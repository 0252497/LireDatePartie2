/* Fichier pour les attributs, les méthodes et les propriétés de la classe Date. */
using System;
using System.Diagnostics;
using static System.Int32;

namespace Prog2
{
    /// <summary>
    /// Classe Date.
    /// </summary>
    public class Date : object, IEquatable<Date>, IComparable<Date>, IFormattable
    {
        // --- Constructeur par défaut ---
        public Date()
        {
            EstMutable = true;
            Mois = 1;
            Jour = 1;
            Année = 1;
        }

        // --- Constructeurs paramétrés ---

        public Date(int année, int mois, int jour, bool estMutable = true)
        {
            if (!EstValide(année, mois, jour))
                throw new ArgumentOutOfRangeException("##  ");

            _année = année;
            _mois = mois;
            _jour = jour;
            EstMutable = estMutable;
        }

        public Date(int année, Mois moisTypé, int jour, bool estMutable = true)
            : this(année, (int)moisTypé, jour, estMutable) {}
        
        /// <summary>
        /// Exemple : new Date("11 septembre 2011").
        /// </summary>
        /// <param name="strDate">la date en format texte</param>
        /// <exception cref="System.ArgumentException">date</exception>
        public Date(string strDate, bool estMutable = true)
        {
            if (TryParse(strDate, out Date date))
            {
                EstMutable = estMutable;
                _année = date.Année;
                _mois = date.Mois;
                _jour = date.Jour;
            }
            else
            {
                throw new ArgumentException(strDate, $"## Invalide : {strDate}");
            }
        }

        private int _année;
        private int _mois;
        private int _jour;
        private int _jourDeLAnnée;

        private static readonly Date aujourdhui = New(
            DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
        private static readonly Date demain = New(
            DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
        private static readonly Date hier = New(
            DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);

        // --- Propriétés ---

        /// <summary>
        /// L'année.
        /// </summary>
        public virtual int Année
        {
            get => _année;
            set
            {
                if (value < 1 || _jour > value.NbJoursDsMois(_mois))
                    throw new ArgumentOutOfRangeException(nameof(Année), $"## Invalide : {value}");

                if (!EstMutable)
                {
                    throw new InvalidOperationException();
                }

                _année = value;
            }
        }

        /// <summary>
        /// Le mois de l'année. (janvier = 1)
        /// </summary>
        public virtual int Mois
        {
            get => _mois;
            set
            {
                if (value < 1 || value > 12 || _jour > _année.NbJoursDsMois(value))
                    throw new ArgumentOutOfRangeException(nameof(Mois), $"## Invalide : {value}");

                if (!EstMutable)
                {
                    throw new InvalidOperationException();
                }

                _mois = value;
            }
        }

        /// <summary>
        /// Le jour du mois.
        /// </summary>
        public virtual int Jour
        {
            get => _jour;
            set
            {
                if (1 > value || value > _année.NbJoursDsMois(_mois))
                    throw new ArgumentOutOfRangeException(nameof(Jour), $"## Invalide : {value}");

                if (!EstMutable)
                {
                    throw new InvalidOperationException();
                }

                _jour = value;
            }
        }

        /// <summary>
        /// Le jour de l'année.
        /// </summary>
        public virtual int JourDeLAnnée
        {
            get
            {
                // Pour la date entrée et le dernier jour de l'année précédente :
                Date date = new Date(Année, Mois, Jour);
                Date dernier = new Date(Année - 1, 12, 31);

                _jourDeLAnnée = 0;

                while (!SontÉgales(date, dernier))
                {
                    date.Décrémenter();
                    ++_jourDeLAnnée;
                }

                return _jourDeLAnnée;
            }
            set
            {
                _mois = 1;
                _jour = 1;

                for (int i = 1; i < value; ++i)
                    Incrémenter();

                if (1 > value || value > (Année.EstBissextile() ? 366 : 365))
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(JourDeLAnnée), $"## Invalide: {value}");
                }
            }
        }

        /// <summary>
        /// Jour de la semaine associé à la date. Calculé grâce à l'algorithme des congruences de Zeller.
        /// </summary>
        public JourDeLaSemaine JourDeLaSemaine
        {
            get
            {
                if (!EstMutable)
                {
                    throw new InvalidOperationException();
                }

                int m = Mois;
                int a = Année;
                int q = Jour;

                if (m == 1 || m == 2)
                {
                    m += 12;
                    --a;
                }

                int k = a % 100;
                int j = a / 100;

                int h = (q + 13 * (m + 1) / 5 + k + k / 4 + j / 4 + 5 * j) % 7;
                int d = ((h + 5) % 7) + 1;

                return (JourDeLaSemaine)d;
            }
        }

        /// <summary>
        /// Le mois sous forme de type Mois.
        /// </summary>
        public Mois MoisTypé
        {
            get
            {
                return (Mois)Mois;
            }
            set
            {
                if (!EstMutable)
                {
                    throw new InvalidOperationException();
                }

                Mois = (int)value;
            }
        }
        
        // --- Propriétés calculables --- 

        /// <summary>
        /// Date d'aujourd'hui.
        /// NB: Le même objet est retourné chaque fois.
        /// </summary>
        public static Date Aujourdhui => aujourdhui.MettreÀJour();

        /// <summary>
        /// Date de demain.
        /// </summary>
        public static Date Demain => demain.MettreÀJour().Incrémenter();

        /// <summary>
        /// Vrai si la date est le premier jour de l'an.
        /// </summary>
        public bool EstJourDeLAn
            => Mois == 1 && Jour == 1;

        /// <summary>
        /// Renvoie si la date est mutable.
        /// </summary>
        public bool EstMutable { get; set; }

        /// <summary>
        /// Vrai si la date est Noël.
        /// </summary>
        public bool EstNoël
            => Mois == 12 && Jour == 25;

        /// <summary>
        /// Vrai si une date est spéciale. Une date est spéciale si le mois et le jour sont
        /// identiques.
        /// </summary>
        public bool EstSpéciale => Jour == Mois;

        /// <summary>
        /// Vrai si la date est la St-Jean-Baptiste.
        /// </summary>
        public bool EstStJean
            => Mois == 6 && Jour == 24;

        /// <summary>
        /// Vrai si une date est très spéciale. Une date est très spéciale si le jour, le mois et
        /// les deux derniers chiffres de l'année sont identiques.
        /// </summary>
        public bool EstTrèsSpéciale 
            => EstSpéciale && Mois == Année % 100;

        /// <summary>
        /// Date de hier.
        /// </summary>
        public static Date Hier => hier.MettreÀJour().Décrémenter();

        // --- Méthodes ---

        /// <summary>
        /// Génère une date aléatoire comprise entre les années spécifiées.
        /// NB : La distribution est uniforme et toutes les dates sont possibles.
        /// </summary>
        /// <param name="random">Générateur utilisé pour générer la date</param>
        /// <param name="annéeMin">année minimum</param>
        /// <param name="annéeMax">année maximum</param>
        /// <returns>une nouvelle date aléatoire</returns>
        public static Date Aléatoire(Random random, int annéeMin, int annéeMax)
        {
            if (annéeMax < annéeMin)
            {
                throw new ArgumentException("## Max doit être plus grand que min");
            }

            // On génère une année, un mois et un jour aléatoires :
            int annéeAléatoire = random.Next(annéeMin, annéeMax + 1);
            int moisAléatoire = random.Next(1, 13);
            int jourAléatoire = random.Next(1, annéeAléatoire.NbJoursDsMois(moisAléatoire) + 1);

            return new Date(annéeAléatoire, moisAléatoire, jourAléatoire);
        }

        /// <summary>
        /// Génère une date aléatoire comprise entre les années spécifiées.
        /// NB : La distribution est uniforme et toutes les dates sont possibles.
        /// </summary>
        /// <param name="random">Générateur utilisé pour générer la date</param>
        /// <param name="dateMin">date minimum</param>
        /// <param name="dateMax">date maximum</param>
        /// <returns>une nouvelle date aléatoire</returns>
        public static Date Aléatoire(Random random, Date dateMin, Date dateMax)
        {
            if (dateMax.ComparerAvec(dateMin) == -1)
            {
                throw new ArgumentException("## Max doit être plus grand que min");
            }

            // Le nombre de jours qui se retrouvent entre la date maximum et la date minimum :
            int nbJours = dateMax.Moins(dateMin) + 1;

            // Pour le jour aléatoire qu'on ajoutera à un clone de la date minimum :
            int jourAléatoire = random.Next(0, nbJours);    

            return dateMin.Cloner().Incrémenter(jourAléatoire);
        }

        /// <summary>
        /// Pour cloner une date en modifiant certains attributs au besoin.
        /// </summary>
        /// <param name="date">date à cloner</param>
        /// <param name="année">année modifiée au besoin</param>
        /// <param name="mois">mois modifié au besoin</param>
        /// <param name="jour">jour modifié au besoin</param>
        /// <returns>la date clonée</returns>
        public virtual Date Cloner(/* Date this*/ int année = 0, int mois = 0, int jour = 0)
        {
            Date clone = new Date(Année, Mois, Jour); // On clone la date entrée

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
        /// Compare cette date-ci (this) avec une autre date => +1 ou 0 ou 1.
        /// </summary>
        /// <param name="autre">l'autre date</param>
        /// <returns>0 si égaux, +1 si this > autre, -1 si autre > this</returns>
        public int ComparerAvec(/* Date this */ Date autre)
        {
            if (Année.ComparerAvec(autre.Année) == 0 && Mois.ComparerAvec(autre.Mois) == 0 &&
                Jour.ComparerAvec(autre.Jour) == 0)
            {
                return 0;
            }
            else if (Année.ComparerAvec(autre.Année) == 1 ||
                (Année.ComparerAvec(autre.Année) == 0 && (Mois.ComparerAvec(autre.Mois) == 1))||
                (Année.ComparerAvec(autre.Année) == 0 && Mois.ComparerAvec(autre.Mois) == 0
                && Jour.ComparerAvec(autre.Jour) == 1))
            {
                return +1;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// Retranche des jours à la date.
        /// </summary>
        /// <param name="décrément">nombre de jours à enlever</param>
        public virtual Date Décrémenter(/* Date this */ int décrément = 1)
        {
            if (!EstMutable)
            {
                throw new InvalidOperationException();
            }

            for (int i = 0; i < décrément; ++i)
            {
                if (EstValide(Année, Mois, Jour - 1))
                {
                    --Jour;
                }
                else
                {
                    if (Mois <= 1)
                    {
                        Mois = 12;
                        --Année;
                    }
                    else
                    {
                        --Mois;
                    }

                    Jour = Année.NbJoursDsMois(Mois);
                }
            }

            return this;
        }

        /// <summary>
        /// Pour cloner une date.
        /// </summary>
        /// <returns>le clone du date</returns>
        public Date Dupliquer() 
            => MemberwiseClone() as Date;

        /// <summary>
        /// Fais afficher la date, soit le mois, le jour et l'année. Si aucune date n'est précisée, on fera 
        /// afficher la date d'aujourd'hui.
        /// </summary>
        /// <param name="date">la date</param>
        /// <param name="séparateur">le séparateur</param>
        /// <returns>la date à afficher</returns>
        public static string EnTexte(Date date = null, string séparateur = "-")
            => (date != null) ? string.Format(
                    $"{date.Année:D4}{séparateur}{date.Mois:D2}{séparateur}{date.Jour:D2}") : string.Format(
                    $"{aujourdhui.Année:D4}{séparateur}{aujourdhui.Mois:D2}{séparateur}{aujourdhui.Jour:D2}");
  
        /// <summary>
        /// Pour obtenir la représentation textuelle d'une date en format long.
        /// </summary>
        /// <returns>représentation textuelle</returns>
        public string EnTexteLong(/* Date this */)
            => $"{Jour} {MoisTypé.ToString().ToLower()} {Année}";

        /// <summary>
        /// Détermine si une date est valide.
        /// </summary>
        /// <param name="année">l'année</param>
        /// <param name="mois">le mois</param>
        /// <param name="jour">le jour</param>
        /// <returns>vrai si la date est valide</returns>
        public static bool EstValide(int année, int mois, int jour, bool estMutable = true)
            => 1 <= jour && jour <= année.NbJoursDsMois(mois) && 1 <= mois && mois <= 12;

        public override int GetHashCode()
        {
            var hashCode = -1198555504;
            hashCode = hashCode * -1521134295 + Année.GetHashCode();
            hashCode = hashCode * -1521134295 + Mois.GetHashCode();
            hashCode = hashCode * -1521134295 + Jour.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// Ajoute des jours à la date.
        /// </summary>
        /// <param name="incrément">nombre de jours à ajouter</param>
        public virtual Date Incrémenter(/* Date this*/ int incrément = 1)
        {
            for (int i = 0; i < incrément; ++i)
            {
                if (EstValide(Année, Mois, Jour + 1))
                {
                    ++Jour;
                }
                else
                {
                    if (Mois >= 12)
                    {
                        Jour = 1;
                        Mois = 1;
                        Année += 1;
                    }
                    else
                    {
                        Jour = 1;
                        Mois += 1;
                    }
                }
            }

            return this;
        }

        /// <summary>
        /// Modifie la date pour la mettre au jour d'aujourd'hui.
        /// </summary>
        /// <returns>la date</returns>
        public virtual Date MettreÀJour(/* Date this*/)
        {
            Année = DateTime.Today.Year;
            Mois = DateTime.Today.Month;
            Jour = DateTime.Today.Day;
            return this;
        }

        /// <summary>
        /// Calcule le nombre de jours qui séparent deux dates, positif ou négatif.
        /// </summary>
        /// <param name="autre">l'autre date</param>
        /// <returns>la différence</returns>
        public int Moins(/* Date this */ Date autre)
        {
            int différence = 0; // Le nombre de jours de différence entre la date et l'autre

            if (ComparerAvec(autre) == 1)
            {
                while (!SontÉgales(this, autre))
                {
                    Décrémenter();
                    ++différence;
                }
            }
            else if (ComparerAvec(autre) == -1)
            {
                while (!SontÉgales(this, autre))
                {
                    Incrémenter();
                    --différence;
                }
            }

            return différence;
        }

        /// <summary>
        /// Pour aider à construire une nouvelle date.
        /// </summary>
        /// <param name="année">l'année</param>
        /// <param name="mois">le mois, 1 = janvier</param>
        /// <param name="jour">le jour du mois</param>
        /// <returns>une nouvelle date ou null si la date n'est pas valide</returns>
        public static Date New(int année, int mois, int jour, bool estMutable = true)
            => !EstValide(année, mois, jour, estMutable) ? null 
                : new Date { Année = année, Mois = mois, Jour = jour, EstMutable = estMutable};

        /// <summary>
        /// Pour aider à construire une nouvelle date.
        /// </summary>
        /// <param name="année">l'année</param>
        /// <param name="mois">le mois en type Mois</param>
        /// <param name="jour">le jour du mois</param>
        /// <returns>une nouvelle date ou null si la date n'est pas valide</returns>
        public static Date New(int année, Mois mois, int jour, bool estMutable = true)
            => EstValide(année, (int)mois, jour) ?
                new Date { Année = année, Mois = (int)mois, Jour = jour, EstMutable = estMutable } : null;

        /// <summary>
        /// Pour vérifier que deux dates sont pareilles.
        /// </summary>
        /// <param name="date1">première date</param>
        /// <param name="date2">deuxième date</param>
        /// <returns>vrai si égales</returns>
        public static bool SontÉgales(Date date1, Date date2)
            => date1.Année == date2.Année && date1.Mois == date2.Mois && date1.Jour == date2.Jour;

        /// <summary>
        /// Renvoie la date en chaîne de caractères.
        /// </summary>
        /// <returns>la date en string</returns>
        public override string ToString()
            => $"{EnTexte(this)}";

        /// <summary>
        /// Tente de décoder une date donnée en format texte.
        /// </summary>
        /// <param name="strDate">la date textuelle</param>
        /// <param name="date">la date ou null si ça ne marche pas</param>
        /// <returns>vrai si la date est décodable et valide</returns>
        public static bool TryParse(string strDate, out Date date)
        {
            date = null;

            if (TrySplitDate(strDate, out string strAnnée, out string strMois, out string strJour) && 
                strMois.TryParseMois(out int mois))
            {
                // Pour l'année et le jour numériques :
                int année = Parse(strAnnée);   
                int jour = Parse(strJour);

                // On crée une nouvelle date qui sera null si non valide :
                date = New(année, mois, jour);
            }

            return date != null; 
        }

        private static bool
            TrySplitDate(string strDate, out string strAnnée, out string strMois, out string strJour)
        {
            string[] date = strDate.Split(new[] { '-', '/', ',', ' ', ';', ':', '(', ')', '\'', '.'}, 
                StringSplitOptions.RemoveEmptyEntries);

            strAnnée = null;
            strMois = null;
            strJour = null;

            if (date.Length != 3)
            {
                return false;
            }
            else if (EstAnnée(date[0]) && date[1].EstAlpha() && EstJour(date[2]))
            {
                strAnnée = date[0];
                strMois = date[1];
                strJour = date[2];
                return true;
            }
            else if (EstAnnée(date[0]) && EstJour(date[1]) && date[2].EstAlpha())
            {
                strAnnée = date[0];
                strJour = date[1];
                strMois = date[2];
                return true;
            }
            else if (date[0].EstAlpha() && EstAnnée(date[1]) && EstJour(date[2]))
            {
                strMois = date[0];
                strAnnée = date[1];
                strJour = date[2];
                return true;
            }
            else if (date[0].EstAlpha() && EstJour(date[1]) && EstAnnée(date[2]))
            {
                strMois = date[0];
                strJour = date[1];
                strAnnée = date[2];
                return true;
            }
            else if (EstJour(date[0]) && EstAnnée(date[1]) && date[2].EstAlpha())
            {
                strJour = date[0];
                strAnnée = date[1];
                strMois = date[2];
                return true;
            }
            else if (EstJour(date[0]) && date[1].EstAlpha() && EstAnnée(date[2]))
            {
                strJour = date[0];
                strMois = date[1];
                strAnnée = date[2];
                return true;
            }
            else if (EstAnnée(date[0]) && EstJour(date[1]) && EstJour(date[2]))
            {
                strJour = date[2];
                strMois = date[1];
                strAnnée = date[0];
                return true;
            }

            return false;

            // --- Fonctions locales ---
            bool EstAnnée(string str) => str.EstNumérique() && str.Length >= 3;
            bool EstJour(string str) => str.EstNumérique() && str.Length <= 2;
        }

        // --- Interfaces ---

        // IComparable :
        public int CompareTo(Date date)
            => ComparerAvec(date);

        // IEquatable :
        public override bool Equals(object obj)
            => obj is Date date && Equals(date);

        public bool Equals(Date date)
            => Année == date.Année &&
                Mois == date.Mois &&
                Jour == date.Jour;

        // IFormattable :
        public string ToString(string format, IFormatProvider formatProvider)
        {
            format = format ?? "G";

            switch (format.ToUpperInvariant())
            {
                case "G":   // Général = par défaut
                case "":
                case "-":
                    return ToString();

                case "L": // long
                    return EnTexteLong();

                case "S":
                    return EnTexte(this, " ");

                case ".":
                    return EnTexte(this, ".");

                case "/":
                    return EnTexte(this, "/");

                default:
                    throw new FormatException(
                        $"Le format '{format}' n'est pas supporté pour une Date.");
            }
        }
    }
}