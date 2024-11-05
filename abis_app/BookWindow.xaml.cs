using abis;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
/*using System.Linq;
using System.Text;
using System.Threading.Tasks;*/
using System.Windows;
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
        public BookWindow()
        {
            InitializeComponent();

            Book_Table.ItemsSource = MainWindow.db.Books.Local.ToBindingList().Select(c => new { c.Isbn, c.Title, c.Pages, c.PublishingHouse, c.YearPublished, c.Description, c.Quantity}); 
        }
        private void Add_Book_Button_Click(object sender, RoutedEventArgs e)
        {
            /*InputWindow inputWindow = new InputWindow();
            inputWindow.Owner = this;
            inputWindow.Show();*/

            MessageBoxResult result = MessageBox.Show("Placeholder", "Inputs data & add a book");
        }

        private void Delete_Book_Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Placeholder", "Inputs ISBN & delete a book");
        }

        private void Edit_Book_Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Placeholder", "Inputs ISBN & edit a book");
        }

        private void Search_Book_Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Placeholder", "Performs search & alters the selection");
        }

        private void Book_Table_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }




        /*private void Book_Table_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            Book b = e.Row.Item as Book;
            MessageBoxResult m = MessageBox.Show($"{b.Isbn}{b.Title}{b.Pages}{b.PublishingHouse}{b.YearPublished}{b.Description}{b.Quantity}");
        }*/
    }
}
