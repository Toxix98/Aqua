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



        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
