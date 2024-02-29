﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aqua.MVVM.Models;
using Microsoft.EntityFrameworkCore;

namespace Aqua.Data
{
    public class AquaJoyDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=AquaJoyDB;Integrated Security=True;Trust Server Certificate=True");
        }

        public DbSet<Store> Store { get; set; }
        public DbSet<invoices> Invoices { get; set; }
        public DbSet<InvoiceDetails> InvoiceDetails { get; set; }
        public DbSet<PurchaseInvoice> PurchaseInvoice { get; set; }
        public DbSet<SalesInvoice> SalesInvoice { get; set; }
    }
}
