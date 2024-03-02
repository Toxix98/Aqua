using Aqua.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqua.Abstarctions
{
    public interface IStoreRepo
    {
        bool UpdateStore(Store store);
        IEnumerable<Store> GetStoreItemByFilter(string parameter);
    }
}
