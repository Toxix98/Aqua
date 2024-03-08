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

namespace Aqua.MVVM.Views.BankAccountPages
{
    /// <summary>
    /// Interaction logic for BankAccAddOrUpdate.xaml
    /// </summary>
    public partial class BankAccAddOrUpdate : Window
    {
        private BankAccountViewModels _bankVM;
        public int BankIDADD = 0;
        public string SatuceMeesgae { get; set; }
        public BankAccAddOrUpdate()
        {
            InitializeComponent();
            _bankVM = new BankAccountViewModels();
        }

        private void txtCustomePhoneNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtBanAccNum.Text == "" || txtBankBranchName.Text == ""
                    || txtBankname.Text == "")
                {
                    MessageBox.Show("لطفا فیلدهای اجباری را پرنمایید", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    _bankVM.SaveBankAccount(txtBankname.Text, txtBankBranchName.Text, txtBanAccNum.Text , BankIDADD);
                }
            }
            catch(Exception ex) 
            {
                SatuceMeesgae = "Error for Adding Or Updating : " + ex.Message;
                MessageBox.Show(SatuceMeesgae);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if(BankIDADD != 0)
            {
                btnSave.Content = "ویرایش حساب بانکی";
                var BankAcc = _bankVM.GetBankAccountById(BankIDADD);
                txtBanAccNum.Text = BankAcc.BankAccountNumber;
                txtBankBranchName.Text = BankAcc.BankBranck;
                txtBankname.Text = BankAcc.BankName;
            }
        }

        private void txtBankBalance_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
