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
    /// Логика взаимодействия для InputWindow.xaml
    /// </summary>
    public partial class BookInputWindow : Window
    {
        AbisContext db;
        public List<String> Inputs;
        public event EventHandler inputEntered;
        public string type = "";
        public long isbn = 0000000000000;

        public BookInputWindow(AbisContext db, string _type, long _isbn)
        {
            type = _type;
            
            if (type == "edit")
            {
                isbn = _isbn;

                InitializeComponent();

                Book book = db.Books.Where(b => b.Isbn == isbn).FirstOrDefault();

                ISBN_Textbox.Text = book.Isbn.ToString();
                Title_Textbox.Text = book.Title.ToString();
                Pages_Textbox.Text = book.Pages.ToString();
                PublishingHouse_Textbox.Text = book.PublishingHouse.ToString();
                YearPublished_Textbox.Text = book.YearPublished.ToString();
                Description_Textbox.Text = book.Description.ToString();
                Quantity_Textbox.Text = book.Quantity.ToString();

                ISBN_Textbox.IsEnabled = false;
            }
        }

        public BookInputWindow(string _type)
        {
            type = _type;

            if (type == "add")
            {
                InitializeComponent();

                ISBN_Textbox.IsEnabled = true;
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

        private void Input_Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
