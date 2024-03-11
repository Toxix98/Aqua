using Aqua.MVVM.Models;
using Aqua.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Aqua.MVVM.ViewModels
{
    public class InvoiceDetailViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<InvoiceDetails> _invoices;
        private ObservableCollection<InvoiceDetails> InvoiceDetailsItem
        {
            get { return _invoices; }
            set
            {
                _invoices = value;
                OnPropertyChanged(nameof(InvoiceDetailsItem));
            }
        }

        private BaseRepo<InvoiceDetails> _baseRepo;
        private InvoiceDetailsRepo _invoiceDetailsRepo;

        public InvoiceDetailViewModel()
        {
            _baseRepo = new BaseRepo<InvoiceDetails>(new Data.AquaJoyDBContext());
            _invoiceDetailsRepo = new InvoiceDetailsRepo(new Data.AquaJoyDBContext());
            InvoiceDetailsItem = new ObservableCollection<InvoiceDetails>(_baseRepo.GetItems());
        }

        public InvoiceDetails GetInvoiceDetailsById(int Id)
        {
            return _baseRepo.GetItem(Id);
        }

        public bool DeletInvoiceDetails(int Id)
        {
            var INV = _baseRepo.GetItem(Id);
            _baseRepo.DeletItem(INV);
            InvoiceDetailsItem.Remove(INV);
            return true;
        }

        public List<InvoiceDetails> GetInvoiceDetails()
        {
            return _baseRepo.GetItems();
        }

        public void SaveAssests(string ProductName, string ProductCode, int ProductCount, int ProductPrice, int InvoiceId, string DeviceModel, int ID, int FiVahed,
            int TPRice)
        {
            if (ID == 0)
            {
                InvoiceDetails InvoiceDetails = new InvoiceDetails()
                {
                    ProductName = ProductName,
                    InvoiceId = InvoiceId,
                    ProductCount = ProductCount,
                    DeviceModel = DeviceModel,
                    FiVahed = FiVahed,
                    TPRice = TPRice,
                    ProductPrice = Convert.ToDecimal(ProductPrice),
                };
                _baseRepo.AddItem(InvoiceDetails);
                InvoiceDetailsItem.Add(InvoiceDetails);
            }
            else
            {
                var exisitingINV = InvoiceDetailsItem.FirstOrDefault(i => i.Id == ID);
                if (exisitingINV != null)
                {
                    exisitingINV.ProductName = ProductName;
                    exisitingINV.ProductCount = ProductCount;
                    exisitingINV.DeviceModel = DeviceModel;
                    exisitingINV.FiVahed = FiVahed;
                    exisitingINV.TPRice = TPRice;
                    exisitingINV.ProductPrice = Convert.ToDecimal(ProductPrice);

                    if (ProductName == "" || ProductCode == "" || ProductCount == null || ProductPrice == null || DeviceModel == ""
                        || FiVahed == null || TPRice == null)
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            MessageBox.Show("لطفا تمامی فیلد هارا پر نمایید", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
                        });
                    }
                    else
                    {
                        _invoiceDetailsRepo.UpdateInvoiceDetails(exisitingINV);
                        _invoiceDetailsRepo.Save();

                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            MessageBox.Show("ریز فاکتور با موفقیت به روزرسانی شد", "پیام", MessageBoxButton.OK, MessageBoxImage.Information);
                        });
                    }
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
