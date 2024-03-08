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
    public class InvoiceDetailsRepo : IInvoiceDetailsRepo
    {
        public string StatuceMessage { get; set; }
        private AquaJoyDBContext db;
        public InvoiceDetailsRepo(AquaJoyDBContext context)
        {
            db = context;
        }
        public bool UpdateInvoiceDetails(InvoiceDetails invoiceDetails)
        {
            try
            {
                db.InvoiceDetails.Update(invoiceDetails);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                StatuceMessage = "Error for Updating InvoiceDetails : " + ex.Message;
                return false;
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
