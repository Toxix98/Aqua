using ACCAPT;
using Aqua.Pages;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Aqua;

namespace Aqua
{
    public partial class MainWindow : Window
    {
        public int id = -1;
        public MainWindow()
        {
            InitializeComponent();
            //if (id == -1)
            //{
            //    LoginPage loginPage = new LoginPage(this);
            //    loginPage.ShowDialog();
            //}
        }


        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private bool IsMax = false;
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (IsMax)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1080;
                    this.Height = 720;

                    IsMax = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                    IsMax = true;
                }
            }
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("MVVM/Views/HomePage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnStor_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("MVVM/Views/StorePages/Store.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnCustomers_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("MVVM/Views/CustomerPages/CustomerPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnAssets_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("MVVM/Views/AssestPages/AssestPage.xaml", UriKind.RelativeOrAbsolute));
        }


        private void btnBankChek_Click_1(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("MVVM/Views/BankChekPages/ChekPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnBillan_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("MVVM/Views/Billan.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnInvoice_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("MVVM/Views/InvoicesPages/AllInvoices.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnSetting_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("MVVM/Views/Settingpage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnDetebtor_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("MVVM/Views/CreditorDebtorPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("MVVM/Views/BankAccountPages/BanckAccountPage.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}