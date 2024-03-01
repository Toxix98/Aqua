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

        public StoreViewModel()
        {
            _storRepo = new BaseRepo<Store>(new AquaJoyDBContext());
            StoreItems = new ObservableCollection<Store>(_storRepo.GetItems());
        }

        public void AddItem(Store newItem)
        {
            _storRepo.AddItem(newItem);
            StoreItems.Add(newItem);
        }

        public bool DeletItem(int ID)
        {
            var product = _storRepo.GetItem(ID);
            _storRepo.DeletItem(product);
            StoreItems.Remove(product);
            return true;
        }

        public Store GetStorProduct(int Id)
        {
           return _storRepo.GetItem(Id);
        }

        public void SaveProduct(string txtPN, string txtPC, string txtPP,
            string txtPD, string txtPCO, string txtPY, int ID)
        {

            Store Item = new Store()
            {
                ProductName = txtPN,
                CountOfProduct = int.Parse(txtPC),
                Price = int.Parse(txtPP),
                Description = txtPD,
                ProductCode = txtPCO,
                Productype = txtPY,
            };

            if(ID == 0 )
            {
                _storRepo.AddItem(Item);
                StoreItems.Add(Item);
                Application.Current.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show("کالا با موفقیت اضافه شد", "پیام", MessageBoxButton.OK, MessageBoxImage.Information);
                });
            }
            else
            {
                Item.Id = ID;
                _storRepo.UpdateItem(Item);
                StoreItems.Add(Item);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}