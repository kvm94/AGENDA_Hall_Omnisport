using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Agenda___Hall_Omnisports
{
    /// <summary>
    /// Logique d'interaction pour InfoReservation.xaml
    /// </summary>
    public partial class InfoReservation : Window
    {
        //Attributs
        private Reservation r;

        public InfoReservation(Reservation r)
        {
            InitializeComponent();
            this.r = r;
            AfficherReservation();
        }

        #region Click event
        private void retourButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion

        private void AfficherReservation()
        {
            string date;

            date = r.date.Day.ToString() + "/" + r.date.Month.ToString() + "/" + r.date.Year.ToString(); ;
            nomReservationTextBlock.Text = r.nomR;
            nomUtilisateurTextBlock.Text = r.utilisateur;
            dateTextBlock.Text = date;
            heureDepartTextBlock.Text = r.HeureDebut.ToString();
            heureFinTextBlock.Text = r.HeureFin.ToString();
            salleTextBlock.Text = r.salle.nom;
            detailTextBlock.Text = r.detail;

        }

    }
}
