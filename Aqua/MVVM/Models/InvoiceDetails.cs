﻿using Microsoft.EntityFrameworkCore;
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
        [Key]
        public int INVId { get; set; }

        public int InvoiceId { get; set; }

        [MaxLength(150)]
        public string ProductName { get; set; }

        public int ProductCount { get; set; }

        [MaxLength(200)]
        public string DeviceModel { get; set; }

        public decimal ProductPrice { get; set; }

        public int FiVahed { get; set; }

        public int TPRice { get; set; }
    }
}
