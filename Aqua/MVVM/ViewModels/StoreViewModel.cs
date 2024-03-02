using Aqua.Abstarctions;
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

        public IEnumerable<Store> GetStoreItemByfilter(string parameter)
        {
            return _storeRepo.GetStoreItemByFilter(parameter);
        }

        public Store GetStorProduct(int Id)
        {
           return _storRepo.GetItem(Id);
        }

        public void BindGrid()
        {
            _storRepo.GetItems();
        }

        public void SaveProduct(string txtPN, string txtPC, string txtPP, string txtPD, string txtPCO, string txtPY, int ID)
        {
            if (ID == 0)
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
                    existingItem.CountOfProduct = int.Parse(txtPC);
                    existingItem.Price = int.Parse(txtPP);
                    existingItem.Description = txtPD;
                    existingItem.ProductCode = txtPCO;
                    existingItem.Productype = txtPY;

                    _storeRepo.UpdateStore(existingItem);
                    _storeRepo.Save();
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        MessageBox.Show("کالا با موفقیت به روزرسانی شد", "پیام", MessageBoxButton.OK, MessageBoxImage.Information);
                    });
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
