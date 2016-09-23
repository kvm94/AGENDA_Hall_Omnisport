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
    /// Logique d'interaction pour InfoSalle.xaml
    /// </summary>
    public partial class InfoSalle : Window
    {
        //Attributs
        Salle salle;

        //Constructeur
        public InfoSalle(Salle salle)
        {
            InitializeComponent();
            this.salle = salle;
            AfficherInfos();
        }

        private void AfficherInfos()
        {
            nomTextBlock.Text = salle.nom;
            capaciteTextBlock.Text = salle.capacite.ToString();
            surfaceTextBlock.Text = salle.surface.ToString();
            detailTextBlock.Text = salle.info;
        }

        #region Click envent
        private void retourButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion

    }
}
