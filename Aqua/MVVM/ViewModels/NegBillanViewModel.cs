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
    public class NegBillanViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<BillanNegetive> _billanNegetive;
        public ObservableCollection<BillanNegetive> BillanNegetiveItem
        {
            get { return _billanNegetive; }
            set
            {
                _billanNegetive = value;
                OnPropertyChanged(nameof(BillanNegetive));
            }
        }

        private BaseRepo<BillanNegetive> _baseRepo;

        public NegBillanViewModel()
        {
            _baseRepo = new BaseRepo<BillanNegetive>(new Data.AquaJoyDBContext());
            BillanNegetiveItem = new ObservableCollection<BillanNegetive>(_baseRepo.GetItems());
        }

        public BillanNegetive BillanNegetiveById(int id)
        {
            return _baseRepo.GetItem(id);
        }

        public bool DeletBillanNegetive(int Id)
        {
            var chek = _baseRepo.GetItem(Id);
            _baseRepo.DeletItem(chek);
            BillanNegetiveItem.Remove(chek);
            return true;
        }

        public List<BillanNegetive> BillanNegetiveList()
        {
            return _baseRepo.GetItems();
        }

        public void Save(string txtFromDate, string txtToDate)
        {
            DateTime StartDate = DateTime.Parse(txtFromDate);
            DateTime EndeDate = DateTime.Parse(txtToDate);

            using (var db = new AquaJoyDBContext())
            {
                List<BankChek> chek = db.bankChek
    .Where(d => d.DueDate.Date >= StartDate.Date && d.DueDate.Date <= EndeDate.Date && d.Type == "1")
    .ToList();

                foreach (var Chek in chek)
                {
                    BillanNegetive newBillanPlusItem = new BillanNegetive
                    {
                        Name = Chek.ChekNumber,
                        Price = Convert.ToDecimal(Chek.ChekPrice),
                        Date = Chek.DueDateSTR
                    };

                    db.BillanNegetive.Add(newBillanPlusItem);
                }

                List<CreditorOrDetebtor> cb = db.CreditorOrDetebtor
.Where(d => d.Date.Date >= StartDate.Date && d.Date.Date <= EndeDate.Date && d.Type == "بستانکار")
.ToList();

                foreach (var CB in cb)
                {
                    BillanNegetive newBillanPlusItem = new BillanNegetive
                    {
                        Name = CB.Name,
                        Price = Convert.ToDecimal(CB.Price),
                        Date = CB.SerachDate
                    };

                    db.BillanNegetive.Add(newBillanPlusItem);
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
