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
    /// Logique d'interaction pour InfoUtilisateur.xaml
    /// </summary>
    public partial class InfoUtilisateur : Window
    {
        private Utilisateur utilisateur;
        public InfoUtilisateur()
        {
            InitializeComponent();
            // Rempli la combobox avec les nom des utilisateurs
            try
            {
                utilisateurComboBox.ItemsSource = DB.GetAllUserName();
            }catch(Exception exc)
            {
                Console.WriteLine(exc.Message);
                MessageBox.Show("Problème de chargement des données utilisateurs");
            }
        }
        #region Click event
        // Retourne sur la page de l'agenda
        private void retourButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion
        // Change l'utilisateur sélectionné et modifie les textblock avec ses infos recherché dans la DB
        private void utilisateurComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (utilisateurComboBox.SelectedItem != null && utilisateurComboBox.SelectedIndex > 0)
            {
                try {
                    // On rempli les TextBlock avec les infos de l'utilisateur
                    this.utilisateur = new Utilisateur(utilisateurComboBox.SelectedItem.ToString());
                    nomTextBlock.Text = this.utilisateur.Nom;
                    prenomTextBlock.Text = this.utilisateur.Prenom;
                    activiteTextBlock.Text = this.utilisateur.Activite;
                    telephoneTextBlock.Text = this.utilisateur.NumTel;
                    emailTextBlock.Text = this.utilisateur.Email;
                    webTextBlock.Text = this.utilisateur.Web;
                }catch(Exception exc)
                {
                    Console.WriteLine(exc.Message);
                    MessageBox.Show("Problème de chargement des données utilisateurs");
                }

            }
            else {
                // On rempli les textblock avec des string vide quand aucun utlisateur est connecté
                nomTextBlock.Text = "";
                prenomTextBlock.Text = "";
                activiteTextBlock.Text = "";
                telephoneTextBlock.Text = "";
                emailTextBlock.Text = "";
                webTextBlock.Text = "";
            }
        }
    }
}
