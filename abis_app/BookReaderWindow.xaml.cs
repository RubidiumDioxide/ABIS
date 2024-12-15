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
        private Dictionary<string, bool> lmc = new Dictionary<string, bool>() { { "Isbn_Textbox", false }, { "Title_Textbox", false}, { "GradebookNum_Textbox", false }, { "Surname_Textbox", false } };
        private string mode;

        public BookReaderWindow(string mode)
        {
            InitializeComponent();
            BookReaderTableRefresh();
            this.mode = mode;

            if(mode == "guest")
            {
                Add_BookReader_Button.IsEnabled = false;
                Add_BookReader_Button.Visibility = Visibility.Collapsed;
                Close_BookReader_Button.IsEnabled = false;
                Close_BookReader_Button.Visibility = Visibility.Collapsed;
            }
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

        private void Search_BookReader_Button_Click(object sender, RoutedEventArgs e)
        {
            this.BookReader_Table.ItemsSource = null;

            //
            var itemsSource = BookReaderTools.LoadTable(MainWindow.db);

            if (Isbn_Textbox.Text != "" && Isbn_Textbox.Text != "ISBN")
            {
                try
                {
                    long bookIsbn = long.Parse(Isbn_Textbox.Text);
                    itemsSource = itemsSource.Where(c => c.Isbn == bookIsbn).ToList();
                }
                catch { }
            }

            if (Title_Textbox.Text != "" && Title_Textbox.Text != "Название книги")
            {
                try
                {
                    string title = Title_Textbox.Text;
                    itemsSource = itemsSource.Where(c => c.Title == title).ToList();
                }
                catch { }
            }

            if (GradebookNum_Textbox.Text != "" && GradebookNum_Textbox.Text != "Номер зачетной книжки")
            {
                try
                {
                    string gradebookNum = GradebookNum_Textbox.Text;
                    itemsSource = itemsSource.Where(c => c.GradebookNum.ToString() == gradebookNum).ToList();
                }
                catch { }  
            }

            if (Surname_Textbox.Text != "" && Surname_Textbox.Text != "Фамилия студента")
            {
                try
                {
                    string surname = Surname_Textbox.Text;
                    itemsSource = itemsSource.Where(c => c.Surname.ToString() == surname).ToList();
                }
                catch { }
            }

            if (Returned_Checkbox.IsChecked != null)
            {
                try
                {
                    bool? returned = Returned_Checkbox.IsChecked;
                    itemsSource = itemsSource.Where(c => c.Returned == returned).ToList();
                }
                catch { }
            }


            BookReader_Table.ItemsSource = itemsSource;
        }

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
            this.BookReader_Table.ItemsSource = null;
            this.BookReader_Table.ItemsSource = BookReaderTools.LoadTable(MainWindow.db);
        }
    }
}
