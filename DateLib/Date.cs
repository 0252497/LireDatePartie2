﻿/* Fichier pour les attributs, les méthodes et les propriétés de la classe Date. */
using System;
using static System.Int32;

namespace Prog2
{
    /// <summary>
    /// Classe Date.
    /// </summary>
    public class Date
    {
        // --- Constructeur par défaut ---
        public Date()
        {
            this._mois = 1;
            this._jour = 1;
            this.Année = 1;
        }

        // --- Constructeurs paramétrés ---
        public Date(int année, int mois, int jour)
        {
            Année = année;
            Mois = mois;
            Jour = jour;
        }

        public Date(int année, Mois moisTypé, int jour) : this(année, (int)moisTypé, jour) {}


        /// <summary>
        /// Exemple : new Date("11 septembre 2011").
        /// </summary>
        /// <param name="strDate">la date en format texte</param>
        /// <exception cref="System.ArgumentException">date</exception>
        public Date(string strDate)
        {
            if (TryParse(strDate, out Date date))
            {
                Année = date.Année;
                _mois = date.Mois;
                _jour = date.Jour;
            }
            else
            {
                throw new ArgumentException(strDate, $"## Invalide : {strDate}");
            }
        }

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
        
        // --- Autopropriétés ---
        /// <summary>
        /// L'année.
        /// </summary>
        public int Année { get; set; }

        /// <summary>
        /// Le mois de l'année. (janvier = 1)
        /// </summary>
        public int Mois
        {
            get => _mois;
            set
            {
                if (value < 1 || value > 12)
                    throw new ArgumentOutOfRangeException(nameof(Mois), $"## Invalide : {value}");
                _mois = value;
            }
        }

        /// <summary>
        /// Le jour du mois.
        /// </summary>
        public int Jour
        {
            get => _jour;
            set
            {
                if (1 > value || value > DateUtil.NbJoursDsMois(Année, _mois))
                    throw new ArgumentOutOfRangeException(nameof(Jour), $"## Invalide : {value}");
                _jour = value;
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
            => this.Mois == 1 && this.Jour == 1;

        /// <summary>
        /// Vrai si la date est Noël.
        /// </summary>
        public bool EstNoël
            => this.Mois == 12 && this.Jour == 25;

        /// <summary>
        /// Vrai si une date est spéciale. Une date est spéciale si le mois et le jour sont
        /// identiques.
        /// </summary>
        public bool EstSpéciale => this.Jour == this.Mois;

        /// <summary>
        /// Vrai si la date est la St-Jean-Baptiste.
        /// </summary>
        public bool EstStJean
            => this.Mois == 6 && this.Jour == 24;

        /// <summary>
        /// Vrai si une date est très spéciale. Une date est très spéciale si le jour, le mois et
        /// les deux derniers chiffres de l'année sont identiques.
        /// </summary>
        public bool EstTrèsSpéciale => this.EstSpéciale && this.Mois == this.Année % 100;

        /// <summary>
        /// Date de hier.
        /// </summary>
        public static Date Hier => hier.MettreÀJour().Décrémenter();

        /// <summary>
        /// Le jour de l'année.
        /// </summary>
        public int JourDeLAnnée
        {
            get
            {
                Date date = New(Année, _mois, _jour);
                Date dernier = New(Année - 1, 12, 31);

                _jourDeLAnnée = 0;

                if (SontÉgales(date, dernier))
                {
                    if (Année.EstBissextile())
                    {
                        _jourDeLAnnée = 366;
                    }
                    else
                    {
                        _jourDeLAnnée = 365;
                    }
                }
                else
                {
                    while (!SontÉgales(date, dernier))
                    {
                        date.Décrémenter();
                        ++_jourDeLAnnée;
                    }
                }

                return _jourDeLAnnée;
            }
            set
            {
                _mois = 1;
                _jour = 1;

                for (int i = 1; i < value; i++)
                    Incrémenter();

                if (1 > value || value > 366)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(JourDeLAnnée), $"## Invalide: {value}");
                }
            }
        }

        /// <summary>
        /// Le mois sous forme de type Mois.
        /// </summary>
        public Mois MoisTypé
        {
            get
            {
                return (Mois)this.Mois;
            }
            set
            {
                this.Mois = (int)value;
            }
        }

        // --- Méthodes ---
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
        public Date Décrémenter(/* Date this */ int décrément = 1)
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

            return this;
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
        /// Pour obtenir la représentation textuelle d'une date en format long.
        /// </summary>
        /// <returns>représentation textuelle</returns>
        public string EnTexteLong(/* Date this */)
            => $"{this.Jour} {MoisTypé.ToString().ToLower()} {this.Année}";

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
        /// Ajoute des jours à la date
        /// </summary>
        /// <param name="incrément">nombre de jours à ajouter</param>
        public Date Incrémenter(/* Date this*/ int incrément = 1)
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

            return this;
        }

        /// <summary>
        /// Modifie la date pour la mettre au jour d'aujourd'hui.
        /// </summary>
        /// <returns>la date</returns>
        public Date MettreÀJour(/* Date this*/)
        {
            this.Année = DateTime.Today.Year;
            this.Mois = DateTime.Today.Month;
            this.Jour = DateTime.Today.Day;
            return this;
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

        /// <summary>
        /// Pour aider à construire une nouvelle date.
        /// </summary>
        /// <param name="année">l'année</param>
        /// <param name="mois">le mois en type Mois</param>
        /// <param name="jour">le jour du mois</param>
        /// <returns>une nouvelle date ou null si la date n'est pas valide</returns>
        public static Date New(int année, Mois mois, int jour)
            => EstValide(année, (int)mois, jour) ?
                new Date { Année = année, Mois = (int)mois, Jour = jour } : null;


        /// <summary>
        /// Pour vérifier que deux dates sont pareilles.
        /// </summary>
        /// <param name="date1">première date</param>
        /// <param name="date2">deuxième date</param>
        /// <returns>vrai si égales</returns>
        public static bool SontÉgales(Date date1, Date date2)
            => date1.Année == date2.Année && date1.Mois == date2.Mois && date1.Jour == date2.Jour;

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
    }
}