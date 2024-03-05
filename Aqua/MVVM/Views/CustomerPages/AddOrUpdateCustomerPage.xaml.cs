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

namespace Aqua.MVVM.Views
{
    /// <summary>
    /// Interaction logic for AddOrUpdateCustomerPage.xaml
    /// </summary>
    public partial class AddOrUpdateCustomerPage : Window
    {
        public int Id = 0;
        private CustomerViewModel _customerViewModel;
        private string StatuseMessage { get; set; }
        public AddOrUpdateCustomerPage()
        {
            InitializeComponent();
            _customerViewModel = new CustomerViewModel();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_customerViewModel != null)
                {
                    if (txtCustomePhoneNumber.Text != "" || txtCustomerFamily.Text != "" || txtCustomerName.Text != "" ||
                        txtCustomerSubCode.Text != "")
                    {
                        _customerViewModel.SaveProduct(txtCustomerName.Text, txtCustomerFamily.Text, txtCustomePhoneNumber.Text,
                            txtCustomerSubCode.Text, txtCustomerAddress.Text, Id);
                    }
                    else
                    {
                        MessageBox.Show("لطفا فیلدهای اجباری را پرنمایید", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch(Exception ex) 
            {
                StatuseMessage = "Error for Adding Or Updating : " + ex.Message;
                MessageBox.Show(StatuseMessage);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if(Id != 0)
            {
                btnSave.Content = "ویرایش شخص";
                var cus = _customerViewModel.GetCustomerById(Id);
                txtCustomerSubCode.Text = cus.SubCode;
                txtCustomerAddress.Text = cus.Address;
                txtCustomePhoneNumber.Text = cus.PhoneNumber;
                txtCustomerFamily.Text = cus.Family;
                txtCustomerName.Text = cus.Name;
            }
        }
    }
}
