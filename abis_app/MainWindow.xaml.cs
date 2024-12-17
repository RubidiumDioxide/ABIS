using abis;
using Microsoft.EntityFrameworkCore;
using System.Data;
//using System.Text;
using System.Windows;
using System.Windows.Controls;
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
        public LoginWindow loginWindow;
        public string connectionString = "";
        private bool isLoginWindowOpened = false;
        private string mode = "guest"; // guest or employee

        public MainWindow()
        {
            InitializeComponent();
            Application.Current.MainWindow = this;
            Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
            //db = new AbisContext();
            //db.Books.Load();
            //db.Readers.Load();
            //db.BookReaders.Load();
            
            loginWindow = new LoginWindow();
            loginWindow.inputEntered += new EventHandler(loginWindowEntered);
            isLoginWindowOpened = true;
            loginWindow.Show();
            loginWindow.Focus();

            Book_Button.IsEnabled = false;
            Reader_Button.IsEnabled = false;
            BookReader_Button.IsEnabled = false;
            Reports_Button.IsEnabled = false;
        }

        private void loginWindowEntered(object sender, EventArgs e)
        {
            mode = loginWindow.mode;
            
            //lea
            //this.connectionString = "Server=WIN-4E7JKGBR3SV\\SQLEXPRESS;Database=abis;TrustServerCertificate=True;Encrypt=False;user id=" + loginWindow.username + ";password=" + loginWindow.password + ";";
            //kat
            this.connectionString = "Server=LAPTOP-FAIVFFI6\\SQLEXPRESS;Database=abis;TrustServerCertificate=True;Encrypt=False;user id=" + loginWindow.username + ";password=" + loginWindow.password + ";";

            try
            {
                db = new AbisContext(connectionString);
                db.Books.Load();
                db.Readers.Load();
                db.BookReaders.Load();
                db.BookHistories.Load();
                db.ReaderHistories.Load();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            
            loginWindow.Close();
            loginWindow.Visibility = Visibility.Collapsed;
            isLoginWindowOpened = false;

            Book_Button.IsEnabled = true;
            Reader_Button.IsEnabled = true;
            BookReader_Button.IsEnabled = true;
            Reports_Button.IsEnabled = true;
        }

        private void Book_Button_Click(object sender, RoutedEventArgs e)
        {
            if (bookWindow == null)
            {
                bookWindow = new BookWindow(mode);
                //bookWindow.Owner = this;
                bookWindow.LinkEvents();
            }

            bookWindow.Show();
            bookWindow.Focus();
        }

        private void Reader_Button_Click(object sender, RoutedEventArgs e)
        {
            if(readerWindow == null)
            {
                readerWindow = new ReaderWindow(mode);
                //readerWindow.Owner = this;
                readerWindow.LinkEvents();
            }

            readerWindow.Show();
            readerWindow.Focus();
        }
        
        private void BookReader_Button_Click(object sender, RoutedEventArgs e)
        {
            if (bookReaderWindow == null)
            {
                bookReaderWindow = new BookReaderWindow(mode);
                //bookReaderWindow.Owner = this;
                bookReaderWindow.LinkEvents();
            }

            bookReaderWindow.Show();
            bookReaderWindow.Focus();
        }

        private void Reports_Button_Click(object sender, RoutedEventArgs e)
        {
            if (reportsWindow == null)
            {
                reportsWindow = new ReportsWindow(mode);
                //reportsWindow.Owner = this;
            }
            
            reportsWindow.Show();
            reportsWindow.Focus();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {   
            Application.Current.Shutdown();
        }
    }
}