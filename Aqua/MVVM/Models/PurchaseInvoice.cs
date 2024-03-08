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

        [MaxLength(150)]
        public string ProductCode { get; set; }

        public int ProductPurchaseCount { get; set; }

        public int FiVahed { get; set; }

        public int TPRice { get; set; }

        public string Customer { get; set; }
    }
}
