﻿using Aqua.Data;
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
using System.Xml.Serialization;

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
        private static BaseRepo<InvoiceDetails> _baseRepo2;

        public InvoiceDetailViewModel()
        {
            _baseRepo = new BaseRepo<InvoiceDetails>(new Data.AquaJoyDBContext());
            _invoiceDetailsRepo = new InvoiceDetailsRepo(new Data.AquaJoyDBContext());
            InvoiceDetailsItem = new ObservableCollection<InvoiceDetails>(_baseRepo.GetItems());
            _baseRepo2 = new BaseRepo<InvoiceDetails>(new Data.AquaJoyDBContext());
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

        public int GetINVID()
        {
            using (var db = new AquaJoyDBContext())
            {
                var INV = db.InvoiceDetails.OrderByDescending(i => i.InvoiceId).FirstOrDefault();
                if (INV != null)
                {
                    return INV.InvoiceId + 1;
                }
                else
                {
                    return 1;
                }
            }
        }

        public static List<InvoiceDetails> SearchByInvoiceId(int invoiceId)
        {
            List<InvoiceDetails> allDetails = _baseRepo2.GetItems();
            List<InvoiceDetails> searchResults = new List<InvoiceDetails>();

            foreach (var item in allDetails)
            {
                if (item.InvoiceId == invoiceId)
                {
                    searchResults.Add(item);
                }
            }

            return searchResults;
        }

        public static void DeletByInvoiceId(int invoiceId)
        {
            List<InvoiceDetails> Details = SearchByInvoiceId(invoiceId);

            foreach(var deatils in Details)
            {
                _baseRepo2.DeletItem(deatils);
            }
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
                var exisitingINV = InvoiceDetailsItem.FirstOrDefault(i => i.INVId == ID);
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
