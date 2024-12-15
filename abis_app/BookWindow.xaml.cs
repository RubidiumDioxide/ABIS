using abis;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

/*using System.Linq;
using System.Text;
using System.Threading.Tasks;*/
using System.Windows;
using System.Windows.Controls;
/*using System.Windows.Controls;
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
    public partial class BookWindow : Window
    {
        private BookInputWindow inputWindow;
        private bool isInputWindowOpen = false;
        private Dictionary<string, bool> lmc = new Dictionary<string, bool>() { { "Isbn_Textbox", false },{ "Title_Textbox", false}, { "YearPublished_Textbox", false} };
        private string mode; 

        public BookWindow(string mode)
        {
            InitializeComponent();
            BookTableRefresh();
            this.mode = mode;

            if (mode == "guest")
            {
                Add_Book_Button.IsEnabled = false;
                Add_Book_Button.Visibility = Visibility.Collapsed;
                Delete_Book_Button.IsEnabled = false;
                Delete_Book_Button.Visibility = Visibility.Collapsed;
                Deactivate_Book_Button.IsEnabled = false;
                Deactivate_Book_Button.Visibility = Visibility.Collapsed;
                Edit_Book_Button.IsEnabled = false;
                Edit_Book_Button.Visibility = Visibility.Collapsed;
            }
        }

        private void Add_Book_Button_Click(object sender, RoutedEventArgs e)
        {
            inputWindow = new BookInputWindow("add");
            //inputWindow.Owner = this;
            inputWindow.inputEntered += new EventHandler(inputWindowEntered);
            isInputWindowOpen = true;
            inputWindow.Show();
            inputWindow.Focus(); 
        }

        private void Deactivate_Book_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Book_Table.SelectedItems.Count > 0)
            {
                //get isbn of the selected row 
                dynamic value = Book_Table.SelectedItem;

                //deactivate function
                try
                {
                    BookTools.DeactivateBook(MainWindow.db, value.Isbn);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("No cell is selected ");
            }

            BookTableRefresh();
        }

        private void Delete_Book_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Book_Table.SelectedItems.Count > 0)
            {
                //get isbn of the selected row 
                dynamic value = Book_Table.SelectedItem;

                //delete function
                try
                {
                    BookTools.DeleteBook(MainWindow.db, value.Isbn); 
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("No cell is selected ");
            }

            this.BookTableRefresh();
        }

        private void Edit_Book_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Book_Table.SelectedItems.Count > 0)
            {
                //get isbn of the selected row 
                dynamic value = Book_Table.SelectedItem;

                //edit 
                inputWindow = new BookInputWindow(MainWindow.db, "edit", value.Isbn);
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

        private void Search_Book_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Book_Table.ItemsSource = null;

            var itemsSource = MainWindow.db.Books.Local.ToBindingList().Select(c => new { c.Isbn, c.Title, c.Author, c.Pages, c.PublishingHouse, c.YearPublished, c.Description, c.Quantity, c.Active });

            if (Isbn_Textbox.Text != "" && Isbn_Textbox.Text != "ISBN") 
            {
                try
                {
                    long isbn = long.Parse(Isbn_Textbox.Text);
                    itemsSource = itemsSource.Where(c => c.Isbn == isbn);
                }
                catch { }
            }

            if (Title_Textbox.Text != "" && Title_Textbox.Text != "Название книги")
            {
                try
                {
                    string title = Title_Textbox.Text;
                    itemsSource = itemsSource.Where(c => c.Title == title);
                }
                catch { }
            }

            if (YearPublished_Textbox.Text != "" && YearPublished_Textbox.Text != "Год")
            {
                try
                {
                    int year_published = int.Parse(YearPublished_Textbox.Text);
                    itemsSource = itemsSource.Where(c => c.YearPublished == year_published);
                }
                catch { }
            }
            
            if (Active_Checkbox.IsChecked != null)
            {
                try
                {
                    bool? active = Active_Checkbox.IsChecked; 
                    itemsSource = itemsSource.Where(c => c.Active == active);
                }
                catch { }
            }

            Book_Table.ItemsSource = itemsSource;
        }

        void inputWindowEntered(object sender, EventArgs e)
        {
            if (inputWindow.type == "add")
            {
                try
                {
                    BookTools.AddBook(MainWindow.db, inputWindow.Inputs);
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
                    BookTools.EditBook(MainWindow.db, inputWindow.isbn, inputWindow.Inputs);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            BookTableRefresh();
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
                if ((sender as TextBox) == t && lmc[(sender as TextBox).Name] == false) {
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

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            BookTableRefresh();
        }

        public void BookTableRefresh()
        {
            MainWindow.db.Books.Load();
            this.Book_Table.ItemsSource = null;
            this.Book_Table.ItemsSource = MainWindow.db.Books.Local.ToBindingList().Select(c => new { c.Isbn, c.Title, c.Author, c.Pages, c.PublishingHouse, c.YearPublished, c.Description, c.Quantity, c.Active });
        }
    }
}
