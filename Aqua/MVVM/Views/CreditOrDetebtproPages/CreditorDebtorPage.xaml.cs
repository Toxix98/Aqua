using Aqua.MVVM.Models;
using Aqua.MVVM.ViewModels;
using Aqua.MVVM.Views;
using Aqua.MVVM.Views.CreditOrDetebtproPages;
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
    public partial class PageCreditorDebtor : Page
    {
        CrediteOrDetebtorViewModel _cbViewModel;
        public int IDUPDate = 0;
        public PageCreditorDebtor()
        {
            InitializeComponent();
            _cbViewModel = new CrediteOrDetebtorViewModel();
            DataContext = _cbViewModel;
            BindGrid();
        }

        public void BindGrid()
        {
            membersDataGrid.ItemsSource = _cbViewModel.GetCreditorOrDetebtors();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddOrEditeCB addOrEditeCB = new AddOrEditeCB();
            addOrEditeCB.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            BindGrid();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (membersDataGrid.SelectedItem != null)
            {
                string name = (membersDataGrid.SelectedCells[4].Column.GetCellContent(membersDataGrid.SelectedItem) as TextBlock)?.Text;
                CreditorOrDetebtor customers = membersDataGrid.SelectedItem as CreditorOrDetebtor;

                if (MessageBox.Show($"آیا از حذف {name} مطمعن هستید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int CusId = customers.id;
                    _cbViewModel.DeletCreditorOrDetebtor(CusId);
                    BindGrid();
                }
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (membersDataGrid.SelectedItem != null)
            {
                Aqua.MVVM.Models.CreditorOrDetebtor store = membersDataGrid.SelectedItem as Aqua.MVVM.Models.CreditorOrDetebtor;
                IDUPDate = Convert.ToInt32(store.id);

                AddOrEditeCB AddOrEditeCB = new AddOrEditeCB();
                AddOrEditeCB.Id = IDUPDate;
                AddOrEditeCB.ShowDialog();
                BindGrid();
            }
        }
    }
}
