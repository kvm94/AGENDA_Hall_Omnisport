using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda___Hall_Omnisports
{
    // La classe Administrateur sera exactement la même que la classe Utilisateur seul le lien avec salle sera ajouté
    // à l'aide d'un référent à cette classe.
    public class Administrateur:Utilisateur
    {
        #region Attribut
        private Salle salle;
        #endregion
        #region Constructeur
        public Administrateur()
        {
            pseudo = "admin";
            password = "";
            nom = "";
            prenom = "";
            activite = "";
            numTel = "";
            web = "";
        }
        public Administrateur(Utilisateur utilisateur)
        {
            this.pseudo = utilisateur.Pseudo;
            this.password = utilisateur.Password;
            this.nom = utilisateur.Nom;
            this.prenom = utilisateur.Prenom;
            this.activite = utilisateur.Activite;
            this.numTel = utilisateur.NumTel;
            this.email = utilisateur.Email;
            this.web = utilisateur.Web;
        }
        #endregion
        #region Accesseur et mutateur
        public Salle Salle {
            get { return salle; }
            set { salle = value; }
        }
        #endregion
    }
}
