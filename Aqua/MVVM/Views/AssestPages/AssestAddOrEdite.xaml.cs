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

namespace Aqua.MVVM.Views.Assest
{
    public partial class AssestAddOrEdite : Window
    {
        public int AssestProId = 0;
        private AssestViewModels _assestviewModel;
        private string StatuseMessage { get; set; }

        public AssestAddOrEdite()
        {
            InitializeComponent();
            _assestviewModel = new AssestViewModels();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtAssesName.Text == "" || txtAssestPrice.Value == null || txtDateOfByeAssest.Text == null)
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        MessageBox.Show("لطفا تمامی فیلد هارا پر نمایید", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
                    });
                }
                else
                {
                    _assestviewModel.SaveAssests(txtAssesName.Text, txtAssestType.Text, txtAssestPrice.Value, 
                        txtDateOfByeAssest.Text, AssestProId);
                }
            }
            catch (Exception ex)
            {
                StatuseMessage = "Error for Adding Assest Item : " + ex.Message;

                MessageBox.Show(StatuseMessage);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if(AssestProId != 0)
            {
                btnSave.Content = "ویرایش دارایی";
                var AssestItem = _assestviewModel.GetAssestById(AssestProId);
                txtAssesName.Text = AssestItem.AssestName;
                txtAssestPrice.Text = AssestItem.AssestPrice.ToString();
                txtAssestType.Text = AssestItem.AssestType;
                txtDateOfByeAssest.Text = AssestItem.SearchDate; 
            }
        }

        private void txtAssestPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if(!char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
