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
        private InputWindow inputWindow;
        private bool isInputWindowOpen = false;
        private bool lmcIsbn = false;
        private bool lmcTitle = false;
        private bool lmcYearPublished = false;

        public BookWindow()
        {
            InitializeComponent();

            Isbn_Textbox.GotFocus += new System.Windows.RoutedEventHandler(LMConIsbnTextbox);
            Title_Textbox.GotFocus += new System.Windows.RoutedEventHandler(LMConTitleTextbox);
            YearPublished_Textbox.GotFocus += new System.Windows.RoutedEventHandler(LMConYearPublishedTextbox);

            BookTableRefresh(); 
        }

        private void Add_Book_Button_Click(object sender, RoutedEventArgs e)
        {
            inputWindow = new InputWindow("add");
            inputWindow.Owner = this;
            inputWindow.inputEntered += new EventHandler(inputWindowEntered);
            isInputWindowOpen = true;
            inputWindow.Show();
        }

        private void Delete_Book_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Book_Table.SelectedItems.Count > 0)
            {
                //get isbn of the selected row 
                dynamic value = Book_Table.SelectedItem;

                //delete function
                BookTools.DeleteBook(MainWindow.db, value.Isbn);

                //reset the datagrid
                this.BookTableRefresh();
            }
            else
            {
                MessageBox.Show("No cell is selected ");
            }
        }

        private void Edit_Book_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Book_Table.SelectedItems.Count > 0)
            {
                //get isbn of the selected row 
                dynamic value = Book_Table.SelectedItem;

                //edit 
                inputWindow = new InputWindow(MainWindow.db, "edit", value.Isbn);
                inputWindow.Owner = this;
                inputWindow.inputEntered += new EventHandler(inputWindowEntered);
                isInputWindowOpen = true;
                inputWindow.Show();
            }
            else
            {
                MessageBox.Show("No cell is selected ");
            }
        }

        void inputWindowEntered(object sender, EventArgs e)
        {
            if (inputWindow.type == "add")
            {
                BookTools.AddBook(MainWindow.db, inputWindow.Inputs);
            }
            if (inputWindow.type == "edit")
            {
                BookTools.EditBook(MainWindow.db, inputWindow.isbn, inputWindow.Inputs); 
            }

            BookTableRefresh();
            inputWindow.Close();
        }

        void LMConIsbnTextbox(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!lmcIsbn)
            {
                Isbn_Textbox.Text = "";
                lmcIsbn = true;
            }
        }

        void LMConTitleTextbox(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!lmcTitle)
            {
                Title_Textbox.Text = "";
                lmcTitle = true;
            }
        }

        void LMConYearPublishedTextbox(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!lmcYearPublished)
            {
                YearPublished_Textbox.Text = "";
                lmcYearPublished = true;
            }
        }

        private void Search_Book_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Book_Table.ItemsSource = null;

            var itemsSource = MainWindow.db.Books.Local.ToBindingList().Select(c => new { c.Isbn, c.Title, c.Pages, c.PublishingHouse, c.YearPublished, c.Description, c.Quantity, c.Authors });

            if (Isbn_Textbox.Text != "")
            {
                long isbn = long.Parse(Isbn_Textbox.Text);
                itemsSource = itemsSource.Where(c=>c.Isbn==isbn);
            }

            if (Title_Textbox.Text != "")
            {
                string title = Title_Textbox.Text;
                itemsSource = itemsSource.Where(c => c.Title == title);
            }


            if (YearPublished_Textbox.Text != "")
            {
                int year_published = int.Parse(YearPublished_Textbox.Text);
                itemsSource = itemsSource.Where(c => c.YearPublished == year_published);
            }

            Book_Table.ItemsSource = itemsSource;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }

        public void BookTableRefresh()
        {
            MainWindow.db.Books.Load();
            this.Book_Table.ItemsSource = null;
            this.Book_Table.ItemsSource = MainWindow.db.Books.Local.ToBindingList().Select(c => new { c.Isbn, c.Title, c.Pages, c.PublishingHouse, c.YearPublished, c.Description, c.Quantity, c.Authors });
        }
    }
}
