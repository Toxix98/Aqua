﻿using System;
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

        public int InvoiceID { get; set; }

        [MaxLength (150)]
        public string CustomerName { get; set; }

        [MaxLength (100)]
        public string CustomerSubCode { get; set; }

        [MaxLength(20)]
        public string CustomerPhoneNumber { get; set; }

        [MaxLength(150)]
        public string ExpertName { get; set; }

        [MaxLength(800)]
        public string? Address { get; set; }

        [MaxLength(150)]
        public string SearchDateOfWork { get; set; }

        public DateTime DateOfWork { get; set; }

        [MaxLength(150)]
        public string SearchNextVisitDate { get; set; }

        public DateTime NextVisitDate { get; set; }
    }
}
