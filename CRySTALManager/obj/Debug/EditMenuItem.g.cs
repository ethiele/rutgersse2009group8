﻿#pragma checksum "..\..\EditMenuItem.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "FF863BC053679CCE07BE14676144ECB7"
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
    /// EditMenuItem
    /// </summary>
    public partial class EditMenuItem : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\EditMenuItem.xaml"
        internal System.Windows.Controls.Label m_PID;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\EditMenuItem.xaml"
        internal System.Windows.Controls.TextBox m_name;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\EditMenuItem.xaml"
        internal System.Windows.Controls.ComboBox m_catagory;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\EditMenuItem.xaml"
        internal System.Windows.Controls.ComboBox m_subcat;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\EditMenuItem.xaml"
        internal System.Windows.Controls.TextBox m_des;
        
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
            System.Uri resourceLocater = new System.Uri("/CRySTALManager;component/editmenuitem.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\EditMenuItem.xaml"
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
            this.m_PID = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.m_name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.m_catagory = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.m_subcat = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.m_des = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
