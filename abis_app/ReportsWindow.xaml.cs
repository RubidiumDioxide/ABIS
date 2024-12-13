using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Логика взаимодействия для ReportsWindow.xaml
    /// </summary>
    public partial class ReportsWindow : Window
    {
        private string type = "BookHistory";
        public ReportsWindow()
        {
            InitializeComponent();
            ReportsTableRefresh();
        }

        public void BookHistory_Button_Click(object sender, RoutedEventArgs e)
        {
            type = "BookHistory";

            ReportsTableRefresh();
        }

        public void ReaderHistory_Button_Click(object sender, RoutedEventArgs e)
        {
            type = "ReaderHistory";

            ReportsTableRefresh();
        }

        /*public void Reports_Book_Button_Click(object sender, RoutedEventArgs e)
                {
                    MessageBoxResult result = MessageBox.Show("Placeholder", "Show a table");
                }*/

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            ReportsTableRefresh();
        }

        public void ReportsTableRefresh()
        {
            if(type == "BookHistory")
            {
                MainWindow.db.BookHistories.Load();
                this.Reports_Table.ItemsSource = null;
                this.Reports_Table.ItemsSource = MainWindow.db.BookHistories.Local.ToBindingList().Select(c => new { c.OperationId, c.BookIsbn, c.Quantity, c.Action, c.Date });
            }
            if (type == "ReaderHistory")
            {
                MainWindow.db.ReaderHistories.Load();
                this.Reports_Table.ItemsSource = null;
                this.Reports_Table.ItemsSource = MainWindow.db.ReaderHistories.Local.ToBindingList().Select(c => new { c.OperationId, c.ReaderGradebookNum, c.Action, c.Date });
            }
        }
    }
}
