   M S B A M L   `   `   `  ���� S  OAgenda - Hall Omnisports, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Agenda___Hall_OmnisportsAgenda___Hall_Omnisports  )    #Agenda___Hall_Omnisports.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     8local&clr-namespace:Agenda___Hall_Omnisports       � Title$  Agenda��$	��519��$��624.532�� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=�.���  � ColumnDefinitions �� $
��543* ��� $	��27* ��� $	��26* ��� $
��105* �.+��� $
��Left=�$	��Top=�$��	11,10,0,0q�$	��470��$	��604��$��4��.+��� -    ��Name$ connectionButton��$��	Connexion�� �� Left$ 10��
 �� Top$ 10��$	��110��$y�Visible=��� -   $ deconnectionButton��$��Deconnexion��$ 10��$ 10��$	��110��$y�Hidden=��� -   $ infoUtilisateurButton��$��Info Utilisateurs��$	 130��$ 10��$	��120���� -   $ infoSalleButton��$��
Info Salle��$	 487��$ 10��$	��100��{�.  �� -   $ infoReserverButton��$��Info Réservation��$ 10��$	 180��$	��145��{�.  �� -   $ gererProfilButton��$��Gérer Profil��$ 10��$	 220��$	��145��$y�Hidden=��� -   $ gererReserverButton��$��Gérer Réservation��$ 10��$	 260��$	��145��$y�Hidden=��� -   $ gererSalleButton��$��Gérer Salle��$ 10��$	 300��$	��145��$y�Hidden=��� -	    ��Name$ salleComboBox��$	 497��$��90�� �� Text$ Salle��	 �� 
IsEditable	 . $ 50��(  "System.Windows.Controls.DatePicker  -
   
  Name$
 dateDatePicker��$	 196��$ 50��$��35��$	��165��   DisplayDate$ 
2016-04-24��   SelectedDateFormat$
 Long=�{�.  �� -    ��Name$ reservationListView��$	 160��$ 90��$	��427��$	��360�� �� View ��  �� AllowsColumnReorder .  �� ColumnHeaderToolTip$ Réservation��.P��� -   	nomColumn��$	��Nom�� �� Width$
 auto�� �� DisplayMemberBinding �� *nomR+�� -   nomUtilisateurColumn��$��Nom Utilisateur��$
 auto�� �� *utilisateur+�� -   
dateColumn��$
��Date��$ 66�� �� *date+�� -   SalleColumn��$��Salle��$
 auto�� �� *salle+�� -    ��Name$ salleCheckBox��$�� ��$	 461��$ 55���� -   $ dateCheckBox��$�� ��$	 160��$ 55��