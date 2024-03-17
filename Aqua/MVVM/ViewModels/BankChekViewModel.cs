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
using System.Globalization;

namespace Aqua.MVVM.ViewModels
{
    public class BankChekViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<BankChek> _bankCheks;
        public ObservableCollection<BankChek> BankChekItem
        {
            get { return _bankCheks; }
            set
            {
                _bankCheks = value;
                OnPropertyChanged(nameof(BankChek));
            }
        }

        private BaseRepo<BankChek> _baseRepo;
        private BaseRepo<BankAccount> _bankAcc;
        private BankChekRepo _bankChekRepo;

        public BankChekViewModel()
        {
            _baseRepo = new BaseRepo<BankChek>(new Data.AquaJoyDBContext());
            _bankChekRepo = new BankChekRepo(new Data.AquaJoyDBContext());
            BankChekItem = new ObservableCollection<BankChek>(_baseRepo.GetItems());
        }

        public BankChek GetBankChekById(int id)
        {
            return _baseRepo.GetItem(id);
        }

        public bool DeletBankChek(int Id)
        {
            var chek = _baseRepo.GetItem(Id);
            _baseRepo.DeletItem(chek);
            BankChekItem.Remove(chek);
            return true;
        }

        public IEnumerable<BankChek> GetBankCheksByfilers(string parametrer)
        {
            return _bankChekRepo.GetBankChekByFilter(parametrer);
        }

        public List<BankChek> GetBankChekList()
        {
            return _baseRepo.GetItems();
        }

        public void SaveBankAccount(string txtChekNum, string txtChekBank, decimal txtChekPrice, string txtAsignmen, string txtIssuDate, string txtDueDate, string txtDescriptions, int ID, string type)
        {
            if (ID == 0)
            {
                BankChek bankChek = new BankChek()
                {
                    ChekNumber = txtChekNum,
                    Bank = txtChekBank,
                    ChekPrice = Convert.ToDecimal(txtChekPrice),
                    Assignment = txtAsignmen,
                    IssueDate = DateTime.ParseExact(txtIssuDate, "yyyy/M/d", CultureInfo.InvariantCulture),
                    IssueDtaeSTR = txtIssuDate,
                    DueDate = DateTime.ParseExact(txtDueDate, "yyyy/M/d", CultureInfo.InvariantCulture),
                    DueDateSTR = txtDueDate,
                    Descriptions = txtDescriptions,
                    Type = type,
                };
                _baseRepo.AddItem(bankChek);
                BankChekItem.Add(bankChek);

                Application.Current.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show("چک با موفقیت ثبت شد با موفقیت اضافه شد", "پیام", MessageBoxButton.OK, MessageBoxImage.Information);
                });
            }
            else
            {
                var exisitingChek = BankChekItem.FirstOrDefault(i => i.Id == ID);
                if (exisitingChek != null)
                {
                    exisitingChek.ChekNumber = txtChekNum;
                    exisitingChek.Bank = txtChekBank;
                    exisitingChek.ChekPrice = Convert.ToDecimal(txtChekPrice);
                    exisitingChek.Assignment = txtAsignmen;
                    exisitingChek.IssueDtaeSTR = txtIssuDate;
                    exisitingChek.DueDateSTR = txtDueDate;
                    exisitingChek.Descriptions = txtDescriptions;
                    exisitingChek.DueDate = DateTime.ParseExact(txtDueDate, "yyyy/M/d", CultureInfo.InvariantCulture);
                    exisitingChek.IssueDate = DateTime.ParseExact(txtIssuDate, "yyyy/M/d", CultureInfo.InvariantCulture);

                    if (txtChekNum == "" || txtChekBank == "" || txtChekPrice == null || txtAsignmen == "" || txtIssuDate == ""
                        || txtDueDate == "" || txtDescriptions == "")
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            MessageBox.Show("لطفا تمامی فیلد هارا پر نمایید", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
                        });
                    }
                    else
                    {
                        _bankChekRepo.UpdateBankChek(exisitingChek);
                        _bankChekRepo.Save();

                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            MessageBox.Show("چک با موفقیت به روزرسانی شد", "پیام", MessageBoxButton.OK, MessageBoxImage.Information);
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
