using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda___Hall_Omnisports
{
    public class Utilisateur
    {
        #region Attribut
        protected string pseudo;
        protected string password;
        protected string nom;
        protected string prenom;
        protected string activite;
        protected string numTel;
        protected string email;
        protected string web;
        protected Reservation reservation; 
        #endregion
        #region Constructeur
        public Utilisateur()
        {
            this.pseudo = "guest";
            this.password = "";
            this.nom = "";
            this.prenom = "";
            this.activite = "";
            this.numTel = "";
            this.email = "";
            this.web = "";
        }
        public Utilisateur(string pseudo)
        {
            this.pseudo = pseudo;
            this.password = DB.GetUser(this.pseudo).Password;
            this.nom = DB.GetUser(this.pseudo).Nom;
            this.prenom = DB.GetUser(this.pseudo).Prenom;
            this.activite = DB.GetUser(this.pseudo).Activite;
            this.numTel = DB.GetUser(this.pseudo).NumTel;
            this.email = DB.GetUser(this.pseudo).Email;
            this.web = DB.GetUser(this.pseudo).Web;
        }
        #endregion
        #region Accesseur et mutateur
        public string Pseudo
        {
            get { return pseudo; }
            set { pseudo = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }
        public string Prenom
        {
            get { return prenom; }
            set { prenom = value; }
        }
        public string Activite
        {
            get { return activite; }
            set { activite = value; }
        }
        public string NumTel
        {
            get { return numTel; }
            set { numTel = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Web
        {
            get { return web; }
            set { web = value; }
        }
        public Reservation Reservation {
            get { return reservation; }
            set { reservation = value; }
        }
        #endregion
        #region Méthode
        public bool Connecter()
        {
            return DB.Connexion(this.pseudo, this.password);
        }
        public bool Creer()
        {
            if (DB.Registration(this.pseudo, this.password, this.nom, this.prenom, this.activite, this.numTel, this.email, this.web))
                return true;
            else
                return false;
        }
        public bool Modifier()
        {
            if (DB.Modification(this.pseudo, this.password, this.nom, this.prenom, this.activite, this.numTel, this.email, this.web))
                return true;
            else
                return false;
        }
        public void Sélectionner()
        {

        }
        #endregion
    }
}
