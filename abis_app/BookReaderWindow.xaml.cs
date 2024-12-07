//using System;
//using System.Collections.Generic;
using abis;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

/*using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;*/

namespace abis_app
{
    /// <summary>
    /// Логика взаимодействия для BookReaderWindow.xaml
    /// </summary>
    public partial class BookReaderWindow : Window
    {
        private BookReaderInputWindow inputWindow;
        private bool isInputWindowOpen = false;
        private Dictionary<string, bool> lmc = new Dictionary<string, bool>() { { "BookIsbn_Textbox", false }, { "ReaderGradebookNum_Textbox", false } };

        public BookReaderWindow()
        {
            InitializeComponent();
            BookReaderTableRefresh();
        }

        private void Add_BookReader_Button_Click(object sender, RoutedEventArgs e)
        {
            inputWindow = new BookReaderInputWindow("add");
            inputWindow.Owner = this;
            inputWindow.inputEntered += new EventHandler(inputWindowEntered);
            isInputWindowOpen = true;
            inputWindow.Show(); 
        }

        private void Close_BookReader_Button_Click(object sender, RoutedEventArgs e)
        {
            if (BookReader_Table.SelectedItems.Count > 0)
            {
                //get isbn of the selected row 
                dynamic value = BookReader_Table.SelectedItem;

                //delete function
                try
                {
                    BookReaderTools.CloseBookReader(MainWindow.db, value.Id);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                //reset the datagrid
                this.BookReaderTableRefresh();
            }
            else
            {
                MessageBox.Show("No cell is selected ");
            }
        }

        /*private void Delete_BookReader_Button_Click(object sender, RoutedEventArgs e)
        {
            if (BookReader_Table.SelectedItems.Count > 0)
            {
                //get isbn of the selected row 
                dynamic value = BookReader_Table.SelectedItem;

                //delete function
                try
                {
                    BookReaderTools.DeleteBookReader(MainWindow.db, value.BookIsbn, value.ReaderGradebookNum);
                }
                catch
                {
                    MessageBox.Show("Failed to delete a BookReader");
                }


                //reset the datagrid
                this.BookReaderTableRefresh();
            }
            else
            {
                MessageBox.Show("No cell is selected ");
            }
        }*/

        /*private void Edit_BookReader_Button_Click(object sender, RoutedEventArgs e)
        {
            if (BookReader_Table.SelectedItems.Count > 0)
            {
                //get isbn of the selected row 
                dynamic value = BookReader_Table.SelectedItem;

                //edit 
                inputWindow = new BookReaderInputWindow(MainWindow.db, "edit", value.Id);
                inputWindow.Owner = this;
                inputWindow.inputEntered += new EventHandler(inputWindowEntered);
                isInputWindowOpen = true;
                inputWindow.Show();
            }
            else
            {
                MessageBox.Show("No cell is selected ");
            }
        }*/

        /*private void Search_BookReader_Button_Click(object sender, RoutedEventArgs e)
        {
            this.BookReader_Table.ItemsSource = null;

            var itemsSource = MainWindow.db.BookReaders.Local.ToBindingList().Select(c => new { c.BookIsbn, c.ReaderGradebookNum, c.DateBorrowed, c.DateReturned, c.DateDeadline, c.Returned});

            if (BookIsbn_Textbox.Text != "")
            {
                long bookIsbn = long.Parse(BookIsbn_Textbox.Text);
                itemsSource = itemsSource.Where(c => c.BookIsbn == bookIsbn);
            }

            if (ReaderGradebookNum_Textbox.Text != "")
            {
                string readerGradebookNum = ReaderGradebookNum_Textbox.Text;
                itemsSource = itemsSource.Where(c => c.ReaderGradebookNum.ToString() == readerGradebookNum);
            }

            BookReader_Table.ItemsSource = itemsSource;
        }*/

        void inputWindowEntered(object sender, EventArgs e)
        {
            if (inputWindow.type == "add")
            {
                try
                {
                    BookReaderTools.AddBookReader(MainWindow.db, inputWindow.Inputs);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (inputWindow.type == "edit")
            {
                try
                {
                    BookReaderTools.EditBookReader(MainWindow.db, inputWindow.id, inputWindow.Inputs);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
            BookReaderTableRefresh();
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

        private void BookReaderTableRefresh()
        {
            MainWindow.db.BookReaders.Load();
            this.BookReader_Table.ItemsSource = null;
            this.BookReader_Table.ItemsSource = MainWindow.db.BookReaders.Local.ToBindingList().Select(c => new { c.Id, c.ReaderGradebookNum, c.BookIsbn, c.DateBorrowed, c.DateReturned, c.DateDeadline, c.Returned });
        }
    }
}
