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

        [MaxLength (150)]
        public string CustomerName { get; set; }

        [MaxLength(50)]
        public string CustomerSubCode { get; set; }

        [MaxLength(20)]
        public string CustomerPhoneNumber { get; set; }

        [MaxLength(800)]
        public string? Address { get; set; }

        public DateTime DateOfWork { get; set; }

        public DateTime NextVisitDate { get; set; }

        [MaxLength(200)]
        public string DeviceModel { get; set; }

        [MaxLength(150)]
        public string THeExpert { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
