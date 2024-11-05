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

        public BookWindow()
        {
            InitializeComponent();
            
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


        private void Search_Book_Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Placeholder", "Performs search & alters the selection");
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
            this.Book_Table.ItemsSource = MainWindow.db.Books.Local.ToBindingList().Select(c => new { c.Isbn, c.Title, c.Pages, c.PublishingHouse, c.YearPublished, c.Description, c.Quantity });
        }
    }
}
