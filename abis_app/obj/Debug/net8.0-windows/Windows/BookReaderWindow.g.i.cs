﻿#pragma checksum "..\..\..\..\Windows\BookReaderWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4BDFE4019E2CC84F29168CDF6E416587C58BE0FA"
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
    /// BookReaderWindow
    /// </summary>
    public partial class BookReaderWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\..\..\Windows\BookReaderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Add_BookReader_Button;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\Windows\BookReaderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Close_BookReader_Button;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\Windows\BookReaderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Search_Button;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\Windows\BookReaderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Isbn_Textbox;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\Windows\BookReaderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Title_Textbox;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\Windows\BookReaderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox GradebookNum_Textbox;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\Windows\BookReaderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Surname_Textbox;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\Windows\BookReaderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox Returned_Checkbox;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\Windows\BookReaderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid BookReader_Table;
        
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
            System.Uri resourceLocater = new System.Uri("/abis_app;V1.0.0.0;component/windows/bookreaderwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Windows\BookReaderWindow.xaml"
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
            this.Add_BookReader_Button = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\..\Windows\BookReaderWindow.xaml"
            this.Add_BookReader_Button.Click += new System.Windows.RoutedEventHandler(this.Add_BookReader_Button_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Close_BookReader_Button = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\..\Windows\BookReaderWindow.xaml"
            this.Close_BookReader_Button.Click += new System.Windows.RoutedEventHandler(this.Close_BookReader_Button_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Search_Button = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\..\..\Windows\BookReaderWindow.xaml"
            this.Search_Button.Click += new System.Windows.RoutedEventHandler(this.Search_BookReader_Button_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Isbn_Textbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.Title_Textbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.GradebookNum_Textbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.Surname_Textbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.Returned_Checkbox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 9:
            this.BookReader_Table = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

