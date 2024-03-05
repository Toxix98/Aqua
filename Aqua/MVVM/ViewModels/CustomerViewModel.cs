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
    public class CustomerViewModel : INotifyPropertyChanged
    {

        private ObservableCollection<Customers> _customerItems;

        public ObservableCollection<Customers> CustomerItems
        {
            get { return _customerItems; }

            set
            {
                _customerItems = value;
                OnPropertyChanged(nameof(CustomerItems));
            }
        }

        private BaseRepo<Customers> _baseRepo;
        private CustomersRepo _customerRepo;

        public CustomerViewModel()
        {
            _baseRepo = new BaseRepo<Customers>(new Data.AquaJoyDBContext());
            _customerRepo = new CustomersRepo(new AquaJoyDBContext());
            CustomerItems = new ObservableCollection<Customers>(_baseRepo.GetItems());

        }

        public Customers GetCustomerById(int Id)
        {
            return _baseRepo.GetItem(Id);
        }

        public bool DeletCustomer(int Id)
        {
            var customer = _baseRepo.GetItem(Id);
            _baseRepo.DeletItem(customer);
            CustomerItems.Remove(customer);

            return true;

        }

        public IEnumerable<Customers> GetCustomerByeFilters(string parametrer)
        {
            return _customerRepo.GetCustomerByFilter(parametrer);
        }

        public List<Customers> GetCustomers()
        {
            return _baseRepo.GetItems();
        }

        public void SaveProduct(string txtCusName, string txtCusFamily, string txtCusPhoneNumber, string txtCusSubCode, string txtCusAddress, int ID)
        {
            if(ID == 0)
            {
                Customers customers = new Customers()
                {
                    Address = txtCusAddress,
                    Family = txtCusFamily,
                    Name = txtCusName,
                    PhoneNumber = txtCusPhoneNumber,
                    SubCode = txtCusSubCode
                };
                 _baseRepo.AddItem(customers);
                CustomerItems.Add(customers);

                Application.Current.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show("کاربر با موفقیت اضافه شد", "پیام", MessageBoxButton.OK, MessageBoxImage.Information);
                });
            }
            else
            {
                var exisitingCustomer = CustomerItems.FirstOrDefault(i => i.Id == ID);
                if (exisitingCustomer != null)
                {
                    exisitingCustomer.Name = txtCusName;
                    exisitingCustomer.Family = txtCusFamily;
                    exisitingCustomer.Address = txtCusAddress;
                    exisitingCustomer.PhoneNumber = txtCusPhoneNumber;
                    exisitingCustomer.SubCode = txtCusSubCode;

                    if (txtCusName == "" || txtCusFamily == "" || txtCusPhoneNumber == "" || txtCusSubCode == "")
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            MessageBox.Show("لطفا تمامی فیلد هارا پر نمایید", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
                        });
                    }
                    else
                    {
                        _customerRepo.UpdateCustomers(exisitingCustomer);
                        _customerRepo.Save();

                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            MessageBox.Show("کاربر با موفقیت به روزرسانی شد", "پیام", MessageBoxButton.OK, MessageBoxImage.Information);
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
