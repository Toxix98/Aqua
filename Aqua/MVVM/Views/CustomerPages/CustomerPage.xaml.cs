using Aqua.MVVM.Models;
using Aqua.MVVM.ViewModels;
using Aqua.MVVM.Views;
using Aqua.Pages.LoginPage;
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

namespace Aqua
{
    /// <summary>
    /// Interaction logic for CustomerPage.xaml
    /// </summary>
    public partial class CustomerPage : Page
    {
        public int IDUPDate = 0;
        private CustomerViewModel _customerViewModel;
        public CustomerPage()
        {
            InitializeComponent();
            _customerViewModel = new CustomerViewModel();
            DataContext = _customerViewModel;
            FillDataGrid();
        }

        void FillDataGrid()
        {
            CustomerDataGrid.ItemsSource = _customerViewModel.CustomerItems;
        }

        void BindGrid()
        {
            CustomerDataGrid.AutoGenerateColumns = false;
            CustomerDataGrid.ItemsSource = _customerViewModel.GetCustomers();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            AddOrUpdateCustomerPage addOrUpdateCustomerPage = new AddOrUpdateCustomerPage();
            addOrUpdateCustomerPage.ShowDialog();
            BindGrid();
        }

        private void btnDelet_Click(object sender, RoutedEventArgs e)
        {
            if(CustomerDataGrid.SelectedItem != null)
            {
                string name = (CustomerDataGrid.SelectedCells[4].Column.GetCellContent(CustomerDataGrid.SelectedItem) as TextBlock)?.Text;
                Customers customers = CustomerDataGrid.SelectedItem as Customers;

                if (MessageBox.Show($"آیا از حذف {name} مطمعن هستید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int CusId = customers.Id;
                    _customerViewModel.DeletCustomer(CusId);
                }
            }
        }

        private void btnEdite_Click(object sender, RoutedEventArgs e)
        {
            if (CustomerDataGrid.SelectedItem != null)
            {
                Aqua.MVVM.Models.Customers store = CustomerDataGrid.SelectedItem as Aqua.MVVM.Models.Customers;
                IDUPDate = Convert.ToInt32(store.Id);

                AddOrUpdateCustomerPage addOrUpdateCustomerPage = new AddOrUpdateCustomerPage();
                addOrUpdateCustomerPage.Id = IDUPDate;
                addOrUpdateCustomerPage.ShowDialog();
                BindGrid();
            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            BindGrid();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            CustomerDataGrid.ItemsSource = _customerViewModel.GetCustomerByeFilters(txtSearch.Text).ToList();
        }
    }
}
