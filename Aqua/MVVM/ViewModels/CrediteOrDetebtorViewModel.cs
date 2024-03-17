using Aqua.Data;
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
    public class CrediteOrDetebtorViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<CreditorOrDetebtor> _creditorOrDetebtor;

        public ObservableCollection<CreditorOrDetebtor> CreditorOrDetebtor
        {
            get { return _creditorOrDetebtor; }

            set
            {
                _creditorOrDetebtor = value;
                OnPropertyChanged(nameof(CreditorOrDetebtor));
            }
        }

        private BaseRepo<CreditorOrDetebtor> _baseRepo;
        private CrediteOrDetebtor _cbRepo;

        public CrediteOrDetebtorViewModel()
        {
            _baseRepo = new BaseRepo<CreditorOrDetebtor>(new Data.AquaJoyDBContext());
            _cbRepo = new CrediteOrDetebtor(new Data.AquaJoyDBContext());
            CreditorOrDetebtor = new ObservableCollection<CreditorOrDetebtor>(_baseRepo.GetItems());
        }

        public CreditorOrDetebtor GetCreditorOrDetebtorById(int Id)
        {
            return _baseRepo.GetItem(Id);
        }

        public bool DeletCreditorOrDetebtor(int Id)
        {
            var customer = _baseRepo.GetItem(Id);
            _baseRepo.DeletItem(customer);
            CreditorOrDetebtor.Remove(customer);

            return true;

        }

        public List<CreditorOrDetebtor> GetCreditorOrDetebtors()
        {
            return _baseRepo.GetItems();
        }

        public void SaveCreditorOrDetebtor(string name, decimal price, string type, string Date, string Decsctiptions, int ID)
        {
            if (ID == 0)
            {
                CreditorOrDetebtor CB = new CreditorOrDetebtor()
                {
                    Name = name,
                    Price = price,
                    Type = type,
                    Date = DateTime.ParseExact(Date, "yyyy/M/d", CultureInfo.InvariantCulture),
                    SerachDate = Date,
                    Descriptions = Decsctiptions
                };
                _baseRepo.AddItem(CB);
                CreditorOrDetebtor.Add(CB);

                Application.Current.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show("با موفقیت اضافه شد", "پیام", MessageBoxButton.OK, MessageBoxImage.Information);
                });
            }
            else
            {
                var exisitingCreditorOrDetebtor = CreditorOrDetebtor.FirstOrDefault(i => i.id == ID);
                if (exisitingCreditorOrDetebtor != null)
                {
                    exisitingCreditorOrDetebtor.Name = name;
                    exisitingCreditorOrDetebtor.Price = Convert.ToInt32(price);
                    exisitingCreditorOrDetebtor.SerachDate = Date;
                    exisitingCreditorOrDetebtor.Descriptions = Decsctiptions;
                    exisitingCreditorOrDetebtor.Date = DateTime.ParseExact(Date, "yyyy/M/d", CultureInfo.InvariantCulture);

                    if (name == "" || price == 0 || type == "" || Date == "")
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            MessageBox.Show("لطفا تمامی فیلد هارا پر نمایید", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
                        });
                    }
                    else
                    {
                        _cbRepo.UpdatedDB(exisitingCreditorOrDetebtor);
                        _cbRepo.Save();

                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            MessageBox.Show("با موفقیت به روزرسانی شد", "پیام", MessageBoxButton.OK, MessageBoxImage.Information);
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
