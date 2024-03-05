using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqua.MVVM.Models
{
    public class PurchaseInvoice
    {
        public int Id { get; set; }

        [MaxLength (150)]
        public string ProuductName { get; set; }

        public Decimal ProductPrice { get; set; }

        [MaxLength(150)]
        public string ProductCode { get; set; }

        public decimal TotalPrice { get; set; }

        [MaxLength(150)]
        public string SearchDatePurchaseInvoice { get; set; }

        public DateTime DateOfPurchase { get; set; }

        public int ProductPurchaseCount { get; set; }

        [MaxLength(800)]
        public string Descriptions { get; set; }
    }
}
