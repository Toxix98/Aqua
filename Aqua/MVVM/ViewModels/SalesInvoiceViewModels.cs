using Aqua.Abstarctions;
using Aqua.MVVM.Models;
using Aqua.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Aqua.MVVM.ViewModels
{
    public class SalesInvoiceViewModels : INotifyPropertyChanged
    {
        private ObservableCollection<PurchaseInvoice> _purchaseInvoice;
        private ObservableCollection<PurchaseInvoice> PurchaseInvoiceItem
        {
            get { return _purchaseInvoice; }
            set
            {
                _purchaseInvoice = value;
                OnPropertyChanged(nameof(PurchaseInvoiceItem));
            }
        }

        private BaseRepo<PurchaseInvoice> _baseRepo;
        private PurchaseInvoiceRepo _purchaseRepo;

        public SalesInvoiceViewModels()
        {
            _baseRepo = new BaseRepo<PurchaseInvoice>(new Data.AquaJoyDBContext());
            _purchaseRepo = new PurchaseInvoiceRepo(new Data.AquaJoyDBContext());
            PurchaseInvoiceItem = new ObservableCollection<PurchaseInvoice>(_baseRepo.GetItems());
        }

        public PurchaseInvoice GetAssesPurchaseInvoiceById(int Id)
        {
            return _baseRepo.GetItem(Id);
        }

        public bool DeletPurchaseInvoice(int Id)
        {
            var INV = _baseRepo.GetItem(Id);
            _baseRepo.DeletItem(INV);
            PurchaseInvoiceItem.Remove(INV);
            return true;
        }

        public List<PurchaseInvoice> GetPurchaseInvoice()
        {
            return _baseRepo.GetItems();
        }

        public void SaveAssests(string ProuductName, string ProductCode, int ProductPurchaseCount, int FiVahed, int TPRice,string Customer, int ID)
        {
            if (ID == 0)
            {
                PurchaseInvoice PurchaseInvoice = new PurchaseInvoice()
                {
                    ProuductName = ProuductName,
                    ProductCode = ProductCode,
                    Customer = Customer,
                    FiVahed = FiVahed,
                    ProductPurchaseCount = ProductPurchaseCount,
                    TPRice = TPRice
                };
                _baseRepo.AddItem(PurchaseInvoice);
                PurchaseInvoiceItem.Add(PurchaseInvoice);
            }
            else
            {
                var exisitingINV = PurchaseInvoiceItem.FirstOrDefault(i => i.Id == ID);
                if (exisitingINV != null)
                {
                    exisitingINV.ProuductName = ProuductName;
                    exisitingINV.ProductCode = ProductCode;
                    exisitingINV.Customer = Customer;
                    exisitingINV.FiVahed = FiVahed;
                    exisitingINV.ProductPurchaseCount = ProductPurchaseCount;
                    exisitingINV.TPRice = TPRice;

                    if (ProuductName == "" || ProductCode == null || ProductPurchaseCount == null || FiVahed == null || TPRice == null || Customer == "")
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            MessageBox.Show("لطفا تمامی فیلد هارا پر نمایید", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
                        });
                    }
                    else
                    {
                        _purchaseRepo.UpdatePurchaseInvoice(exisitingINV);
                        _purchaseRepo.Save();

                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            MessageBox.Show("فاکتور فروش با موفقیت به روزرسانی شد", "پیام", MessageBoxButton.OK, MessageBoxImage.Information);
                        });
                    }
                }
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
