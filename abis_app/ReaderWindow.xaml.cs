﻿using abis;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

/*using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;*/

namespace abis_app
{
    /// <summary>
    /// Логика взаимодействия для ReaderWindow.xaml
    /// </summary>
    public partial class ReaderWindow : Window
    {
        private ReaderInputWindow inputWindow;
        private bool isInputWindowOpen = false;
        private Dictionary<string, bool> lmc = new Dictionary<string, bool>() { { "GradebookNum_Textbox", false }, { "Surname_Textbox", false }, { "FirstName_Textbox", false }, { "GroupNum_Textbox", false }, { "Active_Textbox", false }, { "Debt_Textbox", false } };
        
        public ReaderWindow()
        {
            InitializeComponent();
            ReaderTableRefresh(); 
        }

        private void Add_Reader_Button_Click(object sender, RoutedEventArgs e)
        {
            inputWindow = new ReaderInputWindow("add");
            //inputWindow.Owner = this;
            inputWindow.inputEntered += new EventHandler(inputWindowEntered);
            isInputWindowOpen = true;
            inputWindow.Show();
            inputWindow.Focus();
        }

        private void Delete_Reader_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Reader_Table.SelectedItems.Count > 0)
            {
                //get isbn of the selected row 
                dynamic value = Reader_Table.SelectedItem;

                //delete function
                try
                {
                    ReaderTools.DeleteReader(MainWindow.db, value.GradebookNum);
                }
                catch
                {
                    MessageBox.Show("Failed to delete a Reader");
                }

                //reset the datagrid
                this.ReaderTableRefresh();
            }
            else
            {
                MessageBox.Show("No cell is selected ");
            }
        }

        private void Edit_Reader_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Reader_Table.SelectedItems.Count > 0)
            {
                //get gredebookNum of the selected row 
                dynamic value = Reader_Table.SelectedItem;

                //edit 
                inputWindow = new ReaderInputWindow(MainWindow.db, "edit", value.GradebookNum);
                //inputWindow.Owner = this;
                inputWindow.inputEntered += new EventHandler(inputWindowEntered);
                isInputWindowOpen = true;
                inputWindow.Show();
                inputWindow.Focus();
            }
            else
            {
                MessageBox.Show("No cell is selected ");
            }
        }

        private void Search_Reader_Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Placeholder", "Performs search & alters the selection shown");
        }

        void inputWindowEntered(object sender, EventArgs e)
        {
            if (inputWindow.type == "add")
            {
                try
                {
                    ReaderTools.AddReader(MainWindow.db, inputWindow.Inputs);
                }
                catch
                {
                    MessageBox.Show("Failed to add a Reader");
                }
            }
            if (inputWindow.type == "edit")
            {
                try
                {
                    ReaderTools.EditReader(MainWindow.db, inputWindow.gradebookNum, inputWindow.Inputs);
                }
                catch
                {
                    MessageBox.Show("Failed to edit a Reader");
                }
            }

            ReaderTableRefresh();
            inputWindow.Close();
        }

        public void LinkEvents()
        {
            foreach (TextBox t in Extensions.FindVisualChildren<TextBox>(this))
            {
                t.GotFocus += new System.Windows.RoutedEventHandler(LMConTextbox);
            }
        }

        void LMConTextbox(object sender, System.Windows.RoutedEventArgs e)
        {
            foreach (TextBox t in Extensions.FindVisualChildren<TextBox>(this))
            {
                if ((sender as TextBox) == t && lmc[(sender as TextBox).Name] == false)
                {
                    (sender as TextBox).Text = "";
                    lmc[(sender as TextBox).Name] = true;
                }
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }

        public void ReaderTableRefresh()
        {
            MainWindow.db.Readers.Load();
            this.Reader_Table.ItemsSource = null;
            this.Reader_Table.ItemsSource = MainWindow.db.Readers.Local.ToBindingList().Select(c => new { c.GradebookNum, c.Surname, c.FirstName, c.LastName, c.GroupNum, c.DateOfBirth, c.Active, c.Debt }); 
        }
    }
}
