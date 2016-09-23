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
    /// Logique d'interaction pour Inscription.xaml
    /// </summary>
    public partial class Inscription : Window
    {
        private Utilisateur utilisateur;
        public Inscription(Utilisateur utilisateur)
        {
            InitializeComponent();
            this.utilisateur = utilisateur;
        }        
        #region Click event
        // Evenement du bouton retour -> Femer la fenêtre d'inscription et revnenir à la connexion
        private void retourButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        // Evenement du bouton s'inscrire
        private void inscrireButton_Click(object sender, RoutedEventArgs e)
        {
            //On vérifie d'abord que lemot de passe et le mot de passe de confirmation sont identique
            if (passwordPasswordBox.Password == passwordConfirmPasswordBox.Password)
            {
                try {
                    // On rempli l'utilisateur courant avec les infosaisie dans les textbox
                    utilisateur.Pseudo = pseudoTextBox.Text;
                    utilisateur.Password = passwordPasswordBox.Password;
                    utilisateur.Nom = nomTextBox.Text;
                    utilisateur.Prenom = prenomTextBox.Text;
                    utilisateur.Activite = activiteTextBox.Text;
                    utilisateur.NumTel = numTelTextBox.Text;
                    utilisateur.Email = mailTextBox.Text;
                    utilisateur.Web = webTextBox.Text;
                    // Si la création c'est bien passée on revient sur la fenêtre de connexion
                    if (utilisateur.Creer()) {
                        MessageBox.Show("Vous êtes bien inscrit");
                        this.Close();
                    }
                    // Sinon on affiche un messsage d'erreur
                    else
                        MessageBox.Show("Le pseudo est déjà utilisé, veuillez en choisir un autre", "Erreur d'inscription", MessageBoxButton.OK);
                }
                catch (Exception exc) {
                    MessageBox.Show(exc.Message);
                }
            }
            else
            {
                MessageBox.Show("Le mot de passe et le mot de passe de confirmation ne sont pas les mêmes", "Erreur d'inscription", MessageBoxButton.OK);
            }
        }
        #endregion
        // Toutes les fonctions de cette région permettent d'activer ou de désactiver le boutton S'inscrire
        #region Activer Désactiver Boutton Inscrire
        private void pseudoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.ActiverButtonInscrire();
        }
        private void passwordPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            this.ActiverButtonInscrire();
        }
        private void passwordConfirmPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            this.ActiverButtonInscrire();
        }
        private void nomTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.ActiverButtonInscrire();
        }
        private void ActiverButtonInscrire()
        {
            if (pseudoTextBox.Text != "" && passwordPasswordBox.Password != "" && passwordConfirmPasswordBox.Password != "" && nomTextBox.Text != "")
                inscrireButton.IsEnabled = true;
            else
                inscrireButton.IsEnabled = false;
        }
        #endregion
    }
}
