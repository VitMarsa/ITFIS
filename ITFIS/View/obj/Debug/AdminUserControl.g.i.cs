﻿#pragma checksum "..\..\AdminUserControl.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "ECD8093CAFA4F5676E3922F06515B0CE0B2ADC1B03629063CD8309E91D1C9719"
//------------------------------------------------------------------------------
// <auto-generated>
//     Tento kód byl generován nástrojem.
//     Verze modulu runtime:4.0.30319.42000
//
//     Změny tohoto souboru mohou způsobit nesprávné chování a budou ztraceny,
//     dojde-li k novému generování kódu.
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
using System.Windows.Shell;
using View;


namespace View {
    
    
    /// <summary>
    /// AdminUserControl
    /// </summary>
    public partial class AdminUserControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\AdminUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox userListBox;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\AdminUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label nameLabel;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\AdminUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label surnameLabel;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\AdminUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label idLabel;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\AdminUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label roleLabel;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\AdminUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button changeUserButton;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\AdminUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addUserButton;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\AdminUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button deleteUserButton;
        
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
            System.Uri resourceLocater = new System.Uri("/View;component/adminusercontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AdminUserControl.xaml"
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
            this.userListBox = ((System.Windows.Controls.ListBox)(target));
            
            #line 19 "..\..\AdminUserControl.xaml"
            this.userListBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.userListBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.nameLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.surnameLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.idLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.roleLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.changeUserButton = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\AdminUserControl.xaml"
            this.changeUserButton.Click += new System.Windows.RoutedEventHandler(this.changeUserButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.addUserButton = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\AdminUserControl.xaml"
            this.addUserButton.Click += new System.Windows.RoutedEventHandler(this.addUserButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.deleteUserButton = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\AdminUserControl.xaml"
            this.deleteUserButton.Click += new System.Windows.RoutedEventHandler(this.deleteUserButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
