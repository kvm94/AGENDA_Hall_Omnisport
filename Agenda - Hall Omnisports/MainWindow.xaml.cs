using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Agenda___Hall_Omnisports
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Utilisateur utilisateur;
        private Administrateur administrateur;
        private ListeReservation listeR;
        private ListeSalle listeS;

        public MainWindow()
        {
            InitializeComponent();
            if (DB.Ouverte())
            {
                utilisateur = new Utilisateur();
                dateDatePicker.SelectedDate = DateTime.Now;
                reservationListView.Items.Clear();
                this.Title = "Agenda - " + utilisateur.Pseudo;
                //salleComboBox.SelectedIndex = 0;
                listeS = new ListeSalle();
                listeS.Charger();
                LoadComboBox();
                LoadListView();
            }
            else {
                MessageBox.Show("La base de données ne peut pas être ouverte", "Erreur Base de données");
            }

        }
        #region Click event
        private void connectionButton_Click(object sender, RoutedEventArgs e)
        {
            Connection connection = new Connection(utilisateur);
            this.Visibility = Visibility.Hidden;
            connection.ShowDialog();
            this.Visibility = Visibility.Visible;
            utilisateur = new Utilisateur(utilisateur.Pseudo);
            this.Title = "Agenda - " + utilisateur.Pseudo;
            if (utilisateur.Pseudo == "admin")
            {
                connectionButton.Visibility = Visibility.Hidden;
                deconnectionButton.Visibility = Visibility.Visible;
                gererProfilButton.Visibility = Visibility.Visible;
                gererReserverButton.Visibility = Visibility.Visible;
                gererSalleButton.Visibility = Visibility.Visible;
                administrateur = new Administrateur(utilisateur);
            }
            else if (utilisateur.Pseudo != "guest" && utilisateur.Pseudo != "")
            {
                connectionButton.Visibility = Visibility.Hidden;
                deconnectionButton.Visibility = Visibility.Visible;
                gererProfilButton.Visibility = Visibility.Visible;
                gererReserverButton.Visibility = Visibility.Visible;
            }
        }
        private void deconnectionButton_Click(object sender, RoutedEventArgs e)
        {
            utilisateur = new Utilisateur();
            this.Title = "Agenda - " + utilisateur.Pseudo;
            connectionButton.Visibility = Visibility.Visible;
            deconnectionButton.Visibility = Visibility.Hidden;
            gererProfilButton.Visibility = Visibility.Hidden;
            gererReserverButton.Visibility = Visibility.Hidden;
            gererSalleButton.Visibility = Visibility.Hidden;
        }
        private void gererProfilButton_Click(object sender, RoutedEventArgs e)
        {
            GererUtilisateur gererUtilisateur = new GererUtilisateur(utilisateur);
            this.Visibility = Visibility.Hidden;
            gererUtilisateur.ShowDialog();
            this.Visibility = Visibility.Visible;
        }
        private void gererReserverButton_Click(object sender, RoutedEventArgs e)
        {
            GererReservation gererReservation = new GererReservation(utilisateur);
            this.Visibility = Visibility.Hidden;
            gererReservation.ShowDialog();
            reservationListView.Items.Clear();
            listeR = new ListeReservation();
            listeR.Charger();
            LoadListView();
            this.Visibility = Visibility.Visible;
        }
        private void gererSalleButton_Click(object sender, RoutedEventArgs e)
        {
            GererSalle gererSalle = new GererSalle(administrateur);
            this.Visibility = Visibility.Hidden;
            gererSalle.ShowDialog();
            salleComboBox.ItemsSource = "";
            LoadComboBox();
            listeS = new ListeSalle();
            listeS.Charger();
            this.Visibility = Visibility.Visible;
        }
        private void infoUtilisateurButton_Click(object sender, RoutedEventArgs e)
        {
            InfoUtilisateur infoUtilisateur = new InfoUtilisateur();
            this.Visibility = Visibility.Hidden;
            infoUtilisateur.ShowDialog();
            this.Visibility = Visibility.Visible;
        }
        private void infoReserverButton_Click(object sender, RoutedEventArgs e)
        {
            InfoReservation infoReservation = new InfoReservation(listeR.Extraire(reservationListView.SelectedIndex-1));
            this.Visibility = Visibility.Hidden;
            infoReservation.ShowDialog();
            this.Visibility = Visibility.Visible;
        }
        private void infoSalleButton_Click(object sender, RoutedEventArgs e)
        {
            InfoSalle infoSalle = new InfoSalle(listeS.Extraire(salleComboBox.SelectedIndex));
            this.Visibility = Visibility.Hidden;
            infoSalle.ShowDialog();
            this.Visibility = Visibility.Visible;
        }
        #endregion
        #region SelectionChanged event
       
        private void reservationListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (reservationListView.SelectedIndex > 0)
                infoReserverButton.IsEnabled = true;
            else
                infoReserverButton.IsEnabled = false;
        }


        #endregion
        //Charge la liste dans la comboBox salle.
        private void LoadComboBox()
        {
            salleComboBox.ItemsSource = DB.GetAllSalleName();
        }

        //Charge le liste des réservations.
        private void LoadListView()
        {
            int i;
            listeR = new ListeReservation();
            listeR.Charger();

            reservationListView.Items.Add("");
            for (i = 0; i < listeR.Count(); i++)
                reservationListView.Items.Add(listeR.Extraire(i));
        }

        //Charge la liste des réservation.
        private void LoadListView(string utilisateur)
        {
            int i;
            listeR = new ListeReservation();
            listeR.Charger(utilisateur);

            reservationListView.Items.Add("");
            for (i = 0; i < listeR.Count(); i++)
            {
                reservationListView.Items.Add(listeR.Extraire(i));

            }

        }


        #region Filtres sur la liste

        //Active la comboBox Salle
        private void salleCheckBox_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //reservationListView.Items.Clear();

                if (salleCheckBox.IsChecked == true && salleComboBox.SelectedIndex >= 0)
                {
                    //salleComboBox.IsEnabled = true;
                    if (dateDatePicker.IsEnabled && dateDatePicker.SelectedDate.HasValue)
                    {
                        reservationListView.Items.Clear();
                        LoadListViewBySalleAndDate();
                    }
                    else
                    { 
                        reservationListView.Items.Clear();
                        LoadListViewBySalle();
                    }
                }
                else
                {
                    //Désactive la combobox et recharge la liste
                    //salleComboBox.IsEnabled = false;
                    reservationListView.Items.Clear();
                    if (dateDatePicker.IsEnabled && dateDatePicker.SelectedDate.HasValue)
                        LoadListViewByDate();
                    else
                    {
                        LoadListView();
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

        }

        //Active la comboBox Date.
        private void dateCheckBox_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dateCheckBox.IsChecked == true)
                {
                    dateDatePicker.IsEnabled = true;
                    if (salleCheckBox.IsChecked == true && salleComboBox.SelectedIndex >= 0)
                    {
                        reservationListView.Items.Clear();
                        LoadListViewBySalleAndDate();
                    }
                    else
                    {
                        if (dateDatePicker.IsEnabled && dateDatePicker.SelectedDate.HasValue)
                        {
                            reservationListView.Items.Clear();
                            LoadListViewByDate();
                        }
                    }     
                }
                else
                {
                    //Désactive le datepicker et recharge la liste
                    dateDatePicker.IsEnabled = false;
                    reservationListView.Items.Clear();
                    if (salleCheckBox.IsChecked == true && salleComboBox.SelectedIndex >= 0)
                        LoadListViewBySalle();
                    else
                    {
                        LoadListView();
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

        }

        //Charge la liste avec un filtre sur la salle.
        private void LoadListViewBySalle()
        {
            int i, j = 0;
            listeR = new ListeReservation();
            string nomSalle = listeS.Extraire(salleComboBox.SelectedIndex).nom;
            Salle salle;
            Reservation r;

            listeR.Charger();

            //Applique le filtre
            while (j < listeR.Count())
            {
                salle = listeR.Extraire(j).salle;
                r = listeR.Extraire(j);
                if (salle.nom != nomSalle)
                    listeR.SupprimerFromList(r);
                else
                    j++;
            }

            reservationListView.Items.Add("");
            for (i = 0; i < listeR.Count(); i++)
            {
                reservationListView.Items.Add(listeR.Extraire(i));
            }
        }

        //Charge la liste avec un filtre sur la date.
        private void LoadListViewByDate()
        {
            int i, j = 0;
            listeR = new ListeReservation();
            DateTime date;
            Reservation r;

            listeR.Charger();

            //Applique le filtre
            while (j < listeR.Count())
            {
                date = listeR.Extraire(j).date;
                r = listeR.Extraire(j);
                if (date != dateDatePicker.SelectedDate.Value)
                    listeR.SupprimerFromList(r);
                else
                    j++;
            }

            reservationListView.Items.Add("");
            for (i = 0; i < listeR.Count(); i++)
            {
                reservationListView.Items.Add(listeR.Extraire(i));
            }
        }

        //Charge la liste avec un filtre sur la date et sur la salle.
        private void LoadListViewBySalleAndDate()
        {
            int i, j = 0;
            listeR = new ListeReservation();
            DateTime date;
            string salle = listeS.Extraire(salleComboBox.SelectedIndex).nom;
            Reservation r;

            listeR.Charger();

            //Applique le filtre
            while (j < listeR.Count())
            {
                date = listeR.Extraire(j).date;
                r = listeR.Extraire(j);
                if (date != dateDatePicker.SelectedDate.Value || salle != r.salle.nom)
                    listeR.SupprimerFromList(r);
                else
                    j++;
            }

            reservationListView.Items.Add("");
            for (i = 0; i < listeR.Count(); i++)
            {
                reservationListView.Items.Add(listeR.Extraire(i));
            }
        }

        //Applique un filtre lors d'un changement de date..
        private void dateDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (salleCheckBox.IsChecked == true && salleComboBox.SelectedIndex >= 0)
                {
                    reservationListView.Items.Clear();
                    LoadListViewBySalleAndDate();
                }
                else
                {
                    reservationListView.Items.Clear();
                    LoadListViewByDate();
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

        }

        //Applique un filtre lors d'un changement de salle.
        private void salleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (salleComboBox.SelectedItem != null)
                    infoSalleButton.IsEnabled = true;
                else
                    infoSalleButton.IsEnabled = false;

                if(salleCheckBox.IsChecked == true)
                {
                    if (dateDatePicker.IsEnabled && dateDatePicker.SelectedDate.HasValue)
                    {
                        reservationListView.Items.Clear();
                        LoadListViewBySalleAndDate();
                    }
                    else
                    {
                        reservationListView.Items.Clear();
                        LoadListViewBySalle();
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        #endregion
    }
}
