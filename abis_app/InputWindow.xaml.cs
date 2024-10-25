using abis;
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
    /// Логика взаимодействия для InputWindow.xaml
    /// </summary>
    public partial class InputWindow : Window
    {
        AbisContext db = new AbisContext();
        private List<String> Inputs;
        public InputWindow()
        {
            InitializeComponent();
        }

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj == null) yield return (T)Enumerable.Empty<T>();
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                DependencyObject ithChild = VisualTreeHelper.GetChild(depObj, i);
                if (ithChild == null) continue;
                if (ithChild is T t) yield return t;
                foreach (T childOfChild in FindVisualChildren<T>(ithChild)) yield return childOfChild;
            }
        }

        private void Input_Button_Click(object sender, RoutedEventArgs e)
        {
            Inputs = new List<String>();
            foreach (TextBox t in FindVisualChildren<TextBox>(this))
            {
                Inputs.Add(t.Text);
            }

            db.Add(new Book { Isbn = long.Parse(Inputs[0]), Title = Inputs[1], Pages = short.Parse(Inputs[2]), PublishingHouse = Inputs[3], YearPublished = short.Parse(Inputs[4]), Description = Inputs[5], Quantity = byte.Parse(Inputs[6]) });
            db.SaveChanges();

            this.Close();
        }

        private void ISBN_TextBox_TextChanged(object sender, TextChangedEventArgs e){}
        private void Title_TextBox_TextChanged(object sender, TextChangedEventArgs e) { }
        private void Pages_TextBox_TextChanged(object sender, TextChangedEventArgs e) { }
        private void PublishingHouse_TextBox_TextChanged(object sender, TextChangedEventArgs e) { }
        private void YearPublished_TextBox_TextChanged(object sender, TextChangedEventArgs e) { }
        private void Description_TextBox_TextChanged(object sender, TextChangedEventArgs e) { }
        private void Quantity_TextBox_TextChanged(object sender, TextChangedEventArgs e) { }
    }
}
