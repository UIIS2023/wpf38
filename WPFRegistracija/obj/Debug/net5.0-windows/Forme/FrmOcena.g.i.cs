﻿#pragma checksum "..\..\..\..\Forme\FrmOcena.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "32B7036AE4CA6AB34F321E7D3E830406DFDD56D3"
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
using WPFRegistracija.Forme;


namespace WPFRegistracija.Forme {
    
    
    /// <summary>
    /// FrmOcena
    /// </summary>
    public partial class FrmOcena : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\..\Forme\FrmOcena.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ocenaUnos;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\..\Forme\FrmOcena.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox pasOdabir;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\Forme\FrmOcena.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox sudijaOdabir;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\Forme\FrmOcena.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button unosBtn;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\Forme\FrmOcena.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button izmeniBtn;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\Forme\FrmOcena.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button obrisiBtn;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\Forme\FrmOcena.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid ocenePrikaz;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WPFRegistracija;component/forme/frmocena.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Forme\FrmOcena.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.ocenaUnos = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.pasOdabir = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.sudijaOdabir = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.unosBtn = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\..\Forme\FrmOcena.xaml"
            this.unosBtn.Click += new System.Windows.RoutedEventHandler(this.unosBtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.izmeniBtn = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\..\Forme\FrmOcena.xaml"
            this.izmeniBtn.Click += new System.Windows.RoutedEventHandler(this.izmeniBtn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.obrisiBtn = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\..\Forme\FrmOcena.xaml"
            this.obrisiBtn.Click += new System.Windows.RoutedEventHandler(this.obrisiBtn_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ocenePrikaz = ((System.Windows.Controls.DataGrid)(target));
            
            #line 19 "..\..\..\..\Forme\FrmOcena.xaml"
            this.ocenePrikaz.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.vlasnici_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

