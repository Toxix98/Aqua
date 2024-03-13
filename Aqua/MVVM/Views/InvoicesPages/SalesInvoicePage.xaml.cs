using Aqua.Data;
using Aqua.MVVM.Models;
using Aqua.MVVM.ViewModels;
using Aqua.Pages.LoginPage;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;
using MessageBox = System.Windows.MessageBox;
using Stimulsoft.Report;
using Stimulsoft.Report.Components;
using Stimulsoft.Report.Dictionary;
using Stimulsoft.Report.Export;
using System.Data;
using Stimulsoft.Editor;
using Stimulsoft.Report.Wpf;

namespace Aqua.Pages
{
    public partial class SalesInvoicePage : Window
    {
        public int UPDID = 0;
        public string StatuceMessage { get; set; }
        public int Price = 0;
        private SalesInvoiceViewModels _salesINVviewModel;
        private StoreViewModel _storeViewModel;
        private CustomerViewModel _customerViewModel;
        private InvoiceDetailViewModel _invDetails;
        private InvociesViewModel _invViewModels;
        public SalesInvoicePage()
        {
            InitializeComponent();
            _salesINVviewModel = new SalesInvoiceViewModels();
            _storeViewModel = new StoreViewModel();
            _customerViewModel = new CustomerViewModel();
            _invDetails = new InvoiceDetailViewModel();
            _invViewModels = new InvociesViewModel();

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
                if (txtCustomerName.Text == "" || txtDueDate.Text == "" || txtIssuDate.Text == "" || 
                    txtPhoneNumber.Text == "" || txtSubCode.Text == "" || txtProductCount.Value == 0 ||
                    txtDeviceModel.Text == "")
                {
                    MessageBox.Show("لطفا تمامی فیلد هار کامل نمایید", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    _salesINVviewModel.SaveSalesInvoice(txtProductName.Text, txtDeviceModel.Text, Convert.ToInt32(txtProductCount.Value), Price, TR);
                    MessageBox.Show("محصول با موفقیت اضافه شد", "پیام", MessageBoxButton.OK, MessageBoxImage.Information);
                    PurchaseInvoiceBindGrid();
                    txtTotalPrice.Text += TR.ToString();
                }
            }
            catch (Exception ex)
            {
                StatuceMessage = ex.Message;
                MessageBox.Show(StatuceMessage, "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
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
            catch (Exception ex)
            {
                StatuceMessage = ex.Message;
                MessageBox.Show(StatuceMessage, "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (SalesInvDataGrid.SelectedItem != null)
            {
                SalesInvoice salesInvoice = SalesInvDataGrid.SelectedItem as SalesInvoice;

                int ProID = salesInvoice.Id;
                _salesINVviewModel.DeletSalesInvoice(ProID);
                PurchaseInvoiceBindGrid();
            }
        }

        private void membersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                string Name = "";
                string family = "";
                if (membersDataGrid.SelectedItem != null)
                {
                    Name = (membersDataGrid.SelectedCells[0].Column.GetCellContent(membersDataGrid.SelectedItem) as TextBlock).Text;
                    family = (membersDataGrid.SelectedCells[1].Column.GetCellContent(membersDataGrid.SelectedItem) as TextBlock).Text;
                }

                txtCustomerName.Text = Name + " " + family;
            }
            catch (Exception ex)
            {
                StatuceMessage = ex.Message;
                MessageBox.Show(StatuceMessage, "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (SalesInvDataGrid.Items.Count > 0)
            {
                int currentInvoiceId = _invDetails.GetINVID();
                try
                {
                    foreach (var item in SalesInvDataGrid.Items)
                    {
                        using (var contecxt = new AquaJoyDBContext())
                        {
                            dynamic data = item;
                            InvoiceDetails invoiceDetails = new InvoiceDetails
                            {
                                InvoiceId = currentInvoiceId,
                                DeviceModel = data.DeviceModel,
                                FiVahed = data.FiVahed,
                                ProductCount = data.ProductCount,
                                ProductName = data.ProductName,
                                ProductPrice = 12,
                                TPRice = data.TPRice
                            };
                            contecxt.InvoiceDetails.Add(invoiceDetails);
                            contecxt.SaveChanges();
                            _salesINVviewModel.DeletSalesInvoice(data.Id);
                        }
                    }
                    _invViewModels.SaveAssests(txtExpertNmae.Text, txtDueDate.Text, txtIssuDate.Text, txtCustomerName.Text, Convert.ToInt32(txtTotalPrice.Text) ,txtSubCode.Text,
                        txtPhoneNumber.Text, txtAdress.Text, currentInvoiceId, UPDID);
                    MessageBox.Show("فاکتور با موفقیت اضافه شد", "پیام", MessageBoxButton.OK, MessageBoxImage.Information);
                    PurchaseInvoiceBindGrid();
                    txtCustomerName.Text = "";
                    txtPhoneNumber.Text = "";
                    txtSubCode.Text = "";
                    txtProductCount.Text = "";
                    txtDeviceModel.Text = "";
                    txtAdress.Text = "";
                    txtTotalPrice.Value = 0;
                    txtProductCount.Value = 0;
                    txtExpertNmae.Text = "";
                }
                catch (Exception ex)
                {
                    StatuceMessage = ex.Message;
                    MessageBox.Show(StatuceMessage, "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("لطفا محصولی را اضافه کنید و بعد ثبت فاکتور کنید", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txtPhoneNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("EXName");
            dataTable.Rows.Add(txtExpertNmae.Text);
            StiReport report = new StiReport();
            report.Load("kir.mrt");
            report.RegData("DT", dataTable);
            report.Show();
        }
    }
}
