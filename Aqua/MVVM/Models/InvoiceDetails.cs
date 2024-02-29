using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqua.MVVM.Models
{
    public class InvoiceDetails
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public int ProductCount { get; set; }
        public decimal ProductPrice { get; set; }
    }
}
