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

namespace Aqua.Pages
{
    public partial class SalesInvoicePage : Window
    {
        public string StatuceMessage { get; set; }
        public int Price = 0;
        private SalesInvoiceViewModels _salesINVviewModel;
        private StoreViewModel _storeViewModel;
        private CustomerViewModel _customerViewModel;
        public SalesInvoicePage()
        {
            InitializeComponent();
            _salesINVviewModel = new SalesInvoiceViewModels();
            _storeViewModel = new StoreViewModel();
            _customerViewModel = new CustomerViewModel();

            DataContext = _salesINVviewModel;
            DataContext = _storeViewModel;
            DataContext = _customerViewModel;

            PurchaseInvoiceBindGrid();
            StorBindGrid();
            CustomerBindGrid();
        }

        public void CustomerBindGrid()
        {
            membersDataGrid.ItemsSource = _customerViewModel.GetCustomers();
        }

        public void StorBindGrid()
        {
            StoreDataGrid.ItemsSource = _storeViewModel.GetStore();
        }

        public void PurchaseInvoiceBindGrid()
        {
            SalesInvDataGrid.ItemsSource = _salesINVviewModel.GetSalesInvoice();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                int TR = Price * Convert.ToInt32(txtProductCount.Text);
                if (txtCustomerName.Text == "" || txtCustomerName.Text == "" || txtDueDate.Text == "" ||
                    txtIssuDate.Text == "" || txtPhoneNumber.Text == "" || txtSubCode.Text == "" || txtProductCount.Text == "" ||
                    txtDeviceModel.Text == "")
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        MessageBox.Show("لطفا تمامی فیلد هار کامل نمایید", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
                    });
                }
                else
                {
                    _salesINVviewModel.SaveSalesInvoice(txtProductName.Text, txtDeviceModel.Text, Convert.ToInt32(txtProductCount.Text), Price, TR);
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        MessageBox.Show("محصول با موفقیت اضافه شد", "پیام", MessageBoxButton.OK, MessageBoxImage.Information);
                    });
                    PurchaseInvoiceBindGrid();
                }
            }
            catch(Exception ex)
            {
                StatuceMessage = ex.Message;
                Application.Current.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show(StatuceMessage, "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
                });
            }
        }

        private void StoreDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string Name = "";
                string Modle = "";
                if (StoreDataGrid.SelectedItem != null)
                {
                    Price = Convert.ToInt32((StoreDataGrid.SelectedCells[0].Column.GetCellContent(StoreDataGrid.SelectedItem) as TextBlock).Text);
                    Modle = (StoreDataGrid.SelectedCells[3].Column.GetCellContent(StoreDataGrid.SelectedItem) as TextBlock).Text;
                    Name = (StoreDataGrid.SelectedCells[4].Column.GetCellContent(StoreDataGrid.SelectedItem) as TextBlock).Text;
                }

                txtProductName.Text = Name;
                txtDeviceModel.Text = Modle;
            }
            catch(Exception ex )
            {
                StatuceMessage = ex.Message;
                Application.Current.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show(StatuceMessage, "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
                });
            }
        }
    }
}
