﻿using Aqua.Abstarctions;
using Aqua.Data;
using Aqua.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqua.Repository
{
    public class CustomersRepo : ICustomerRepo
    {
        private AquaJoyDBContext db;
        public string StatuceMessage { get; set; }

        public CustomersRepo(AquaJoyDBContext context)
        {
            db = context;
        }

        public IEnumerable<Customers> GetCustomerByFilter(string parameter)
        {
           return db.Customers.Where(c=> c.Name.Contains(parameter) || c.Family.Contains(parameter) || c.PhoneNumber.Contains(parameter)
            || c.Address.Contains(parameter) || c.SubCode.Contains(parameter));
        }

        public bool UpdateCustomers(Customers customers)
        {
            try
            {
                db.Customers.Update(customers);
                return true;
            }
            catch (Exception ex)
            {
                StatuceMessage = "Erro for Updating Customer : " + ex.Message;
                return false;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
