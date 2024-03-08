using Aqua.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqua.Abstarctions
{
    public interface IInvoiceRepo
    {
        bool UpdateInvoice(invoices invoices);
        IEnumerable<invoices> GetInvoicesByfilter(string parameter);
    }
}
