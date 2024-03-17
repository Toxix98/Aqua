using Aqua.Data;
using Aqua.MVVM.Models;
using Aqua.Repository;
using Microsoft.EntityFrameworkCore;
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
    public class LoginViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Login> _login;

        public ObservableCollection<Login> Login
        {
            get { return _login; }

            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }

        private BaseRepo<Login> _baseRepo;

        public LoginViewModel()
        {
            _baseRepo = new BaseRepo<Login>(new Data.AquaJoyDBContext());
            Login = new ObservableCollection<Login>(_baseRepo.GetItems());

        }

        public Login GetLoginId(int Id)
        {
            return _baseRepo.GetItem(Id);
        }

        public bool DeletLogin(int Id)
        {
            var customer = _baseRepo.GetItem(Id);
            _baseRepo.DeletItem(customer);
            Login.Remove(customer);

            return true;

        }

        public List<Login> GetLogins()
        {
            return _baseRepo.GetItems();
        }

        public void SaveLogin(string txtCusName, string txtCusFamily)
        {
            Login login = new Login()
            {
                UserName = txtCusName,
                Password = txtCusFamily
            };
            _baseRepo.AddItem(login);
            Login.Add(login);

            Application.Current.Dispatcher.Invoke(() =>
            {
                MessageBox.Show("کاربر با موفقیت اضافه شد", "پیام", MessageBoxButton.OK, MessageBoxImage.Information);
            });
        }

        public bool ValidateLogin(string username, string password)
        {
            using (var db = new AquaJoyDBContext())
            {
                var user = db.Login.FirstOrDefault(u => u.UserName == username);

                if (user != null)
                {
                    if (user.Password == password)
                    {
                        return true;
                    }
                }
                return false;
        }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
