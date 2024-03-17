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

namespace Aqua.MVVM.Views.LoginPages
{
    /// <summary>
    /// Interaction logic for AddOrEditeLoginPage.xaml
    /// </summary>
    public partial class AddOrEditeLoginPage : Window
    {
        private LoginViewModel _loginViewModel;
        public string StatuceMessage { get; set; }

        public AddOrEditeLoginPage()
        {
            InitializeComponent();
            _loginViewModel = new LoginViewModel();
            DataContext = _loginViewModel;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _loginViewModel.SaveLogin(txtUserName.Text, txtPassword.Text);
            }
            catch(Exception ex)
            {
                StatuceMessage = ex.Message;
                MessageBox.Show(StatuceMessage, "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
