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
    public partial class ReaderInputWindow : Window
    {
        AbisContext db;
        public List<String> Inputs;
        public event EventHandler inputEntered;
        public string type = "";
        //public long isbn = 0000000000000;

        public ReaderInputWindow(AbisContext db, string _type, long _gradebookNum)
        {
            type = _type;
            
            if (type == "edit")
            {
                //isbn = _isbn;

                InitializeComponent();

                //Book book = db.Books.Where(b => b.Isbn == isbn).FirstOrDefault();
                Reader reader = db.Readers.Where(r => r.GradebookNum == _gradebookNum).FirstOrDefault();

                /*ISBN_Textbox.Text = book.Isbn.ToString();
                Title_Textbox.Text = book.Title.ToString();
                Pages_Textbox.Text = book.Pages.ToString();
                PublishingHouse_Textbox.Text = book.PublishingHouse.ToString();
                YearPublished_Textbox.Text = book.YearPublished.ToString();
                Description_Textbox.Text = book.Description.ToString();
                Quantity_Textbox.Text = book.Quantity.ToString();*/

                GradebookNum_Textbox.Text = reader.GradebookNum.ToString();
                Surname_Textbox.Text = reader.Surname.ToString();
                FirstName_Textbox.Text = reader.FirstName.ToString();
                LastName_Textbox.Text = reader.LastName.ToString();
                GroupNum_Textbox.Text = reader.GroupNum.ToString();
                DateOfBirth_Textbox.Text = reader.DateOfBirth.ToString();
                Active_Textbox.Text = reader.Active.ToString();
                Debt_Textbox.Text = reader.Debt.ToString();

                GradebookNum_Textbox.IsEnabled = false;
            }
        }

        public ReaderInputWindow(string _type)
        {
            type = _type;

            if (type == "add")
            {
                InitializeComponent();

                GradebookNum_Textbox.IsEnabled = true;
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

        //potentially useless, remove later if useless still
        private void ISBN_TextBox_TextChanged(object sender, TextChangedEventArgs e){}
        private void Title_TextBox_TextChanged(object sender, TextChangedEventArgs e) { }
        private void Pages_TextBox_TextChanged(object sender, TextChangedEventArgs e) { }
        private void PublishingHouse_TextBox_TextChanged(object sender, TextChangedEventArgs e) { }
        private void YearPublished_TextBox_TextChanged(object sender, TextChangedEventArgs e) { }
        private void Description_TextBox_TextChanged(object sender, TextChangedEventArgs e) { }
        private void Quantity_TextBox_TextChanged(object sender, TextChangedEventArgs e) { }

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }
    }
}
