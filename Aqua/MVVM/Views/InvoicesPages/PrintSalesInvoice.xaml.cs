using Aqua.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MVVM.Views.InvoicesPages
{
    /// <summary>
    /// Interaction logic for PrintSalesInvoice.xaml
    /// </summary>
    public partial class PrintSalesInvoice : Window
    {
        private SalesInvoiceViewModels _viewModel;
        public string CusName = "";
        public string SubCode = "";
        public string Phone = "";
        public string Adress = "";
        public string DateIssu = "";
        public string DeviceModel = "";
        public string ExpertName = "";
        public string TotalPrice = "";
        public PrintSalesInvoice()
        {
            InitializeComponent();
            _viewModel = new SalesInvoiceViewModels();
            DataContext = _viewModel;
            BindGrid();
        }

        public void BindGrid()
        {
            SalesInvDataGrid.ItemsSource = _viewModel.GetSalesInvoice();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;

                PrintDialog printDialog = new PrintDialog();
                if(printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(print, "فاکتور");
                }
            }
            finally
            {
                this.IsEnabled = true;
            }
        }
    }
}
