﻿#pragma checksum "..\..\..\ReaderInputWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B79267C7D77E19EA1B6FABBFB1C4C1A285999A1C"
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
    /// ReaderInputWindow
    /// </summary>
    public partial class ReaderInputWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\ReaderInputWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox GradebookNum_Textbox;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\ReaderInputWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Surname_Textbox;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\ReaderInputWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FirstName_Textbox;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\ReaderInputWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox LastName_Textbox;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\ReaderInputWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox GroupNum_Textbox;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\ReaderInputWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DateOfBirth_Textbox;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\ReaderInputWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox Active_Checkbox;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\ReaderInputWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox Debt_Checkbox;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\ReaderInputWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Input_Button;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.10.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/abis_app;component/readerinputwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ReaderInputWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.10.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.GradebookNum_Textbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.Surname_Textbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.FirstName_Textbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.LastName_Textbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.GroupNum_Textbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.DateOfBirth_Textbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.Active_Checkbox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 8:
            this.Debt_Checkbox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 9:
            this.Input_Button = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\ReaderInputWindow.xaml"
            this.Input_Button.Click += new System.Windows.RoutedEventHandler(this.Input_Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

