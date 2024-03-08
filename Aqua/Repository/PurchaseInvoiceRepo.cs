using Aqua.Abstarctions;
using Aqua.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqua.Repository
{
    public class PurchaseInvoiceRepo : IPurchaseInvoice
    {
        public string StatuceMessage { get; set; }
        private AquaJoyDBContext db;
        public PurchaseInvoiceRepo(AquaJoyDBContext context)
        {
            db = context;
        }

        public bool UpdatePurchaseInvoice(MVVM.Models.PurchaseInvoice purchaseInvoice)
        {
            try
            {
                db.Update(purchaseInvoice);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                StatuceMessage = "Error for Updating PurchaseInvoice : " + ex.Message;
                return false;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
