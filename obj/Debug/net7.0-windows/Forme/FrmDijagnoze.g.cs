﻿#pragma checksum "..\..\..\..\Forme\FrmDijagnoze.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "45A0FEE9372F846490DBEDBBA18BE61BD51942B5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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
using Zubna_ordinacija.Forme;


namespace Zubna_ordinacija.Forme {
    
    
    /// <summary>
    /// FrmDijagnoze
    /// </summary>
    public partial class FrmDijagnoze : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\..\Forme\FrmDijagnoze.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNazivDijagnoze;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\Forme\FrmDijagnoze.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSacuvaj;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\Forme\FrmDijagnoze.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnOtkazi;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\Forme\FrmDijagnoze.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPlan;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\Forme\FrmDijagnoze.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbKorisnik;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\Forme\FrmDijagnoze.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbPacijent;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\Forme\FrmDijagnoze.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbEvidencija;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\Forme\FrmDijagnoze.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbRacun;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Zubna ordinacija;component/forme/frmdijagnoze.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Forme\FrmDijagnoze.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.txtNazivDijagnoze = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.btnSacuvaj = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\..\Forme\FrmDijagnoze.xaml"
            this.btnSacuvaj.Click += new System.Windows.RoutedEventHandler(this.btnSacuvaj_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnOtkazi = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\..\Forme\FrmDijagnoze.xaml"
            this.btnOtkazi.Click += new System.Windows.RoutedEventHandler(this.btnOtkazi_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txtPlan = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.cbKorisnik = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.cbPacijent = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.cbEvidencija = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.cbRacun = ((System.Windows.Controls.ComboBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
