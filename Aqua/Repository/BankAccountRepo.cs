using Aqua.Abstarctions;
using Aqua.Data;
using Aqua.ListViewModel;
using Aqua.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqua.Repository
{
    public class BankAccountRepo : IBankAccountRepo
    {
        private AquaJoyDBContext db;
        public string StatuceMessage { get; set; }
        public BankAccountRepo(AquaJoyDBContext context)
        {
            db = context;
        }
        public IEnumerable<BankAccount> GetBankAccounts(string parameter)
        {
            return db.BankAccount.Where(c=> c.BankName.Contains(parameter) || c.BankBranck.Contains(parameter) || c.BankAccountNumber.Contains(parameter)).ToList();
        }

        public bool UpdateBankAccount(BankAccount bankAccount)
        {
            try
            {
                db.BankAccount.Update(bankAccount);
                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                StatuceMessage = "Error for Updating BankAccountItem : " + ex.Message;
                return false;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public List<BankAccountListViewModel> GetBankName()
        {
            return db.BankAccount.Select(b=> new BankAccountListViewModel()
            {
                Id = b.Id,
                BankName = b.BankName,
                BankBeranch = b.BankBranck,
                HseChek = b.HaseBankChek
            }).ToList();
        }
    }
}
