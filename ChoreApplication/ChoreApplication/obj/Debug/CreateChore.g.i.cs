﻿#pragma checksum "..\..\CreateChore.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "31A328E193749E62202D19DF384586895D5EB3D630E1F104A0718910DDBBBDAD"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ChoreApplication;
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


namespace ChoreApplication {
    
    
    /// <summary>
    /// CreateChore
    /// </summary>
    public partial class CreateChore : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\CreateChore.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grid1;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\CreateChore.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox choreNameTextBox;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\CreateChore.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox valueTextBox;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\CreateChore.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddChorePicture;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\CreateChore.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image chorePictureImage;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\CreateChore.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox descriptionTextBox;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\CreateChore.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Create;
        
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
            System.Uri resourceLocater = new System.Uri("/ChoreApplication;component/createchore.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\CreateChore.xaml"
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
            
            #line 8 "..\..\CreateChore.xaml"
            ((ChoreApplication.CreateChore)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.grid1 = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.choreNameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.valueTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.AddChorePicture = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\CreateChore.xaml"
            this.AddChorePicture.Click += new System.Windows.RoutedEventHandler(this.AddChorePicture_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.chorePictureImage = ((System.Windows.Controls.Image)(target));
            return;
            case 7:
            this.descriptionTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.Create = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\CreateChore.xaml"
            this.Create.Click += new System.Windows.RoutedEventHandler(this.Create_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

