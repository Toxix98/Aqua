using Aqua.Abstarctions;
using Aqua.Data;
using Aqua.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqua.Repository
{
    public class InvoiceRepo : IInvoiceRepo
    {
        public string StatuceMessage { get; set; }

        private AquaJoyDBContext db;
        public InvoiceRepo(AquaJoyDBContext context)
        {
            db = context;
        }
        public IEnumerable<invoices> GetInvoicesByfilter(string parameter)
        {
            return db.Invoices.Where(i=> i.SearchDateInvoice.Contains(parameter) || i.CustomerName.Contains(parameter) || i.ExpertName.Contains(parameter));
        }

        public bool UpdateInvoice(invoices invoices)
        {
            try
            {
                db.Invoices.Update(invoices);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                StatuceMessage = "Error for Updating Inovices : " + ex.Message;
                return false;
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
