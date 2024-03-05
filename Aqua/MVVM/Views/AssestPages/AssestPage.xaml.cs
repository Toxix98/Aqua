using Aqua.MVVM.Models;
using Aqua.MVVM.ViewModels;
using Aqua.MVVM.Views.Assest;
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
    /// <summary>
    /// Interaction logic for AssestPage.xaml
    /// </summary>
    public partial class AssestPage : Page
    {
        private AssestViewModels _assestViewModel;
        public int AssestId2;
        public AssestPage()
        {
            InitializeComponent();
            _assestViewModel = new AssestViewModels();
            DataContext = _assestViewModel;
            BindGrid();
        }

        public void BindGrid()
        {
            AssestDataGrid.ItemsSource = _assestViewModel.GetAssest();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AssestAddOrEdite assestAddOrEdite = new AssestAddOrEdite();
            assestAddOrEdite.ShowDialog();
            BindGrid();
        }

        private void btnEdite_Click(object sender, RoutedEventArgs e)
        {
            if(AssestDataGrid.SelectedItem != null)
            {
                Assests assests = AssestDataGrid.SelectedItem as Assests;
                AssestId2 = Convert.ToInt32(assests.Id);

                AssestAddOrEdite assestAddOrEdite = new AssestAddOrEdite();
                assestAddOrEdite.AssestProId = AssestId2;
                assestAddOrEdite.ShowDialog();
            }
            AssestDataGrid.Items.Refresh();
            BindGrid();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            BindGrid();
        }

        private void btnDelet_Click(object sender, RoutedEventArgs e)
        {
            if(AssestDataGrid.SelectedItem != null)
            {
                var AssestName = (AssestDataGrid.SelectedCells[3].Column.GetCellContent(AssestDataGrid.SelectedItem) as TextBlock)?.Text;
                Assests assests = AssestDataGrid.SelectedItem as Assests;

                if (MessageBox.Show($"آیا از حذف {AssestName} مطمعن هستید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int AssId = assests.Id;
                    _assestViewModel.DeletAssest(AssId);
                    BindGrid();
                }
            }
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
           AssestDataGrid.ItemsSource = _assestViewModel.GetAssestsByFilters(txtSearch.Text);
        }
    }
}
