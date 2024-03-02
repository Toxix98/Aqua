using Aqua.Abstarctions;
using Aqua.Data;
using Aqua.MVVM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqua.Repository
{
    public class StoreRepo : IStoreRepo
    {
        private AquaJoyDBContext db;

        public StoreRepo(AquaJoyDBContext context)
        {
            db = context;
        }
        public bool UpdateStore(Store store)
        {
            db.Store.Update(store);
            return true;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public IEnumerable<Store> GetStoreItemByFilter(string parameter)
        {
            return db.Store.Where(p => p.Productype.Contains(parameter) || p.Description.Contains(parameter) ||
                p.ProductName.Contains(parameter) || p.ProductCode.Contains(parameter)).ToList();
        }
    }
}
