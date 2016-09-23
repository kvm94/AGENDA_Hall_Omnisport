using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda___Hall_Omnisports
{
    public class Reservation
    {
        //Attributs
        public int      id              { get; set; }
        public string   nomR             { get; set; }
        public DateTime date            { get; set; }
        public int      HeureDebut      { get; set; }
        public int      HeureFin        { get; set; }
        public int      MinDebut        { get; set; }
        public int      MinFin          { get; set; }
        public string   detail          { get; set; }
        public string   utilisateur     { get; set; }
        public Salle    salle           { get; set; }

        //Constructeurs

        public Reservation()
        {

        }

        public Reservation(int id, string nom, DateTime date, int heureDebut, int heureFin, int minDebut, int minFin, string detail, string utilisateur, Salle salle)
        {
            this.id                 = id;
            this.nomR                = nom;
            this.date               = date;
            this.HeureDebut         = heureDebut;
            this.HeureFin           = heureFin;
            this.MinDebut           = minDebut;
            this.MinFin             = minFin;
            this.detail             = detail;
            this.utilisateur        = utilisateur;
            this.salle              = salle;
        }

        //Méthodes

        //Ajoute la réservation dans la base de données.
        public void Ajout()
        {
            DB.AddReservation(this);
        }

        //Supprimer une salle de la base de données.
        public void Supprimer()
        {
            DB.DeleteReservation(this.id);
        }

        //Modifie une salle dans la base de données.
        public void Modifier()
        {
            DB.UpdateReservation(this);
        }

    }
}
