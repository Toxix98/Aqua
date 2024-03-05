using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqua.MVVM.Models
{
    public class Customers
    {
        public int Id { get; set; }

        [MaxLength(150)]
        public string Name { get; set; }

        [MaxLength(150)]
        public string Family { get; set; }

        [MaxLength(150)]
        public string PhoneNumber { get; set; }

        [MaxLength(800)]
        public string? Address { get; set; }

        [MaxLength(40)]
        public string SubCode { get; set; }
    }
}
