﻿#pragma checksum "..\..\..\ManagerWindow_1.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A9BA69E30523FD53CE8BE672CC705B69BBC76984"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using BookShopApplication;
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


namespace BookShopApplication {
    
    
    /// <summary>
    /// ManagerWindow_1
    /// </summary>
    public partial class ManagerWindow_1 : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 66 "..\..\..\ManagerWindow_1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AuFName_E;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\ManagerWindow_1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AuLName_E;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\ManagerWindow_1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox AuListBox;
        
        #line default
        #line hidden
        
        
        #line 117 "..\..\..\ManagerWindow_1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox GeFName_E;
        
        #line default
        #line hidden
        
        
        #line 125 "..\..\..\ManagerWindow_1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox GeListBox;
        
        #line default
        #line hidden
        
        
        #line 166 "..\..\..\ManagerWindow_1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PuFName_E;
        
        #line default
        #line hidden
        
        
        #line 174 "..\..\..\ManagerWindow_1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox PuListBox;
        
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
            System.Uri resourceLocater = new System.Uri("/BookShopApplication;component/managerwindow_1.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ManagerWindow_1.xaml"
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
            this.AuFName_E = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.AuLName_E = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.AuListBox = ((System.Windows.Controls.ListBox)(target));
            return;
            case 4:
            
            #line 79 "..\..\..\ManagerWindow_1.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AuAdd_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 87 "..\..\..\ManagerWindow_1.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AuDelete_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.GeFName_E = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.GeListBox = ((System.Windows.Controls.ListBox)(target));
            return;
            case 8:
            
            #line 128 "..\..\..\ManagerWindow_1.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.GeAdd_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 136 "..\..\..\ManagerWindow_1.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.GeDelete_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.PuFName_E = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.PuListBox = ((System.Windows.Controls.ListBox)(target));
            return;
            case 12:
            
            #line 177 "..\..\..\ManagerWindow_1.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PuAdd_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 185 "..\..\..\ManagerWindow_1.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PuDelete_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

