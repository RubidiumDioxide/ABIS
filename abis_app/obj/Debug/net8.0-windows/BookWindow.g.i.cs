﻿#pragma checksum "..\..\..\BookWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1079B0DFD8436BF4235DF2D057F9A6C0337096C7"
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
    /// BookWindow
    /// </summary>
    public partial class BookWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\BookWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Add_Book_Button;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\BookWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Deactivate_Book_Button;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\BookWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Edit_Book_Button;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\BookWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Search_Book_Button;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\BookWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Isbn_Textbox;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\BookWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Title_Textbox;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\BookWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox YearPublished_Textbox;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\BookWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid Book_Table;
        
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
            System.Uri resourceLocater = new System.Uri("/abis_app;component/bookwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\BookWindow.xaml"
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
            this.Add_Book_Button = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\BookWindow.xaml"
            this.Add_Book_Button.Click += new System.Windows.RoutedEventHandler(this.Add_Book_Button_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Deactivate_Book_Button = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\BookWindow.xaml"
            this.Deactivate_Book_Button.Click += new System.Windows.RoutedEventHandler(this.Deactivate_Book_Button_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Edit_Book_Button = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\BookWindow.xaml"
            this.Edit_Book_Button.Click += new System.Windows.RoutedEventHandler(this.Edit_Book_Button_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Search_Book_Button = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\BookWindow.xaml"
            this.Search_Book_Button.Click += new System.Windows.RoutedEventHandler(this.Search_Book_Button_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Isbn_Textbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.Title_Textbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.YearPublished_Textbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.Book_Table = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

