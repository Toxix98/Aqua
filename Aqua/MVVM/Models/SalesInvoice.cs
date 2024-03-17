using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqua.MVVM.Models
{
    public class SalesInvoice
    {
        public int Id { get; set; }

        [MaxLength(150)]
        public string ProductName { get; set; }

        public int ProID { get; set; }

        public int ProductCount { get; set; }

        [MaxLength(200)]
        public string DeviceModel { get; set; }

        public int FiVahed { get; set; }

        public int TPRice { get; set; }
    }
}
