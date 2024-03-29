﻿using Aqua.Abstarctions;
using Aqua.Data;
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
    public class StoreViewModel : INotifyPropertyChanged
    {

        private ObservableCollection<Store> _storItems;
        public ObservableCollection<Store> StoreItems
        {
            get { return _storItems; }

            set
            {
                _storItems = value;
                OnPropertyChanged(nameof(StoreItems));
            }
        }

        private BaseRepo<Store> _storRepo;
        private StoreRepo _storeRepo;

        public StoreViewModel()
        {
            _storRepo = new BaseRepo<Store>(new AquaJoyDBContext());
            _storeRepo = new StoreRepo(new AquaJoyDBContext());
            StoreItems = new ObservableCollection<Store>(_storRepo.GetItems());
        }

        public List<Store> GetStore()
        {
            return _storRepo.GetItems();
        }

        public bool DeletItem(int ID)
        {
            var product = _storRepo.GetItem(ID);
            _storRepo.DeletItem(product);
            StoreItems.Remove(product);
            return true;
        }

        public IEnumerable<Store> GetStoreItemByfilter(string parameter)
        {
            return _storeRepo.GetStoreItemByFilter(parameter).ToList();
        }

        public Store GetStorProduct(int Id)
        {
           return _storRepo.GetItem(Id);
        }

        public bool SingleUpdate(int Count, int ID)
        {
            var PRO = _storRepo.GetItem(ID);
            PRO.CountOfProduct -= Count;
            if(PRO.CountOfProduct < 0)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show("مجودی انبار کافی نیست", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
                });
                PRO.CountOfProduct += Count;
                return false;
            }
            else
            {
                _storeRepo.UpdateStore(PRO);
                _storeRepo.Save();
                return true;
            }
        }

        public bool DeletDecresCount(int Count, int ProID)
        {
            var Pro = _storRepo.GetItem(ProID);
            Pro.CountOfProduct += Count;
            _storeRepo.UpdateStore(Pro);
            _storeRepo.Save();
            return true;
        }

        public void SaveProduct(string txtPN, int txtPC, int txtPP, string txtPD, string txtPCO, string txtPY, string txtDev , int ID)
        {
            if (ID == 0)
            {
                Store Item = new Store()
                {
                    ProductName = txtPN,
                    CountOfProduct = txtPC,
                    Price = txtPP,
                    Description = txtPD,
                    ProductCode = txtPCO,
                    Productype = txtPY,
                    ProductDevice = txtDev,
                };



                _storRepo.AddItem(Item);
                StoreItems.Add(Item);
                Application.Current.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show("کالا با موفقیت اضافه شد", "پیام", MessageBoxButton.OK, MessageBoxImage.Information);
                });
            }
            else
            {
                var existingItem = StoreItems.FirstOrDefault(i => i.Id == ID);
                if (existingItem != null)
                {
                    existingItem.ProductName = txtPN;
                    existingItem.CountOfProduct = txtPC;
                    existingItem.Price = txtPP;
                    existingItem.Description = txtPD;
                    existingItem.ProductCode = txtPCO;
                    existingItem.Productype = txtPY;
                    existingItem.ProductDevice = txtDev;

                    if (txtPC == 0 || txtPCO == "" || txtPN == "" || txtPP == 0 || txtPY == "" || txtDev == "")
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            MessageBox.Show("لطفا تمامی فیلد هارا پر نمایید", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
                        });
                    }
                    else
                    {
                        _storeRepo.UpdateStore(existingItem);
                        _storeRepo.Save();
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            MessageBox.Show("کالا با موفقیت به روزرسانی شد", "پیام", MessageBoxButton.OK, MessageBoxImage.Information);
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
