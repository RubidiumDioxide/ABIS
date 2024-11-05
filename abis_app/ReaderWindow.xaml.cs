using abis;
using System;
/*using System.Collections.Generic;
using System.Linq;
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
    public partial class ReaderWindow : Window
    {
        public ReaderWindow()
        {
            InitializeComponent();

            //Reader_Table.ItemsSource = MainWindow.db.Readers.Local.ToBindingList().Select(c => new { c.GradebookNum, c.Surname, c.FirstName, c.LastName, c.GroupNum, c.DateOfBirth, c.Active, c.Debt });
            Reader_Table.ItemsSource = MainWindow.db.Readers.Local.ToBindingList();
        }

        private void Add_Reader_Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Placeholder", "Inputs data & add a reader");
        }

        private void Delete_Reader_Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Placeholder", "Inputs GradebookNum & deletes a reader");
        }

        private void Edit_Reader_Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Placeholder", "Inputs GradebookNum & edits a reader");
        }

        private void Search_Reader_Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Placeholder", "Performs search & alters the selection shown");
        }
    }
}
