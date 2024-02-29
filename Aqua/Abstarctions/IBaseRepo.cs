using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqua.Abstarctions
{
    public interface IBaseRepo<T> : IDisposable where T :class, new()
    {
        void AddItem(T item);
        T GetItem(int id);
        List<T> GetItems();
        void DeletItem(T item);
    }
}
