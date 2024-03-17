using Aqua;
using Aqua.MVVM.ViewModels;
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

namespace ACCAPT
{
    public partial class LoginPage : Window
    {
        private MainWindow mainWindow;
        private LoginViewModel _loginViewModel;
        public LoginPage(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            _loginViewModel = new LoginViewModel();
            DataContext = _loginViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            var username = txtUserName.Text;
            var password = txtPassword.Password.ToString();

            if (_loginViewModel.ValidateLogin(username, password))
            {
                this.Close();
                mainWindow.id = 0;
                mainWindow.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("نام کاربری یا رمز عبور اشتباه است.");
            }
        }
    }
}
