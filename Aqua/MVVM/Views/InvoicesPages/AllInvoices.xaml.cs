using Aqua.MVVM.ViewModels;
using Aqua.Pages;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Aqua.MVVM.Views.InvoicesPages
{
    /// <summary>
    /// Interaction logic for AllInvoices.xaml
    /// </summary>
    public partial class AllInvoices : Page
    {
        private InvociesViewModel _allINVviewModel;
        public AllInvoices()
        {
            InitializeComponent();
            _allINVviewModel = new InvociesViewModel();
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
        }
    }
}
