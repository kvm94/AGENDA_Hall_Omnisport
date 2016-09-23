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
    /// Logique d'interaction pour GererUtilisateur.xaml
    /// </summary>
    public partial class GererUtilisateur : Window
    {
        private Utilisateur utilisateur;
        public GererUtilisateur(Utilisateur utilisateur)
        {
            InitializeComponent();
            this.utilisateur = utilisateur;
            // Prérempli les textbox avec les infos de l'utilisateur
            pseudoTextBlock.Text = utilisateur.Pseudo;
            passwordPasswordBox.Password = utilisateur.Password;
            passwordConfirmPasswordBox.Password = utilisateur.Password;
            nomTextBox.Text = utilisateur.Nom;
            prenomTextBox.Text = utilisateur.Prenom;
            activiteTextBox.Text = utilisateur.Activite;
            numTelTextBox.Text = utilisateur.NumTel;
            mailTextBox.Text = utilisateur.Email;
            webTextBox.Text = utilisateur.Web;
        }
        #region Click event
        // Envoi les modifications à  la DB
        private void modifierButton_Click(object sender, RoutedEventArgs e)
        {
            if (passwordPasswordBox.Password == passwordConfirmPasswordBox.Password)
            {
                try
                {
                    // Modifie la classe utilisateur avec les infos des Textblock
                    utilisateur.Password = passwordPasswordBox.Password;
                    utilisateur.Nom = nomTextBox.Text;
                    utilisateur.Prenom = prenomTextBox.Text;
                    utilisateur.Activite = activiteTextBox.Text;
                    utilisateur.NumTel = numTelTextBox.Text;
                    utilisateur.Email = mailTextBox.Text;
                    utilisateur.Web = webTextBox.Text;
                    // Envoi les nouvel infos à la DB
                    if (utilisateur.Modifier())
                    {
                        MessageBox.Show("Votre modification a bien été effectuez");
                        this.Close();
                    }
                    else
                        MessageBox.Show("Une erreur c'est produite lors de la modification", "Erreur de modification", MessageBoxButton.OK);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
            else
            {
                MessageBox.Show("Le mot de passe et le mot de passe de confirmation ne sont pas les mêmes", "Erreur d'inscription", MessageBoxButton.OK);
            }
        }
        // Retourne sur la page de l'agenda
        private void retourButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion
        // Toutes les fonctions de cette région permettent d'activer ou de désactiver le boutton Modifier
        #region Activer Désactiver Boutton Modifier
        private void passwordPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            this.ActiverButtonModifier();
        }
        private void passwordConfirmPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            this.ActiverButtonModifier();
        }
        private void nomTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.ActiverButtonModifier();
        }
        private void ActiverButtonModifier()
        {
            if (passwordPasswordBox.Password != "" && passwordConfirmPasswordBox.Password != "" && nomTextBox.Text != "")
                modifierButton.IsEnabled = true;
            else
                modifierButton.IsEnabled = false;
        }
        #endregion
    }
}
