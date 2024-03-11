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
        private ObservableCollection<SalesInvoice> _salesInvoice;
        private ObservableCollection<SalesInvoice> SalesInvoiceItem
        {
            get { return _salesInvoice; }
            set
            {
                _salesInvoice = value;
                OnPropertyChanged(nameof(SalesInvoiceItem));
            }
        }

        private BaseRepo<SalesInvoice> _baseRepo;
        private PurchaseInvoiceRepo _salesInvoiceRepo;

        public SalesInvoiceViewModels()
        {
            _baseRepo = new BaseRepo<SalesInvoice>(new Data.AquaJoyDBContext());
            _salesInvoiceRepo = new PurchaseInvoiceRepo(new Data.AquaJoyDBContext());
            SalesInvoiceItem = new ObservableCollection<SalesInvoice>(_baseRepo.GetItems());
        }

        public SalesInvoice GetAssesSalesInvoiceById(int Id)
        {
            return _baseRepo.GetItem(Id);
        }

        public bool DeletSalesInvoice(int Id)
        {
            var INV = _baseRepo.GetItem(Id);
            _baseRepo.DeletItem(INV);
            SalesInvoiceItem.Remove(INV);
            return true;
        }

        public List<SalesInvoice> GetSalesInvoice()
        {
            return _baseRepo.GetItems();
        }

        public void SaveSalesInvoice(string ProductName, string DeviceModel, int ProductCount, int FiVahed, int TPRice)
        {
            SalesInvoice salesInvoice = new SalesInvoice()
            {
                ProductName = ProductName,
                DeviceModel = DeviceModel,
                TPRice = TPRice,
                FiVahed = FiVahed,
                ProductCount = ProductCount,

            };
            _baseRepo.AddItem(salesInvoice);
            SalesInvoiceItem.Add(salesInvoice);
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
