using abis;
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
    /// Логика взаимодействия для BookReaderInputWindow.xaml
    /// </summary>
    public partial class BookReaderInputWindow : Window
    {
        AbisContext db;
        public List<String> Inputs;
        public event EventHandler inputEntered;
        public string type = "";
        public long bookIsbn = 0;
        public int readerGradebookNum = 0;  

        public BookReaderInputWindow(AbisContext db, string _type, long _bookIsbn, int _readerGradebookNum)
        {
            type = _type;

            if (type == "edit")
            {
                bookIsbn = _bookIsbn;
                readerGradebookNum = _readerGradebookNum;
                
                InitializeComponent();

                BookReader bookReader = db.BookReaders.Where(b => b.BookIsbn == bookIsbn && b.ReaderGradebookNum == readerGradebookNum).FirstOrDefault();

                ReaderGradebookNum_Textbox.Text = bookReader.ReaderGradebookNum.ToString();
                BookIsbn_Textbox.Text = bookReader.BookIsbn.ToString();
                DateBorrowed_Textbox.Text = bookReader.DateBorrowed.ToString();
                DateReturned_Textbox.Text = bookReader.DateReturned.ToString();
                Returned_Textbox.Text = bookReader.Returned.ToString();

                foreach(TextBox t in Extensions.FindVisualChildren<TextBox>(this))
                {
                    t.IsEnabled = false;
                }

                DateReturned_Textbox.IsEnabled = true;
            }
        }

        public BookReaderInputWindow(string _type)
        {
            type = _type;

            if (type == "add")
            {
                InitializeComponent(); 

                foreach(TextBox t in Extensions.FindVisualChildren<TextBox>(this))
                {
                    t.IsEnabled = true;
                }

                DateReturned_Textbox.IsEnabled = false;
                Returned_Textbox.IsEnabled = false; 
            }
        }

        public void Input_Button_Click(object sender, RoutedEventArgs e)
        {
            Inputs = new List<String>();
            foreach (TextBox t in Extensions.FindVisualChildren<TextBox>(this))
            {
                Inputs.Add(t.Text);
            }

            inputEntered?.Invoke(this, EventArgs.Empty);
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }
    }
}
