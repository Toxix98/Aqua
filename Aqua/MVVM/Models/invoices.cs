using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqua.MVVM.Models
{
    public class invoices
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public string CustomerName { get; set; }
        public string ExpertName { get; set; }
        public DateTime DateOfSalesInvoice { get; set; }
    }
}
