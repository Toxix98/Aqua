using Aqua.Data;
using Aqua.MVVM.Models;
using Aqua.MVVM.ViewModels;
using Aqua.Pages;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Aqua.MVVM.Views.InvoicesPages
{
    public partial class AllInvoices : Page
    {
        private InvociesViewModel _allINVviewModel;
        private InvoiceDetailViewModel _invoiceDetailViewModel;
        public int IDdeatils = 0;
        public AllInvoices()
        {
            InitializeComponent();
            _allINVviewModel = new InvociesViewModel();
            _invoiceDetailViewModel = new InvoiceDetailViewModel();
            DataContext = _allINVviewModel;
            BindGrid();
        }

        public void BindGrid()
        {
            AllINVDataGrid.ItemsSource = _allINVviewModel.Getinvoices();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            SalesInvoicePage salesInvoicePage = new SalesInvoicePage();
            salesInvoicePage.ShowDialog();
            BindGrid();
        }

        private void btnEdite_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AllINVDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (AllINVDataGrid.SelectedItem != null)
                {
                    Aqua.MVVM.Models.invoices Inv = AllINVDataGrid.SelectedItem as Aqua.MVVM.Models.invoices;
                    int id = Inv.InvoiceID;
                    
                    List<InvoiceDetails> details = InvoiceDetailViewModel.SearchByInvoiceId(id);
                    DetailsINVdataGrid.ItemsSource = details;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnDelet_Click(object sender, RoutedEventArgs e)
        {
            if (AllINVDataGrid.SelectedItem != null)
            {
                var AssestName = (AllINVDataGrid.SelectedCells[6].Column.GetCellContent(AllINVDataGrid.SelectedItem) as TextBlock)?.Text;
                invoices assests = AllINVDataGrid.SelectedItem as invoices;

                if (MessageBox.Show($"آیا از حذف {AssestName} مطمعن هستید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int AssId = assests.Id;
                    int ID = assests.InvoiceID;

                    _invoiceDetailViewModel.DeletInvoiceDetails(ID);
                    _allINVviewModel.Deletinvoices(AssId);
                    BindGrid();
                }
            }
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        { 
            AllINVDataGrid.ItemsSource =  _allINVviewModel.GetINVByFilter(txtSearch.Text).ToList();
        }
    }
}
