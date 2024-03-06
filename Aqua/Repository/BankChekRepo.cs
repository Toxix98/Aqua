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
    public class BankChekRepo : IBankChekRepo
    {
        private AquaJoyDBContext db;
        public string SatuceMessage { get; set; }
        public BankChekRepo(AquaJoyDBContext context)
        {
            db = context;
        }

        public IEnumerable<BankChek> GetBankChekByFilter(string parameter)
        {
            return db.bankChek.Where(c => c.Bank.Contains(parameter) || c.ChekNumber.Contains(parameter) || c.Assignment.Contains(parameter)
            || c.Descriptions.Contains(parameter) || c.DueDateSTR.Contains(parameter) || c.IssueDtaeSTR.Contains(parameter));
        }

        public bool UpdateBankChek(BankChek bankChek)
        {
            try
            {
                db.bankChek.Update(bankChek);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                SatuceMessage = "Error For Updating BankChek : " + ex.Message;
                return false;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
