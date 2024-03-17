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

namespace Aqua.MVVM.Views.CreditOrDetebtproPages
{
    /// <summary>
    /// Interaction logic for AddOrEditeCB.xaml
    /// </summary>
    public partial class AddOrEditeCB : Window
    {
        public int Id = 0;
        public string type = "";
        CrediteOrDetebtorViewModel _cbViewModel;
        public string StatuceMessage { get; set; }
        public AddOrEditeCB()
        {
            InitializeComponent();
            _cbViewModel = new CrediteOrDetebtorViewModel();
        }

        public void BindGrid()
        {
            _cbViewModel.GetCreditorOrDetebtors();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_cbViewModel != null)
                {
                    if (txtname.Text != "" || txtDate.Text != "" || txtPrice.Text != "" ||
                        type != "")
                    {
                        _cbViewModel.SaveCreditorOrDetebtor(txtname.Text, Convert.ToDecimal(txtPrice.Text), type,
                            txtDate.Text, txtDescriptions.Text, Id);
                        BindGrid();
                    }
                    else
                    {
                        MessageBox.Show("لطفا فیلدهای اجباری را پرنمایید", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                StatuceMessage = "Error for Adding Or Updating : " + ex.Message;
                MessageBox.Show(StatuceMessage);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void bedehkar_Checked(object sender, RoutedEventArgs e)
        {
            type = "بدهکار";
        }

        private void bestankar_Checked(object sender, RoutedEventArgs e)
        {
            type = "بستانکار";
        }

        private void Border_Loaded(object sender, RoutedEventArgs e)
        {
            if (Id != 0)
            {
                btnSave.Content = "ویرایش";
                var cus = _cbViewModel.GetCreditorOrDetebtorById(Id);
                txtname.Text = cus.Name;
                txtDescriptions.Text = cus.Descriptions;
                txtPrice.Text = cus.Price.ToString();
                txtDate.Text = cus.SerachDate;
                type = cus.Type;
            }
        }
    }
}
