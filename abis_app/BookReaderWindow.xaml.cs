//using System;
//using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;

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
        public BookReaderWindow()
        {
            InitializeComponent();

            BookReader_Table.ItemsSource = MainWindow.db.BookReaders.Local.ToBindingList();
        }

        private void Add_BookReader_Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Placeholder", "Inputs data & add a reader");
        }

        private void Delete_BookReader_Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Placeholder", "Inputs GradebookNum & deletes a reader");
        }

        private void Edit_BookReader_Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Placeholder", "Inputs GradebookNum & edits a reader");
        }

        private void Search_BookReader_Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Placeholder", "Performs search & alters the selection shown");
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }
    }
}
