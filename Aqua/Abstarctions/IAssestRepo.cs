using Aqua.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqua.Abstarctions
{
    public interface IAssestRepo
    {
        IEnumerable<Assests> GetAssestsByFilter(string parameter);
        bool UpdateAssest(Assests assest);
    }
}
