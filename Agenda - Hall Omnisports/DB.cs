using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda___Hall_Omnisports
{
    class DB
    {
        //Ouvre la connexion à la base de données.
        private static DATABASEDataContext database = new DATABASEDataContext();

        #region Vincent
        // Important est-ce que la db peut-être ouverte
        public static bool Ouverte()
        {
            return database.DatabaseExists();
        }
        // Fonction qui check dans la DB si l'utilisateur est présent avec le mot de passe saisi
        public static bool Connexion(string pseudo, string password)
        {
            if (database.Connexion(pseudo, password) == 1)
                return true;
            else
                return false;
        }
        // Fonction qui check les informations d'un utilisateur dans la DB et les renvoi
        public static Utilisateur GetUser(string pseudo)
        {
            Utilisateur utilisateur = new Utilisateur();
            utilisateur.Pseudo = pseudo;
            utilisateur.Password = database.GetUser(pseudo).Single().Password;
            utilisateur.Nom = database.GetUser(pseudo).Single().Nom;
            utilisateur.Prenom = database.GetUser(pseudo).Single().Prenom;
            utilisateur.Activite = database.GetUser(pseudo).Single().Activite;
            utilisateur.NumTel = database.GetUser(pseudo).Single().Telephone;
            utilisateur.Email = database.GetUser(pseudo).Single().Email;
            utilisateur.Web = database.GetUser(pseudo).Single().Web;
            return utilisateur;
        }
        // Fonction qui enregistre un nouvel utilisateur dans la DB
        public static bool Registration(string pseudo, string password, string nom, string prenom, string activite, string numTel, string email, string web)
        {
            if (database.Registration(pseudo, password, nom, prenom, activite, numTel, email, web) == 1)
                return true;
            else
                return false;
        }
        // Fonction qui update l'utilisateur dans la DB
        public static bool Modification(string pseudo, string password, string nom, string prenom, string activite, string numTel, string email, string web)
        {
            if (database.Modification(pseudo, password, nom, prenom, activite, numTel, email, web) == 1)
                return true;
            else
                return false;
        }
        // Fonction qui va rechercher les non d'utilisateur et les place dans une liste
        public static List<string> GetAllUserName()
        {
            List<string> tmp = new List<string>();
            tmp.Add("");
            foreach (var User in database.GetAllUserName())
            {
                tmp.Add(User.Pseudo);
            }
            return tmp;
        }
        #endregion

        #region Kevin

        // Ajoute un salle dans la base de données.
        public static void AddSalle(Salle salle)
        {
            SALLE tSalle = new SALLE();

            tSalle.Nom      = salle.nom;
            tSalle.Surface  = salle.surface;
            tSalle.Detail   = salle.info;
            tSalle.Capacite = salle.capacite;

            database.SALLE.InsertOnSubmit(tSalle);
            database.SubmitChanges();
        }

        // Ajoute une réservation dans la base de données.
        public static void AddReservation(Reservation r)
        {
            RESERVATION reservation = new RESERVATION();
            int id_utilisateur = 0;
            var req = database.GetIdUtilisateur(r.utilisateur);

            foreach (var item in req)
                id_utilisateur = item.ID_Utilisateur;

            reservation.Date = r.date;
            reservation.HeureDebut = r.HeureDebut;
            reservation.HeureFin = r.HeureFin;
            reservation.MinDebut = r.MinDebut;
            reservation.MinFin = r.MinFin;
            reservation.Detail = r.detail;
            reservation.ID_Salle = r.salle.id;
            reservation.ID_Utilisateur = id_utilisateur;
            reservation.NomR = r.nomR;

            database.RESERVATION.InsertOnSubmit(reservation);
            database.SubmitChanges();
        }

        //Supprime une salle dans la base de données.
        public static void DeleteSalle(int id)
        {
            database.DeleteSalle(id);
            database.SubmitChanges();
        }

        //Supprime une réservation dans la base de données.
        public static void DeleteReservation(int id)
        {
            database.DeleteReservation(id);
            database.SubmitChanges();
        }

        //Met à jour une salle dans la base de données.
        public static void UpdateSalle(Salle s)
        {
            database.UpdateSalle(s.id, s.nom, s.capacite, s.surface, s.info);
        }

        //Met à jour une réservation dans la base de données.
        public static void UpdateReservation(Reservation r)
        {
            database.UpdateReservation(r.id, r.nomR, r.date, r.detail, r.HeureDebut, r.HeureFin, r.MinDebut, r.MinFin);
        }

        //Charge les salle dans une liste.
        public static void LoadSalle(ListeSalle liste)
        {
            var req = database.GetSalle();

            foreach (var item in req)
            {
                liste.Ajout(item.ID_Salle, item.Nom, item.Capacite, item.Surface, item.Detail);
            }

        }

        //Charge les réservations d'un utilisateur dans une liste.
        public static void LoadReservation(ListeReservation liste, string utilisateur)
        {
            var req = database.GetReservation(utilisateur);
            Salle s = new Salle();

            foreach (var item in req)
            {
                var req2 = database.GetSalleById(item.ID_Salle);
                foreach (var salle in req2)
                    s = new Salle(salle.ID_Salle, salle.Nom, salle.Capacite, salle.Surface, salle.Detail);
                liste.Ajout(item.ID_Reservation, item.NomR, item.Date, item.HeureDebut, item.HeureFin, item.MinDebut, item.MinFin, item.Detail, utilisateur, s);
            }

        }

        //Charge toutes les réservations dans une liste.
        public static void LoadReservation(ListeReservation liste)
        {
            var req = database.GetAllReservation();
            Salle s = new Salle();


            foreach (var item in req)
            {
                var req2 = database.GetSalleById(item.ID_Salle);
                foreach (var salle in req2)
                    s = new Salle(salle.ID_Salle, salle.Nom, salle.Capacite, salle.Surface, salle.Detail);
                liste.Ajout(item.ID_Reservation, item.NomR, item.Date, item.HeureDebut, item.HeureFin, item.MinDebut, item.MinFin, item.Detail, item.Pseudo, s);
            }

        }

        //Charge une liste de noms de salle.
        public static List<string> GetAllSalleName()
        {
            List<string> tmp = new List<string>();

            foreach (var salle in database.GetAllSalleName())
            {
                tmp.Add(salle.nom);
            }
            return tmp;
        }

        //Charge une liste de réservation par salle et par date.
        public static void LoadReservation(List<int> heuresDebut, List<int> heuresFin, String nomSalle, DateTime date)
        {
            var req = database.GetAllReservationByDateAndSalle(date, nomSalle);

            foreach (var item in req)
            {
                heuresDebut.Add(item.HeureDebut);
                heuresFin.Add(item.HeureFin);
            }

        }

        #endregion
    }
}
