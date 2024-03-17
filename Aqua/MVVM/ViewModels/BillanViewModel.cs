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
    public class BillanViewModel : INotifyPropertyChanged
    {

        private ObservableCollection<BillanPlus> _billanPlus;
        public ObservableCollection<BillanPlus> BillanPlus
        {
            get { return _billanPlus; }
            set
            {
                _billanPlus = value;
                OnPropertyChanged(nameof(BillanPlus));
            }
        }

        private BaseRepo<BillanPlus> _baseRepo;

        public BillanViewModel()
        {
            _baseRepo = new BaseRepo<BillanPlus>(new Data.AquaJoyDBContext());
            BillanPlus = new ObservableCollection<BillanPlus>(_baseRepo.GetItems());
        }

        public BillanPlus GetBillanPlusById(int id)
        {
            return _baseRepo.GetItem(id);
        }

        public bool DeletBillanPlusChek(int Id)
        {
            var chek = _baseRepo.GetItem(Id);
            _baseRepo.DeletItem(chek);
            BillanPlus.Remove(chek);
            return true;
        }

        public List<BillanPlus> GetBillanPlusList()
        {
            return _baseRepo.GetItems();
        }

        public void Save(string txtFromDate, string txtToDate)
        {
            DateTime StartDate = DateTime.Parse(txtFromDate);
            DateTime EndeDate = DateTime.Parse(txtToDate);

            using (var db = new AquaJoyDBContext())
            {
                List<Assests> assests = db.Assest
                    .Where(d => d.AssestDateOfBuye.Date >= StartDate.Date && d.AssestDateOfBuye.Date <= EndeDate.Date)
                    .ToList();

                foreach (var asset in assests)
                {
                    BillanPlus newBillanPlusItem = new BillanPlus
                    {
                        PlusName = asset.AssestName,
                        Price = Convert.ToInt32(asset.AssestPrice),
                        Date = asset.SearchDate
                    };

                    db.BillanPlus.Add(newBillanPlusItem);
                }

                List<invoices> Inv = db.Invoices
                    .Where(d => d.DateOfWork.Date >= StartDate.Date && d.DateOfWork.Date <= EndeDate.Date)
                    .ToList();

                foreach (var inv in Inv)
                {
                    BillanPlus newBillanPlusItem = new BillanPlus
                    {
                        PlusName = inv.CustomerName,
                        Price = Convert.ToDecimal(inv.TotalPrice),
                        Date = inv.SearchDateOfWork
                    };

                    db.BillanPlus.Add(newBillanPlusItem);
                }


                List<BankChek> chek = db.bankChek
    .Where(d => d.DueDate.Date >= StartDate.Date && d.DueDate.Date <= EndeDate.Date && d.Type == "0")
    .ToList();

                foreach (var Chek in chek)
                {
                    BillanPlus newBillanPlusItem = new BillanPlus
                    {
                        PlusName = Chek.ChekNumber,
                        Price = Convert.ToDecimal(Chek.ChekPrice),
                        Date = Chek.DueDateSTR
                    };

                    db.BillanPlus.Add(newBillanPlusItem);
                }

                List<CreditorOrDetebtor> cb = db.CreditorOrDetebtor
.Where(d => d.Date.Date >= StartDate.Date && d.Date.Date <= EndeDate.Date && d.Type == "بدهکار")
.ToList();

                foreach (var CB in cb)
                {
                    BillanPlus newBillanPlusItem = new BillanPlus
                    {
                        PlusName = CB.Name,
                        Price = Convert.ToDecimal(CB.Price),
                        Date = CB.SerachDate
                    };

                    db.BillanPlus.Add(newBillanPlusItem);
                }


                db.SaveChanges();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
