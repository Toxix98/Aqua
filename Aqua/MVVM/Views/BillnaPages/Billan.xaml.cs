using Aqua.Data;
using Aqua.MVVM.Models;
using Aqua.MVVM.ViewModels;
using Aqua.MVVM.Views.BillnaPages;
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

namespace Aqua.Pages
{
    public partial class Billan : Page
    {
        private BillanViewModel viewModel;
        private NegBillanViewModel _NegBillanViewModel;
        public string StatuceMessage { get; set; }
        public Billan()
        {
            InitializeComponent();
            viewModel = new BillanViewModel();
            _NegBillanViewModel = new NegBillanViewModel();
            DataContext = viewModel;
            DataContext = _NegBillanViewModel;
            BindGridPlus();
            NegBindGrid();
        }

        public void BindGridPlus()
        {
            BillanPlus.ItemsSource = viewModel.GetBillanPlusList();
        }

        public void NegBindGrid()
        {
            BillanNeg.ItemsSource = _NegBillanViewModel.BillanNegetiveList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            viewModel.Save(txtFromDate.Text, txtToDate.Text);
            _NegBillanViewModel.Save(txtFromDate.Text, txtToDate.Text);
            BindGridPlus();
            NegBindGrid();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (var db = new AquaJoyDBContext())
            {
                try
                {
                    List<BillanPlus> AllP = db.BillanPlus.ToList();
                    decimal PriceP = 0;
                    foreach (var item in AllP)
                    {
                        PriceP += item.Price;
                    }

                    List<BillanNegetive> AllN = db.BillanNegetive.ToList();
                    decimal PriceN = 0;
                    foreach (var item in AllN)
                    {
                        PriceN += item.Price;
                    }

                    decimal FinliayPrice = PriceP - PriceN;

                    PrintBillanResult printBillanResult = new PrintBillanResult();
                    printBillanResult.txtSood.Text = PriceP.ToString();
                    printBillanResult.txtZarar.Text = PriceN.ToString();
                    printBillanResult.txtTotalPrice.Text = FinliayPrice.ToString();
                    printBillanResult.ShowDialog();
                }
                catch (Exception ex)
                {
                    StatuceMessage = ex.Message;
                    MessageBox.Show(StatuceMessage, "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            using(var db = new AquaJoyDBContext())
            {
                db.BillanPlus.RemoveRange(db.BillanPlus);
                db.SaveChanges();

                db.BillanNegetive.RemoveRange(db.BillanNegetive);
                db.SaveChanges();
                BindGridPlus();
                NegBindGrid();
            }
        }
    }
}
