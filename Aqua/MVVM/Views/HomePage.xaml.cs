using Aqua.MVVM.ViewModels;
using LiveCharts;
using LiveCharts.Wpf;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Aqua.Pages.LoginPage
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        private BankChekViewModel bankChekViewModel;
        private CrediteOrDetebtorViewModel crediteOrDetebtorViewModel;
        public HomePage()
        {
            InitializeComponent();
            bankChekViewModel = new BankChekViewModel();
            crediteOrDetebtorViewModel = new CrediteOrDetebtorViewModel();
            DataContext = bankChekViewModel;
            DataContext = crediteOrDetebtorViewModel;
            ChekBindGrid();
            CBBindGrid();
        }

        public void ChekBindGrid()
        {
            dtgShowChek.ItemsSource = bankChekViewModel.GetBankChekList();
        }

        public void CBBindGrid()
        {
            dtgDetebtorHome.ItemsSource = crediteOrDetebtorViewModel.GetCreditorOrDetebtors();
        }
    }
}
