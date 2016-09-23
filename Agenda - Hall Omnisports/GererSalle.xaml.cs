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
    /// Logique d'interaction pour GererSalle.xaml
    /// </summary>
    public partial class GererSalle : Window
    {
        //Attributs

        private ListeSalle liste;
        private Administrateur admin;

        //Constructeur

        public GererSalle(Administrateur admin)
        {
            InitializeComponent();
            this.admin = admin;
            LoadListView();
        }

        #region Click event

        //Ferme la fenêtre.
        private void retourButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Supprime une salle de la liste et de la base de données.
        private void supprimerButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                liste.Extraire(salleListView.SelectedIndex - 1).Supprimer();

                nomTextBox.Text = "";
                capaciteTextBox.Text = "";
                surfaceTextBox.Text = "";
                detailTextBox.Text = "";

                salleListView.Items.Clear();
                MessageBox.Show("Suppression réussie !");
                LoadListView();
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            
        }

        //Ajoute une salle à la base de données.
        private void ajouterButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                admin.Salle = new Salle();

                admin.Salle.nom = nomTextBox.Text;
                admin.Salle.surface = int.Parse(surfaceTextBox.Text);
                admin.Salle.capacite = int.Parse(capaciteTextBox.Text);
                admin.Salle.info = detailTextBox.Text;

                nomTextBox.Text = "";
                capaciteTextBox.Text = "";
                surfaceTextBox.Text = "";
                detailTextBox.Text = "";

                admin.Salle.Ajout();
                MessageBox.Show("Ajout réussie !");

                salleListView.Items.Clear();
                LoadListView();
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            
        }

        //Modifie la salle dans la base de données.
        private void modifiererButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Salle s = liste.Extraire(salleListView.SelectedIndex);

                s.nom = nomTextBox.Text;
                s.surface = int.Parse(surfaceTextBox.Text);
                s.capacite = int.Parse(capaciteTextBox.Text);
                s.info = detailTextBox.Text;

                nomTextBox.Text = "";
                capaciteTextBox.Text = "";
                surfaceTextBox.Text = "";
                detailTextBox.Text = "";

                DB.UpdateSalle(s);
                MessageBox.Show("Mise à jour réussie !");
                salleListView.Items.Clear();
                LoadListView();
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            
        }

        #endregion

        #region SelectionChanged event

        //Charge les info lors d'un click sur un item de la liste.
        private void salleListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int pos;
            if (salleListView.SelectedIndex > 0)
            {
                supprimerButton.IsEnabled   = true;
                modifiererButton.Visibility = Visibility.Visible;

                pos = salleListView.SelectedIndex-1;
                nomTextBox.Text         = liste.Extraire(pos).nom;
                capaciteTextBox.Text    = liste.Extraire(pos).capacite.ToString();
                surfaceTextBox.Text     = liste.Extraire(pos).surface.ToString();
                detailTextBox.Text      = liste.Extraire(pos).info;

            }
            else
            {
                nomTextBox.Text = "";
                capaciteTextBox.Text = "";
                surfaceTextBox.Text = "";
                detailTextBox.Text = "";

                supprimerButton.IsEnabled = false;
                modifiererButton.Visibility = Visibility.Hidden;
            }
        }
        #endregion

        #region Activer Désactiver Boutton Ajouter
        private void nomTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.ActiverButtonAjouter();
        }
        private void capaciteTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.ActiverButtonAjouter();
        }
        private void surfaceTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.ActiverButtonAjouter();
        }
        private void ActiverButtonAjouter()
        {
            if (nomTextBox.Text != "" && capaciteTextBox.Text != "" && surfaceTextBox.Text != "")
                ajouterButton.IsEnabled = true;
            else
                ajouterButton.IsEnabled = false;
        }
        #endregion

        //Charge le liste des salles.
        private void LoadListView()
        {
            int i;
            liste = new ListeSalle();
            liste.Charger();

            salleListView.Items.Add("");

            for (i = 0; i < liste.Count(); i++)
                salleListView.Items.Add(liste.Extraire(i));
        }
    }
}
