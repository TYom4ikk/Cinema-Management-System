﻿#pragma checksum "..\..\..\View\SellTicketPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "CC39891094A28BD057460891DB349B170FC843B8E29C0917448586CA14252139"
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


namespace CinemaManagementSystem.View {
    
    
    /// <summary>
    /// SellTicketPage
    /// </summary>
    public partial class SellTicketPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\View\SellTicketPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock FilmTitleBlock;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\View\SellTicketPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock SessionInfoBlock;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\View\SellTicketPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox RowComboBox;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\View\SellTicketPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox SeatComboBox;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\View\SellTicketPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PriceTextBox;
        
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
            System.Uri resourceLocater = new System.Uri("/CinemaManagementSystem;component/view/sellticketpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\SellTicketPage.xaml"
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
            this.FilmTitleBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.SessionInfoBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.RowComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 43 "..\..\..\View\SellTicketPage.xaml"
            this.RowComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.RowComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.SeatComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.PriceTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            
            #line 71 "..\..\..\View\SellTicketPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SellButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 76 "..\..\..\View\SellTicketPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PrintButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 80 "..\..\..\View\SellTicketPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CancelButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

