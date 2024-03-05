using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqua.MVVM.Models
{
    public class invoices
    {
        public int Id { get; set; }

        public decimal TotalPrice { get; set; }

        [MaxLength (150)]
        public string CustomerName { get; set; }

        [MaxLength(150)]
        public string ExpertName { get; set; }

        [MaxLength(150)]
        public string SearchDateInvoice { get; set; }

        public DateTime DateOfSalesInvoice { get; set; }
    }
}
