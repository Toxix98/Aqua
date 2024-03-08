using Aqua.Abstarctions;
using Aqua.ListViewModel;
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
    public class BankAccountViewModels : INotifyPropertyChanged
    {
        private ObservableCollection<BankAccount> _bankAccount;
        public ObservableCollection<BankAccount> BankAccountItem
        {
            get { return _bankAccount; }

            set
            {
                _bankAccount = value;
                OnPropertyChanged(nameof(BankAccount));
            }
        }

        private BaseRepo<BankAccount> _baseRepo;
        private BankAccountRepo _bankAccountRepo;

        public BankAccountViewModels()
        {
            _baseRepo = new BaseRepo<BankAccount>(new Data.AquaJoyDBContext());
            _bankAccountRepo = new BankAccountRepo(new Data.AquaJoyDBContext());
            BankAccountItem = new ObservableCollection<BankAccount>(_baseRepo.GetItems());
        }

        public BankAccount GetBankAccountById(int Id)
        {
            return _baseRepo.GetItem(Id);
        }

        public bool DeletBankAccount(int Id)
        {
            var BankAcc = _baseRepo.GetItem(Id);
            _baseRepo.DeletItem(BankAcc);
            BankAccountItem.Remove(BankAcc);
            return true;

        }

        public List<BankAccountListViewModel> GetBankNameList()
        {
            return _bankAccountRepo.GetBankName();
        }

        public IEnumerable<BankAccount> GetBanckAccountByFilters(string parameter)
        {
            return _bankAccountRepo.GetBankAccounts(parameter);
        }

        public List<BankAccount> GetBankAccountList()
        {
            return _baseRepo.GetItems();
        }

        public void SaveBankAccount(string txtBankName, string txtBankBranch, string txtBankAcCNumber, int ID)
        {
            if (ID == 0)
            {
                BankAccount bankAccount = new BankAccount()
                {
                    BankName = txtBankName,
                    BankAccountNumber = txtBankAcCNumber,
                    BankBranck = txtBankBranch,
                };
                _baseRepo.AddItem(bankAccount);
                BankAccountItem.Add(bankAccount);

                Application.Current.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show("حساب بانکی با موفقیت اضافه شد", "پیام", MessageBoxButton.OK, MessageBoxImage.Information);
                });
            }
            else
            {
                var exisitingBankAcc = BankAccountItem.FirstOrDefault(i => i.Id == ID);
                if (exisitingBankAcc != null)
                {
                    exisitingBankAcc.BankName = txtBankName;
                    exisitingBankAcc.BankBranck = txtBankBranch;
                    exisitingBankAcc.BankAccountNumber = txtBankAcCNumber;

                    if (txtBankName == "" || txtBankBranch == "" || txtBankAcCNumber == "")
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            MessageBox.Show("لطفا تمامی فیلد هارا پر نمایید", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
                        });
                    }
                    else
                    {
                        _bankAccountRepo.UpdateBankAccount(exisitingBankAcc);
                        _bankAccountRepo.Save();

                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            MessageBox.Show("حساب بانکی با موفقیت به روزرسانی شد", "پیام", MessageBoxButton.OK, MessageBoxImage.Information);
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
