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
    /// Logique d'interaction pour Connection.xaml
    /// </summary>
    public partial class Connection : Window
    {
        private Utilisateur utilisateur;
        public Connection(Utilisateur utilisateur)
        {
            InitializeComponent();
            this.utilisateur = utilisateur;
        }
        #region Click event
        // Connecte l'utilisateur si les info son correcte sinon réaffiche la fenêtre connexion
        private void connectionButton_Click(object sender, RoutedEventArgs e)
        {
            try {
                utilisateur.Pseudo = pseudoTextBox.Text;
                utilisateur.Password = passwordPasswordBox.Password;
            }
            catch (Exception exc) {
                MessageBox.Show(exc.Message);
            }

            if (utilisateur.Connecter())
                this.Close();
            else
            {
                pseudoTextBox.Text = "";
                passwordPasswordBox.Password = "";
                MessageBox.Show("L'identifaint ou le mot de passe sont incorecte", "Echec de connection", MessageBoxButton.OK);
            }
        }
        // Ouvre la fenêtre d'inscription
        private void inscriptionBT_Click(object sender, RoutedEventArgs e)
        {
            Inscription inscription = new Inscription(utilisateur);
            inscription.ShowDialog();
        }
        // Retourne sur la page de l'agenda
        private void retourButton_Click(object sender, RoutedEventArgs e)
        {
            pseudoTextBox.Text = "guest";
            passwordPasswordBox.Password = "";
            this.Close();
        }
        #endregion
        // Toutes les fonctions de cette région permettent d'activer ou de désactiver le boutton connexion
        #region Activer Désactiver Boutton Connection
        private void pseudoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.ActiverButtonConnection();
        }
        private void passwordPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            this.ActiverButtonConnection();
        }
        private void ActiverButtonConnection()
        {
            if (pseudoTextBox.Text != "" && passwordPasswordBox.Password != "")
                connectionButton.IsEnabled = true;
            else
                connectionButton.IsEnabled = false;
        }
        #endregion
    }
}
