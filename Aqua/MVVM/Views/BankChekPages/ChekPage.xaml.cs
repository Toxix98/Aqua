using Aqua.MVVM.Models;
using Aqua.MVVM.ViewModels;
using Aqua.MVVM.Views;
using Aqua.MVVM.Views.BankChekPages;
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

namespace Aqua.Pages
{
    public partial class ChekPage : Page
    {
        private BankChekViewModel _viewModel;
        public int CHekID2 = 0;
        public ChekPage()
        {
            InitializeComponent();
            _viewModel = new BankChekViewModel();
            DataContext = _viewModel;
            BindGrid();
        }

        public void BindGrid()
        {
            ChekDataGrid.ItemsSource = _viewModel.GetBankChekList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            BankChekAddOrEdite BankChekAddOrEdite = new BankChekAddOrEdite();
            BankChekAddOrEdite.ShowDialog();
            BindGrid();
        }

        private void btnDelet_Click(object sender, RoutedEventArgs e)
        {
            if (ChekDataGrid.SelectedItem != null)
            {
                string ChekName = (ChekDataGrid.SelectedCells[6].Column.GetCellContent(ChekDataGrid.SelectedItem) as TextBlock)?.Text;
                BankChek Chek = ChekDataGrid.SelectedItem as BankChek;


                if (MessageBox.Show($"آیا از حذف چک به شماره {ChekName} مطمئن هستید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int CHekId = Chek.Id;
                    _viewModel.DeletBankChek(CHekId);
                    BindGrid();
                }
            }
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            BindGrid();
        }

        private void btnEdite_Click(object sender, RoutedEventArgs e)
        {
            if (ChekDataGrid.SelectedItem != null)
            {
                BankChek Chek = ChekDataGrid.SelectedItem as BankChek;
                CHekID2 = Convert.ToInt32(Chek.Id);

                BankChekAddOrEdite bankChekAddOrEdite = new BankChekAddOrEdite();
                bankChekAddOrEdite.UPDID = CHekID2;
                bankChekAddOrEdite.ShowDialog();
                BindGrid();
            }
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            ChekDataGrid.ItemsSource = _viewModel.GetBankCheksByfilers(txtSearch.Text).ToList();
        }
    }
}
