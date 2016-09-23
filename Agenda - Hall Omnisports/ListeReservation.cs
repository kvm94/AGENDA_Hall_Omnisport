using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda___Hall_Omnisports
{
    public class ListeReservation
    {
        //Attribut

        private List<Reservation> liste;

        //Constructeur

        public ListeReservation()
        {
            liste = new List<Reservation>();
        }

        //Méthodes

        //Ajout d'une réservation à la liste.
        public void Ajout(int id, string nom, DateTime date, int heureDebut, int heureFin, int minDebut, int minFin, string detail, string utilisateur, Salle salle)
        {
            Reservation r = new Reservation(id, nom, date,heureDebut,heureFin, minDebut, minFin, detail, utilisateur, salle);
            this.Ajout(r);
        }

        public void Ajout(Reservation r)
        {
            liste.Add(r);
        }

        //Supprimer toutes les réservation de la liste et de la base de données.
        public void Supprimer()
        {
            int i;
            for (i = 0; i < this.Count(); i++)
            {
                liste[i].Supprimer();
            }
        }

        //Supprime un salle de la liste
        public void SupprimerFromList(Reservation r)
        {
            liste.Remove(r);
        }

        //Compte le nombre d'élements de la liste.
        public int Count()
        {
            return liste.Count();
        }

        //Extrait la réservation à une position demandé de la liste.
        public Reservation Extraire(int pos)
        {
            return liste[pos];
        }

        //Charge le contenue de la liste à partir de la base de données.
        public void Charger(string utilisateur)
        {
            DB.LoadReservation(this, utilisateur);
        }
        //Charge toutes le réservations.
        public void Charger()
        {
            DB.LoadReservation(this);
        }
    }
}
