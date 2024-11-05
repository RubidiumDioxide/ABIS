using abis;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace abis_app
{
    /// <summary>
    /// Логика взаимодействия для DataWindow.xaml
    /// </summary>
    public partial class DataWindow : Window
    {
        private AbisContext db; 
        public DataWindow()
        {
            InitializeComponent();

            db = new AbisContext();
            db.Books.Load();
            this.DataContext = db.Books.Local.ToBindingList();
            //this.DataContext = db.Books.Local;
        }
        private void Add_Book_Button_Click(object sender, RoutedEventArgs e)
        {
            InputWindow inputWindow = new InputWindow();
            inputWindow.Owner = this;
            inputWindow.Show();
        }

        private void Book_Table_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
