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
    /// Logique d'interaction pour GererReservation.xaml
    /// </summary>
    public partial class GererReservation : Window
    {
        //Attributs

        private ListeReservation    listeR;
        private Utilisateur         utilisateur;
        private ListeSalle          listeS;
        private List<int>           heuresDebut;
        private List<int>           heuresFin;

        //Constructeur

        public GererReservation(Utilisateur utilisateur)
        {
            InitializeComponent();
            this.utilisateur = utilisateur;
            listeS = new ListeSalle();
            dateNewDatePicker.DisplayDateStart = DateTime.Now;
            dateDatePicker.SelectedDate = DateTime.Now;
            reservationListView.Items.Clear();
            //salleComboBox.SelectedIndex = 0;
            listeS.Charger();
            LoadComboBox();
            LoadNewComboBox();
            if (utilisateur.Pseudo == "admin")
                LoadListView();
            else
                LoadListView(utilisateur.Pseudo);
        }

        #region Click event

        //Ferme la fenêtre.
        private void retourButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Ajoute une réservation dans la base de données.
        private void ajouterButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CheckReservation())
                {
                    //Récupération des informations.
                    utilisateur.Reservation = new Reservation();
                    Salle s = listeS.Extraire(salleNewComboBox.SelectedIndex);

                    utilisateur.Reservation.nomR = nomTextBox.Text;
                    utilisateur.Reservation.salle = s;
                    utilisateur.Reservation.date = dateNewDatePicker.SelectedDate.Value;
                    utilisateur.Reservation.detail = detailTextBox.Text;
                    utilisateur.Reservation.HeureDebut = int.Parse(heureDebutTextBox.Text);
                    utilisateur.Reservation.HeureFin = int.Parse(heureFinTextBox.Text);
                    utilisateur.Reservation.MinDebut = int.Parse(minDebutTextBox.Text);
                    utilisateur.Reservation.MinFin = int.Parse(minFinTextBox.Text);
                    utilisateur.Reservation.utilisateur = utilisateur.Pseudo;

                    DB.AddReservation(utilisateur.Reservation);

                    MessageBox.Show("Ajout réussi !");

                    //Chargement de la listeView
                    reservationListView.Items.Clear();
                    if (utilisateur.Pseudo == "admin")
                        LoadListView();
                    else
                        LoadListView(utilisateur.Pseudo);
                }
                else
                    throw new Exception("La salle est déjà réservée pour cette plage horaire!");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        //Supprime une réservation.
        private void supprimerButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                listeR.Extraire(reservationListView.SelectedIndex - 1).Supprimer();
                reservationListView.Items.Clear();

                MessageBox.Show("Suppression réussie !");

                if (utilisateur.Pseudo == "admin")
                    LoadListView();
                else
                    LoadListView(utilisateur.Pseudo);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

        }

        //Modifie une réservation dans la base de données.
        private void modifiererButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                    Reservation r = listeR.Extraire(reservationListView.SelectedIndex - 1);

                    r.nomR = nomTextBox.Text;
                    r.date = dateNewDatePicker.SelectedDate.Value;
                    r.detail = detailTextBox.Text;
                    r.HeureDebut = int.Parse(heureDebutTextBox.Text);
                    r.HeureFin = int.Parse(heureFinTextBox.Text);
                    r.MinDebut = int.Parse(minDebutTextBox.Text);
                    r.MinFin = int.Parse(minFinTextBox.Text);

                    nomTextBox.Text = "";
                    heureFinTextBox.Text = "";
                    heureDebutTextBox.Text = "";
                    detailTextBox.Text = "";

                    DB.UpdateReservation(r);
                    reservationListView.Items.Clear();

                    MessageBox.Show("Mise à jour réussie !");

                    if (utilisateur.Pseudo == "admin")
                        LoadListView();
                    else
                        LoadListView(utilisateur.Pseudo);
                
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        #endregion

        #region SelectionChanged event

        //Chargement de la réservation lors d'un selection dans la liste.
        private void reservationListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (reservationListView.SelectedIndex > 0)
            {
                Reservation r = listeR.Extraire(reservationListView.SelectedIndex-1);
                heureDebutTextBox.IsEnabled = false;
                heureFinTextBox.IsEnabled = false;
                dateNewDatePicker.IsEnabled = false;

                nomTextBox.Text = r.nomR;
                salleNewComboBox.Text = r.salle.nom;
                dateNewDatePicker.Text = r.date.ToString();
                detailTextBox.Text  = r.detail;
                heureDebutTextBox.Text = r.HeureDebut.ToString();
                heureFinTextBox.Text = r.HeureFin.ToString();
                minDebutTextBox.Text = "00";
                minFinTextBox.Text = "00";

                supprimerButton.IsEnabled = true;
                modifiererButton.Visibility = Visibility.Visible;
            }
            else
            {
                heureDebutTextBox.IsEnabled = true;
                heureFinTextBox.IsEnabled = true;
                dateNewDatePicker.IsEnabled = true;
                nomTextBox.Text = "";
                salleNewComboBox.Text = "";
                dateNewDatePicker.Text = "";
                detailTextBox.Text = "";
                heureDebutTextBox.Text = "";
                heureFinTextBox.Text = "";
                minDebutTextBox.Text = "00";
                minFinTextBox.Text ="00";

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
        private void salleNewComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.ActiverButtonAjouter();
        }
        private void heureDebutTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.ActiverButtonAjouter();
        }
        //private void minDebutTextBox_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    this.ActiverButtonAjouter();
        //}
        private void heureFinTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.ActiverButtonAjouter();
        }
        //private void minFinTextBox_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    this.ActiverButtonAjouter();
        //}
        private void ActiverButtonAjouter()
        {
            if (nomTextBox.Text != "" && dateNewDatePicker.SelectedDate != null && heureDebutTextBox.Text != "" && minDebutTextBox.Text != "" && heureFinTextBox.Text != "" && minFinTextBox.Text != "" && salleNewComboBox.SelectedItem != null)
                ajouterButton.IsEnabled = true;
            else
                ajouterButton.IsEnabled = false;
        }
        #endregion

        #region Chargement des listes 

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

        //Charge la liste dans la comboBox salle.
        private void LoadComboBox()
        {
            salleComboBox.ItemsSource = DB.GetAllSalleName();
        }

        //Charge le comboBox des salles dans le formulaire.
        private void LoadNewComboBox()
        {
            salleNewComboBox.ItemsSource = DB.GetAllSalleName();
        }

        //Charge les liste des heures déjà réservée.

        #endregion

        #region Filtres sur la liste

        //Active la comboBox Salle
        private void salleCheckBox_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                salleComboBox.IsEnabled = true;
                if (salleCheckBox.IsChecked == true )
                {
                    salleComboBox.SelectedIndex = 0;
                    if (dateDatePicker.IsEnabled && dateDatePicker.SelectedDate.HasValue )
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
                    salleComboBox.IsEnabled = false;
                    reservationListView.Items.Clear();
                    if (dateDatePicker.IsEnabled && dateDatePicker.SelectedDate.HasValue)
                        LoadListViewByDate();
                    else
                    {
                        if (utilisateur.Pseudo == "admin")
                            LoadListView();
                        else
                            LoadListView(utilisateur.Pseudo);
                    }
                }
            }
            catch(Exception exc)
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
                    if (salleComboBox.IsEnabled && salleComboBox.SelectedIndex >= 0)
                    {
                        reservationListView.Items.Clear();
                        LoadListViewBySalleAndDate();
                    }
                    else
                        if (dateDatePicker.IsEnabled && dateDatePicker.SelectedDate.HasValue)
                    {
                        reservationListView.Items.Clear();
                        LoadListViewByDate();
                    }
                }
                else
                {
                    //Désactive le datepicker et recharge la liste
                    dateDatePicker.IsEnabled = false;
                    reservationListView.Items.Clear();
                    if (salleComboBox.IsEnabled && salleComboBox.SelectedIndex >= 0)
                        LoadListViewBySalle();
                    else
                    {
                        if (utilisateur.Pseudo == "admin")
                            LoadListView();
                        else
                            LoadListView(utilisateur.Pseudo);
                    }
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            
        }

        //Charge la liste avec un filtre sur la salle.
        private void LoadListViewBySalle()
        {
            int i, j=0;
            listeR = new ListeReservation();
            string nomSalle = listeS.Extraire(salleComboBox.SelectedIndex).nom;
            Salle salle;
            Reservation r;

            if(utilisateur.Pseudo == "admin")
                listeR.Charger();
            else
                listeR.Charger(utilisateur.Pseudo);

            //Applique le filtre
            while(j < listeR.Count())
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

            if (utilisateur.Pseudo == "admin")
                listeR.Charger();
            else
                listeR.Charger(utilisateur.Pseudo);

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

            if (utilisateur.Pseudo == "admin")
                listeR.Charger();
            else
                listeR.Charger(utilisateur.Pseudo);

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
                if (salleComboBox.IsEnabled && salleComboBox.SelectedIndex >= 0)
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
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }    
        }

        #endregion

        private bool CheckReservation()
        {
            bool ok = true;
            int heureDebut = int.Parse(heureDebutTextBox.Text);
            int heureFin   = int.Parse(heureFinTextBox.Text);
            string salle = salleNewComboBox.SelectedValue.ToString();

            //Reset des heures réservées
            heuresDebut = new List<int>();
            heuresFin = new List<int>();

            //Chargement des listes heuresDebut et heuresFin
            DB.LoadReservation(heuresDebut, heuresFin, salle,dateNewDatePicker.SelectedDate.Value);

            if (heureDebut >= heureFin || heureDebut< 8 || heureFin>21)
                throw new Exception("Heure de réservation invalide!");

            //Si count() < 0 c'est qu'il n'y a pas de réservation pour cette date.
            if (heuresDebut.Count() > 0)
            {
                foreach( int heureD in heuresDebut)
                {
                    foreach(int heureF in heuresFin)
                    {
                        if (heureDebut >= heureD && heureDebut < heureF)
                            ok = false;
                        if (heureFin > heureD && heureFin <= heureF)
                            ok = false;
                    }
                }
            }

            return ok;
        }
    }
}
