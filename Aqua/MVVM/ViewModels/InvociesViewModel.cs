﻿using Aqua.Abstarctions;
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
    public class InvociesViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<invoices> _invoices;
        private ObservableCollection<invoices> InvoicesItem
        {
            get { return _invoices; }
            set
            {
                _invoices = value;
                OnPropertyChanged(nameof(InvoicesItem));
            }
        }

        private BaseRepo<invoices> _baseRepo;
        private InvoiceRepo _invoiceRepo;

        public InvociesViewModel()
        {
            _baseRepo = new BaseRepo<invoices>(new Data.AquaJoyDBContext());
            _invoiceRepo = new InvoiceRepo(new Data.AquaJoyDBContext());
            InvoicesItem = new ObservableCollection<invoices>(_baseRepo.GetItems());
        }

        public invoices GetinvoicesById(int Id)
        {
            return _baseRepo.GetItem(Id);
        }

        public bool Deletinvoices(int Id)
        {
            var INV = _baseRepo.GetItem(Id);
            _baseRepo.DeletItem(INV);
            InvoicesItem.Remove(INV);
            return true;
        }

        public List<invoices> Getinvoices()
        {
            return _baseRepo.GetItems();
        }
        public void SaveAssests(string ExpertName, string SearchDateInvoice, string CustomerName, int TotalPrice, int ID)
        {
            if (ID == 0)
            {
                invoices invoices = new invoices()
                {
                    ExpertName = ExpertName,
                    SearchDateInvoice = SearchDateInvoice,
                    DateOfSalesInvoice = DateTime.ParseExact(SearchDateInvoice, "yyyy/M/d", CultureInfo.InvariantCulture),
                    CustomerName = CustomerName,
                    TotalPrice = Convert.ToDecimal(TotalPrice),
                };
                _baseRepo.AddItem(invoices);
                InvoicesItem.Add(invoices);
            }
            else
            {
                var exisitingINV = InvoicesItem.FirstOrDefault(i => i.Id == ID);
                if (exisitingINV != null)
                {
                    exisitingINV.ExpertName = ExpertName;
                    exisitingINV.SearchDateInvoice = SearchDateInvoice;
                    exisitingINV.DateOfSalesInvoice = DateTime.ParseExact(SearchDateInvoice, "yyyy/M/d", CultureInfo.InvariantCulture);
                    exisitingINV.CustomerName = CustomerName;
                    exisitingINV.TotalPrice = Convert.ToDecimal(TotalPrice);

                    if (ExpertName == "" || SearchDateInvoice == "" || CustomerName == "" || TotalPrice == null)
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            MessageBox.Show("لطفا تمامی فیلد هارا پر نمایید", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
                        });
                    }
                    else
                    {
                        _invoiceRepo.UpdateInvoice(exisitingINV);
                        _invoiceRepo.Save();

                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            MessageBox.Show("فاکتور با موفقیت به روزرسانی شد", "پیام", MessageBoxButton.OK, MessageBoxImage.Information);
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
