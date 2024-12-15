using Azure.Identity;
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
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public event EventHandler inputEntered;
        public string username;
        public string password;
        public string mode;
        public LoginWindow()
        {
            InitializeComponent();
        }

        public void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            username = Username_Textbox.Text;
            password = Password_Passwordbox.Password;
            mode = "employee";

            inputEntered?.Invoke(this, EventArgs.Empty);
        }

        public void Guest_Login_Button_Click(Object sender, RoutedEventArgs e)
        {
            username = "guest";
            password = "1234";
            mode = "guest";

            inputEntered?.Invoke(this, EventArgs.Empty);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            //this.Visibility = Visibility.Hidden;
        }
    }
}
