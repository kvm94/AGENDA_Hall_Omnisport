﻿#pragma checksum "..\..\Inscription.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D2436B89CB12E548D1EFCC102DB9BF30"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using Agenda___Hall_Omnisports;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Agenda___Hall_Omnisports {
    
    
    /// <summary>
    /// Inscription
    /// </summary>
    public partial class Inscription : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\Inscription.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox pseudoTextBox;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\Inscription.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox passwordPasswordBox;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\Inscription.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox passwordConfirmPasswordBox;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\Inscription.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nomTextBox;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\Inscription.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox prenomTextBox;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\Inscription.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox activiteTextBox;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\Inscription.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox numTelTextBox;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\Inscription.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox mailTextBox;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\Inscription.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox webTextBox;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\Inscription.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button inscrireButton;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\Inscription.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button retourButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Agenda - Hall Omnisports;component/inscription.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Inscription.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.pseudoTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 20 "..\..\Inscription.xaml"
            this.pseudoTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.pseudoTextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.passwordPasswordBox = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 21 "..\..\Inscription.xaml"
            this.passwordPasswordBox.PasswordChanged += new System.Windows.RoutedEventHandler(this.passwordPasswordBox_PasswordChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.passwordConfirmPasswordBox = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 22 "..\..\Inscription.xaml"
            this.passwordConfirmPasswordBox.PasswordChanged += new System.Windows.RoutedEventHandler(this.passwordConfirmPasswordBox_PasswordChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.nomTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 23 "..\..\Inscription.xaml"
            this.nomTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.nomTextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.prenomTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.activiteTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.numTelTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.mailTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.webTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.inscrireButton = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\Inscription.xaml"
            this.inscrireButton.Click += new System.Windows.RoutedEventHandler(this.inscrireButton_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.retourButton = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\Inscription.xaml"
            this.retourButton.Click += new System.Windows.RoutedEventHandler(this.retourButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

