using abis;
using abis.Entities;
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
        public long id;

        public BookReaderInputWindow(AbisContext db, string _type, long _id)
        {
            type = _type;

            if (type == "edit")
            {
                id = _id;
                
                InitializeComponent();

                BookReader bookReader = db.BookReaders.Find(id);

                ReaderGradebookNum_Textbox.Text = bookReader.ReaderGradebookNum.ToString();
                BookIsbn_Textbox.Text = bookReader.BookIsbn.ToString();
                /*DateBorrowed_Textbox.Text = bookReader.DateBorrowed.ToString();
                DateReturned_Textbox.Text = bookReader.DateReturned.ToString();
                DateDeadline_Textbox.Text = bookReader.DateDeadline.ToString();
                Returned_Textbox.Text = bookReader.Returned.ToString();*/

                ReaderGradebookNum_Textbox.IsEnabled = false;
                BookIsbn_Textbox.IsEnabled = false;
                /*DateBorrowed_Textbox.IsEnabled = false;
                DateReturned_Textbox.IsEnabled = true; 
                DateDeadline_Textbox.IsEnabled = true;
                Returned_Textbox.IsEnabled = true;*/
            }
        }

        public BookReaderInputWindow(string _type)
        {
            type = _type;

            if (type == "add")
            {
                InitializeComponent(); 

                ReaderGradebookNum_Textbox.IsEnabled = true;
                BookIsbn_Textbox.IsEnabled = true;
                /*DateBorrowed_Textbox.IsEnabled = true;
                DateReturned_Textbox.IsEnabled = false;
                DateDeadline_Textbox.IsEnabled = false;
                Returned_Textbox.IsEnabled = false;*/
            }
        }

        public void Input_Button_Click(object sender, RoutedEventArgs e)
        {
            Inputs = new List<String>();
            foreach (TextBox t in Extensions.FindVisualChildren<TextBox>(this))
            {
                if (t.IsEnabled == true)
                {
                    Inputs.Add(t.Text);
                }
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
