using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda___Hall_Omnisports
{
    public class Salle
    {
        //Attributs
        public int      id          { get; set; }
        public string   nom         { get; set; }
        public int      capacite    { get; set; }
        public int      surface     { get; set; }
        public string   info        { get; set; }

        //Constructeurs

        public Salle()
        {

        }

        public Salle(int id, string nom, int capacite, int surface, string info)
        {
            this.id         = id;
            this.nom        = nom;
            this.capacite   = capacite;
            this.surface    = surface;
            this.info       = info;
        }

        //Méthodes

        //Ajoute la salle dans la base de données.
        public void Ajout()
        {
            DB.AddSalle(this);
        }

        //Supprimer une salle de la base de données.
        public void Supprimer()
        {
            try
            {
                DB.DeleteSalle(this.id);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                throw new Exception("Impossible de supprimer la salle car elle est utilisé dans une réservation!");
            }
        }

        //Modifie une salle dans la base de données.
        public void Modifier()
        {
            DB.UpdateSalle(this);
        }

        //Change l'affichage par defaut de Salle
        public override string ToString()
        {
            return nom;
        }
    }
}
