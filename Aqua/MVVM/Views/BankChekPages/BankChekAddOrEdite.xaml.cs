using Aqua.ListViewModel;
using Aqua.MVVM.Models;
using Aqua.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Globalization;

namespace Aqua.MVVM.Views.BankChekPages
{
    public partial class BankChekAddOrEdite : Window
    {
        public int UPDID = 0;
        private BankAccountViewModels _bankAccVM;
        private BankChekViewModel _bankChekViewModel;
        public string Type = "";
        public string StatuceMessage { get; set; }
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
            try
            {
                if (txtAssignment.Text == "" || txtChekBank.Text == "" || txtChekNumber.Text == "" || txtChekPrice.Value == null || txtDueDate == null
                    || txtIssuDate == null)
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        MessageBox.Show("لطفا تمامی فیلد هارا پر نمایید", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
                    });
                }
                else
                {
                    _bankChekViewModel.SaveBankAccount(txtChekNumber.Text, txtChekBank.Text, Convert.ToDecimal(txtChekPrice.Value), txtAssignment.Text, txtIssuDate.Text
                        , txtDueDate.Text, txtDescriptions.Text, UPDID, Type);

                }
            }
            catch (Exception ex)
            {
                StatuceMessage = "Error for Adding Or updating BankChek" + ex.Message;
                Application.Current.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show(StatuceMessage, "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
                });
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void txtIssuDate_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void txtDueDate_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void txtChekNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void txtChekPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
            TextBox textBox = sender as TextBox;
        }

        private void BankAccDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string name = "";
            if (BankAccDataGrid.SelectedItem != null)
            {
                name = (BankAccDataGrid.SelectedCells[1].Column.GetCellContent(BankAccDataGrid.SelectedItem) as TextBlock).Text;
            }
            txtChekBank.Text = name;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if(UPDID != 0)
            {
                btnSave.Content = "ویرایش چک";
                var ChekItem = _bankChekViewModel.GetBankChekById(UPDID);
                txtAssignment.Text = ChekItem.Assignment;
                txtChekBank.Text = ChekItem.Bank;
                txtChekNumber.Text = ChekItem.ChekNumber;
                txtChekPrice.Value = Convert.ToInt32(ChekItem.ChekPrice);
                txtDescriptions.Text = ChekItem.Descriptions;
                txtDueDate.Text = ChekItem.DueDateSTR;
                txtIssuDate.Text = ChekItem.IssueDtaeSTR;
            }
        }

        private void ckb0_Checked(object sender, RoutedEventArgs e)
        {
            Type = "0";
        }

        private void ckb1_Checked(object sender, RoutedEventArgs e)
        {
            Type = "1";
        }
    }
}
