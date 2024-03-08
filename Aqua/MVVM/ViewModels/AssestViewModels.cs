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
    public class AssestViewModels : INotifyPropertyChanged
    {
        private ObservableCollection<Assests> _assestItem;
        public ObservableCollection<Assests> AssestItems
        {
            get { return _assestItem; }

            set
            {
                _assestItem = value;
                OnPropertyChanged(nameof(AssestItems));
            }
        }

        private BaseRepo<Assests> _baseRepo;
        private AssestRepo _assestRepo;

        public AssestViewModels()
        {
            _baseRepo = new BaseRepo<Assests>(new Data.AquaJoyDBContext());
            _assestRepo = new AssestRepo(new Data.AquaJoyDBContext());
            AssestItems = new ObservableCollection<Assests>(_baseRepo.GetItems());
        }

        public Assests GetAssestById(int Id)
        {
            return _baseRepo.GetItem(Id);
        }

        public bool DeletAssest(int Id)
        {
            var Assest = _baseRepo.GetItem(Id);
            _baseRepo.DeletItem(Assest);
            AssestItems.Remove(Assest);
            return true;
        }

        public IEnumerable<Assests> GetAssestsByFilters(string parameter)
        {
            return _assestRepo.GetAssestsByFilter(parameter);
        }

        public List<Assests> GetAssest()
        {
            return _baseRepo.GetItems();
        }

        public void SaveAssests(string txtAssName, string txtAssType, int ?txtAssPrice, string txtDateOfBye, int ID)
        {
            if (ID == 0)
            {
                Assests assests = new Assests()
                {
                    AssestName = txtAssName,
                    AssestType = txtAssType,
                    AssestPrice = Convert.ToDecimal(txtAssPrice),
                    SearchDate = txtDateOfBye,
                    AssestDateOfBuye = DateTime.ParseExact(txtDateOfBye, "yyyy/M/d", CultureInfo.InvariantCulture),
            };
                _baseRepo.AddItem(assests);
                AssestItems.Add(assests);

                Application.Current.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show("دارایی با موفقیت اضافه شد", "پیام", MessageBoxButton.OK, MessageBoxImage.Information);
                });
            }
            else
            {
                var exisitingAsses = AssestItems.FirstOrDefault(i => i.Id == ID);
                if (exisitingAsses != null)
                {
                    exisitingAsses.AssestName = txtAssName;
                    exisitingAsses.AssestType = txtAssType;
                    exisitingAsses.AssestPrice = Convert.ToDecimal(txtAssPrice);
                    exisitingAsses.SearchDate = txtDateOfBye;
                    exisitingAsses.AssestDateOfBuye = DateTime.ParseExact(txtDateOfBye, "yyyy/M/d", CultureInfo.InvariantCulture);

                    if (txtAssName == "" || txtAssPrice == null || txtDateOfBye == "")
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            MessageBox.Show("لطفا تمامی فیلد هارا پر نمایید", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
                        });
                    }
                    else
                    {
                        _assestRepo.UpdateAssest(exisitingAsses);
                        _assestRepo.Save();

                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            MessageBox.Show("دارایی با موفقیت به روزرسانی شد", "پیام", MessageBoxButton.OK, MessageBoxImage.Information);
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
