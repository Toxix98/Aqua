using Aqua;
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
        public LoginPage(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            if (txtUserName.Text == "admin" && txtPassword.Password.ToString() == "admin")
            {
                this.Close();
                mainWindow.id = 0;
                mainWindow.Visibility = Visibility.Visible;
            }
            else
            {
                txtUserName.Text = "mahan";
            }
        }
    }
}
