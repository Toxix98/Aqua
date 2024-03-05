using Aqua.Abstarctions;
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
            BankAccount bankAccount = new BankAccount();
            if (bankAccount.BankChekId == 0)
            {
                _baseRepo.DeletItem(BankAcc);
                BankAccountItem.Remove(BankAcc);
                return true;
            }
            else
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show("این حساب بانکی با یک دسته چک در ارتباط است و شما نمیتوانید تا زمانی که دسته چک را پاک نکرده‌اید این حساب بانکی را پاک کنید", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
                });
                return false;
            }

        }

        public IEnumerable<BankAccount> GetBanckAccountByFilters(string parameter)
        {
            return _bankAccountRepo.GetBankAccounts(parameter);
        }

        public List<BankAccount> GetBankAccountList()
        {
            return _baseRepo.GetItems();
        }

        public void SaveBankAccount(string txtBankName, string txtBankBranch, string txtBankBalance, string txtBankAcCNumber, int CheckId, int ID)
        {
            if (ID == 0)
            {
                string hasechek = "";
                if(CheckId == 0)
                {
                    hasechek = "ندارد";
                }
                else if(CheckId == 1) 
                {
                    hasechek = "دارد";
                }
                BankAccount bankAccount = new BankAccount()
                {
                    BankName = txtBankName,
                    BankAccountNumber = txtBankAcCNumber,
                    BankBalance = Convert.ToDecimal(txtBankBalance),
                    BankBranck = txtBankBranch,
                    BankChekId = 0,
                    HaseBankChek = hasechek
                };
                _baseRepo.AddItem(bankAccount);
                BankAccountItem.Add(bankAccount);

                Application.Current.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show("دارایی با موفقیت اضافه شد", "پیام", MessageBoxButton.OK, MessageBoxImage.Information);
                });
            }
            else
            {
                var exisitingBankAcc = BankAccountItem.FirstOrDefault(i => i.Id == ID);
                if (exisitingBankAcc != null)
                {
                    exisitingBankAcc.BankName = txtBankName;
                    exisitingBankAcc.BankBalance = Convert.ToDecimal(txtBankBalance);
                    exisitingBankAcc.BankBranck = txtBankBranch;
                    exisitingBankAcc.BankAccountNumber = txtBankAcCNumber;

                    if (txtBankName == "" || txtBankBalance == "" || txtBankBranch == "" || txtBankAcCNumber == "")
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
