using abis;
using Microsoft.EntityFrameworkCore;
using System.Data;
//using System.Text;
using System.Windows;
/*using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;*/

namespace abis_app
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static AbisContext db; 
        public BookWindow bookWindow;
        public ReaderWindow readerWindow;
        public BookReaderWindow bookReaderWindow;
        public ReportsWindow reportsWindow;

        public MainWindow()
        {
            InitializeComponent();
            db = new AbisContext();
            db.Books.Load();
            db.Readers.Load();
            db.BookReaders.Load();
        }
        private void Book_Button_Click(object sender, RoutedEventArgs e)
        {
            if (bookWindow == null)
            {
                bookWindow = new BookWindow();
                bookWindow.Owner = this;
                bookWindow.Show();
            }
            else
            {
                bookWindow.Focus();
            }
        }

        private void Reader_Button_Click(object sender, RoutedEventArgs e)
        {
            if(readerWindow == null)
            {
                readerWindow = new ReaderWindow();
                readerWindow.Owner = this;
                readerWindow.Show();
            }
            else
            {
                readerWindow.Focus();
            }
        }
        
        private void BookReader_Button_Click(object sender, RoutedEventArgs e)
        {
            if (bookReaderWindow == null)
            {
                bookReaderWindow = new BookReaderWindow();
                bookReaderWindow.Owner = this;
                bookReaderWindow.Show();
            }
            else
            {
                bookReaderWindow.Focus();
            }
        }

        private void Reports_Button_Click(object sender, RoutedEventArgs e)
        {
            if (reportsWindow == null)
            {
                reportsWindow = new ReportsWindow();
                reportsWindow.Owner = this;
                reportsWindow.Show();
            }
            else
            {
                reportsWindow.Focus();
            }
        }
    }
}