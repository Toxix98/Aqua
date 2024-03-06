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

namespace Aqua.MVVM.Views.BankChekPages
{
    public partial class BankChekAddOrEdite : Window
    {
        private BankAccountViewModels _bankAccVM;
        private BankChekViewModel _bankChekViewModel;
        public BankChekAddOrEdite()
        {
            InitializeComponent();
            _bankAccVM = new BankAccountViewModels();
            DataContext = _bankAccVM;
            _bankChekViewModel = new BankChekViewModel();
            DataGridList();
        }

        public void DataGridList()
        {
            BankAccDataGrid.AutoGenerateColumns = false;
            BankAccDataGrid.ItemsSource = _bankAccVM.GetBankNameList();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {

        }

        private void txtIssuDate_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void txtDueDate_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void txtChekNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void txtChekPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }
    }
}
