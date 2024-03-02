using Aqua.Data;
using Aqua.MVVM.Models;
using Aqua.MVVM.ViewModels;
using Aqua.MVVM.Views;
using Aqua.Repository;
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

namespace Aqua.Pages.LoginPage
{
    public partial class Store : Page
    {
        private StoreViewModel _viewModel;
        private StoreAddOrUpdate storeAddOrUpdate;
        public int IDUPDate = 0;
        public Store()
        {
            InitializeComponent();

            _viewModel = new StoreViewModel();
            DataContext = _viewModel;
            storeAddOrUpdate = new StoreAddOrUpdate();

            FillDataGrid();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StoreAddOrUpdate StoreAddOrUpdate = new StoreAddOrUpdate();
            StoreAddOrUpdate.ShowDialog();
            BindGrid();

        }

        public void FillDataGrid()
        {
            StoreDataGrid.ItemsSource = _viewModel.StoreItems;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (StoreDataGrid.SelectedItem != null)
            {
                string productName = (StoreDataGrid.SelectedCells[5].Column.GetCellContent(StoreDataGrid.SelectedItem) as TextBlock)?.Text;
                Aqua.MVVM.Models.Store store = StoreDataGrid.SelectedItem as Aqua.MVVM.Models.Store;


                if (MessageBox.Show($"آیا از حذف {productName} مطمعن هستید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int ProductId = store.Id;
                    _viewModel.DeletItem(ProductId);
                }
            }

        }

        private void StoreDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        void BindGrid()
        {
            StoreDataGrid.AutoGenerateColumns = false;
            StoreDataGrid.ItemsSource = _viewModel.GetStore();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (StoreDataGrid.SelectedItem != null)
            {
                Aqua.MVVM.Models.Store store = StoreDataGrid.SelectedItem as Aqua.MVVM.Models.Store;
                IDUPDate = Convert.ToInt32(store.Id);

                storeAddOrUpdate = new StoreAddOrUpdate();
                storeAddOrUpdate.ProductStoreID = IDUPDate;
                storeAddOrUpdate.ShowDialog();
                BindGrid();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //Store store = sender as Store;
            //if (store != null)
            //{
            //    store.Initialize(new StoreAddOrUpdate(), ProductStoreID);
            //}
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            BindGrid();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            StoreDataGrid.ItemsSource = _viewModel.GetStoreItemByfilter(txtSearch.Text);
        }
    }
}
