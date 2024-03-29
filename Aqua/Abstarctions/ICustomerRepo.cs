﻿using Aqua.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqua.Abstarctions
{
    public interface ICustomerRepo
    {
        IEnumerable<Customers> GetCustomerByFilter(string parameter);
        bool UpdateCustomers(Customers customers);
    }
}
