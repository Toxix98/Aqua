using Aqua.Abstarctions;
using Aqua.Data;
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

        public CustomersRepo(AquaJoyDBContext context)
        {
            db = context;
        }
    }
}
