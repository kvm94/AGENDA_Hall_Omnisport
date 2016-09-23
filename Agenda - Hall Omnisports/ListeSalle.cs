using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda___Hall_Omnisports
{
    public class ListeSalle
    {
        //Attribut

        private List<Salle> liste;

        //Constructeur

        public ListeSalle()
        {
            liste = new List<Salle>();
        }

        //Méthodes

        //Ajout d'une salle à la liste.
        public void Ajout(int id, string nom, int capacite, int surface, string info)
        {
            Salle salle = new Salle(id, nom, capacite, surface, info);
            this.Ajout(salle);
        }

        public void Ajout(Salle salle)
        {
            liste.Add(salle);
        }


        //Supprimer toutes les salle de la liste et de la base de données.
        public void Supprimer()
        {
            int i;
            for (i = 0; i < this.Count(); i++)
            {
                liste[i].Supprimer();
            }
        }

        //Supprime un salle de la liste
        public void SupprimerSalle(Salle salle)
        {
            liste.Remove(salle);
        }

        //Compte le nombre d'élements de la liste.
        public int Count()
        {
            return liste.Count();
        }

        //Extrait la salle à une position demandé de la liste.
        public Salle Extraire(int pos)
        {
            return liste[pos];
        }

        //Charge le contenue de la liste à partir de la base de données.
        public void Charger()
        {
            DB.LoadSalle(this);
        }
    }
}
