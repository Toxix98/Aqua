using Aqua.Abstarctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Aqua.Data;
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;

namespace Aqua.Repository
{
    public class BaseRepo<T> : IBaseRepo<T> where T :class
    {
        private AquaJoyDBContext db;
        private DbSet<T> _dbSet;
        public string StatusMessage { get; set; }
        public BaseRepo(AquaJoyDBContext Context)
        {
            db = Context;
            _dbSet = db.Set<T>();
        }
        public void AddItem(T item)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    _dbSet.Add(item);
                    db.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    StatusMessage = "Error adding item " + ex.Message;
                }
            }
        }


        public void DeletItem(T item)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    _dbSet.Remove(item);
                    db.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    StatusMessage = "Error deleting item " + ex.Message;
                }
            }
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public T GetItem(int id)
        {
            return _dbSet.Find(id);
        }

        public List<T> GetItems()
        {
            return _dbSet.ToList();
        }

        public void UpdateItem(T item)
        {
            using (var transactions = db.Database.BeginTransaction())
            {
                try
                {
                    _dbSet.Update(item);
                    db.SaveChanges();
                    transactions.Commit();
                }
                catch(Exception ex)
                {
                    transactions.Rollback();
                    StatusMessage = "Error Updating item " + ex.Message;
                }
            }
        }
    }
}
