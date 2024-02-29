using Aqua.Abstarctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Aqua.Data;
using System.Reflection.Metadata;

namespace Aqua.Repository
{
    public class BaseRepo<T> : IBaseRepo<T> where T :class, new()
    {
        private AquaJoyDBContext db;
        public string StatusMessage { get; set; }
        public BaseRepo(AquaJoyDBContext Context)
        {
            db = Context;
        }
        public void AddItem(T item)
        {
            int result = 0;
            try
            {
                db.Set<T>().Add(item);
            }
            catch 
            {
                
            }
        }

        public void DeletItem(T item)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public T GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public List<T> GetItems()
        {
            throw new NotImplementedException();
        }
    }
}
