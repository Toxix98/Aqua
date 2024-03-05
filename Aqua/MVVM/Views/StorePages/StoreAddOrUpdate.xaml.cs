﻿using Aqua.MVVM.ViewModels;
using Aqua.Pages.LoginPage;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Aqua.MVVM.Views
{
    /// <summary>
    /// Interaction logic for StoreAddOrUpdate.xaml
    /// </summary>
    public partial class StoreAddOrUpdate : Window
    {
        public int ProductStoreID = 0;
        private StoreViewModel _viewModel;
        public string StatuceMessage { get; set; }
        public StoreAddOrUpdate()
        {
            InitializeComponent();
            _viewModel = new StoreViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_viewModel != null)
                {
                    if (txtProductCode.Text != "" || txtProductCount.Text != "" || txtProductName.Text != "" || txtProductPrice.Text != ""
                        || txtProductType.Text != "")
                    {
                        _viewModel.SaveProduct(txtProductName.Text, txtProductCount.Text, txtProductPrice.Text,
                            txtProductDescriptions.Text, txtProductCode.Text, txtProductType.Text, ProductStoreID);
                    }
                    else
                    {
                        MessageBox.Show("لطفا فیلدهای اجباری را پرنمایید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                StatuceMessage = "Error for Adding or Updating : " + ex.Message;
                MessageBox.Show(StatuceMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (ProductStoreID != 0)
            {
                btnSave.Content = "ویرایش";
                var ProductDet = _viewModel.GetStorProduct(ProductStoreID);
                txtProductCode.Text = ProductDet.ProductCode;
                txtProductCount.Text = ProductDet.CountOfProduct.ToString();
                txtProductDescriptions.Text = ProductDet.Description;
                txtProductName.Text = ProductDet.ProductName;
                txtProductPrice.Text = ProductDet.Price.ToString();
                txtProductType.Text = ProductDet.Productype;
            }
        }
    }
}
