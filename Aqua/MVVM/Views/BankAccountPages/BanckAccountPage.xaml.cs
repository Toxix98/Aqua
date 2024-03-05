using Aqua.MVVM.Models;
using Aqua.MVVM.ViewModels;
using Aqua.MVVM.Views.Assest;
using Aqua.MVVM.Views.BankAccountPages;
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
    public partial class PageBanckAccount : Page
    {
        private BankAccountViewModels _bankViewModel;
        public int BankAccId = 0;
        public PageBanckAccount()
        {
            InitializeComponent();
            _bankViewModel = new BankAccountViewModels();
            DataContext = _bankViewModel;
            BindGrid();
        }

        public void BindGrid()
        {
            BankAccountDataGrid.ItemsSource = _bankViewModel.GetBankAccountList();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            BankAccAddOrUpdate bankAccAddOrUpdate = new BankAccAddOrUpdate();
            bankAccAddOrUpdate.ShowDialog();
            BindGrid();
        }

        private void btnEdite_Click(object sender, RoutedEventArgs e)
        {
            if (BankAccountDataGrid.SelectedItem != null)
            {
                BankAccount bankAccount = BankAccountDataGrid.SelectedItem as BankAccount;
                BankAccId = Convert.ToInt32(bankAccount.Id);

                BankAccAddOrUpdate bankAccAddOrUpdate = new BankAccAddOrUpdate();
                bankAccAddOrUpdate.BankIDADD = BankAccId;
                bankAccAddOrUpdate.ShowDialog();
            }
            BankAccountDataGrid.Items.Refresh();
            BindGrid();
        }

        private void btnDelet_Click(object sender, RoutedEventArgs e)
        {
            if (BankAccountDataGrid.SelectedItem != null)
            {
                var BankName = (BankAccountDataGrid.SelectedCells[4].Column.GetCellContent(BankAccountDataGrid.SelectedItem) as TextBlock)?.Text;
                BankAccount bankAccount = BankAccountDataGrid.SelectedItem as BankAccount;

                if (MessageBox.Show($"آیا از حذف {BankName} مطمعن هستید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int BankId = bankAccount.Id;
                    _bankViewModel.DeletBankAccount(BankId);
                    BindGrid();
                }
            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            BindGrid();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            BankAccountDataGrid.ItemsSource = _bankViewModel.GetBanckAccountByFilters(txtSearch.Text);
        }
    }
}
