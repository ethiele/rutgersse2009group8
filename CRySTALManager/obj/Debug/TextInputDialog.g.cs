﻿#pragma checksum "..\..\TextInputDialog.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "35999A7A436986FC4150D8A508AF52A5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3053
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


namespace CRySTALManager {
    
    
    /// <summary>
    /// TextInput
    /// </summary>
    public partial class TextInputDialog : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\TextInputDialog.xaml"
        internal System.Windows.Controls.Label DispText;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\TextInputDialog.xaml"
        internal System.Windows.Controls.TextBox Resp;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\TextInputDialog.xaml"
        internal System.Windows.Controls.Button OkBnt;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/CRySTALManager;component/textinputdialog.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\TextInputDialog.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.DispText = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.Resp = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.OkBnt = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\TextInputDialog.xaml"
            this.OkBnt.Click += new System.Windows.RoutedEventHandler(this.OkBnt_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
