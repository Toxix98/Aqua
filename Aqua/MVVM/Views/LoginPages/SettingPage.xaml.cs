using Aqua.MVVM.Models;
using Aqua.MVVM.ViewModels;
using Aqua.MVVM.Views.LoginPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Aqua.Pages
{
    /// <summary>
    /// Interaction logic for SettingPage.xaml
    /// </summary>
    public partial class SettingPage : Page
    {
        private LoginViewModel _loginViewModel;
        public SettingPage()
        {
            InitializeComponent();
            _loginViewModel = new LoginViewModel();
            DataContext = _loginViewModel;
            BindGrid();
        }

        public void BindGrid()
        {
            LoginInfo.ItemsSource = _loginViewModel.GetLogins();
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddOrEditeLoginPage addOrEditeLoginPage = new AddOrEditeLoginPage();
            addOrEditeLoginPage.ShowDialog();
            BindGrid();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            BindGrid();
        }

        private void btnDelet_Click(object sender, RoutedEventArgs e)
        {
            if (LoginInfo.SelectedItem != null)
            {
                string name = (LoginInfo.SelectedCells[1].Column.GetCellContent(LoginInfo.SelectedItem) as TextBlock)?.Text;
                Login Login = LoginInfo.SelectedItem as Login;

                if (MessageBox.Show($"آیا از حذف {name} مطمعن هستید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int log = Login.Id;
                    _loginViewModel.DeletLogin(log);
                    BindGrid();
                }
            }
        }
    }
}
