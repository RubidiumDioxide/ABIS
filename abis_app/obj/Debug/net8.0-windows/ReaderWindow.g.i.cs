﻿#pragma checksum "..\..\..\ReaderWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7D57B2698AF91DE0C6899BC0A132601104391F6A"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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
using abis_app;


namespace abis_app {
    
    
    /// <summary>
    /// ReaderWindow
    /// </summary>
    public partial class ReaderWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\ReaderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Add_Reader_Button;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\ReaderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Delete_Reader_Button;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\ReaderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Edit_Reader_Button;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\ReaderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Search_Button;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\ReaderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid Reader_Table;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.8.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/abis_app;component/readerwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ReaderWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.8.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Add_Reader_Button = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\ReaderWindow.xaml"
            this.Add_Reader_Button.Click += new System.Windows.RoutedEventHandler(this.Add_Reader_Button_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Delete_Reader_Button = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\ReaderWindow.xaml"
            this.Delete_Reader_Button.Click += new System.Windows.RoutedEventHandler(this.Delete_Reader_Button_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Edit_Reader_Button = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\ReaderWindow.xaml"
            this.Edit_Reader_Button.Click += new System.Windows.RoutedEventHandler(this.Edit_Reader_Button_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Search_Button = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\..\ReaderWindow.xaml"
            this.Search_Button.Click += new System.Windows.RoutedEventHandler(this.Search_Reader_Button_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Reader_Table = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

