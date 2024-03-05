using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqua.MVVM.Models
{
    public class InvoiceDetails
    {
        public int Id { get; set; }

        public int InvoiceId { get; set; }

        [MaxLength(150)]
        public string ProductName { get; set; }

        [MaxLength(150)]
        public string ProductCode { get; set; }

        public int ProductCount { get; set; }

        public decimal ProductPrice { get; set; }
    }
}
