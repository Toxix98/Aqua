using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqua.MVVM.Models
{
    public class BillanPlus
    {
        [Key]
        public int IdPlus { get; set; }

        [MaxLength (150)]
        public string PlusName { get; set; }

        public decimal Price { get; set; }

        [MaxLength(100)]
        public string Date { get; set; }
    }
}
