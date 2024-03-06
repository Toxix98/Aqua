using Aqua.MVVM.ViewModels;
using Aqua.MVVM.Views.BankChekPages;
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

namespace Aqua.Pages
{
    /// <summary>
    /// Interaction logic for ChekPage.xaml
    /// </summary>
    public partial class ChekPage : Page
    {
        private BankChekViewModel _viewModel;
        public ChekPage()
        {
            InitializeComponent();
            _viewModel = new BankChekViewModel();
            DataContext = _viewModel;
            BindGrid();
        }

        public void BindGrid()
        {
            ChekDataGrid.ItemsSource = _viewModel.GetBankChekList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            BankChekAddOrEdite BankChekAddOrEdite = new BankChekAddOrEdite();
            BankChekAddOrEdite.ShowDialog();
            BindGrid();
        }
    }
}
