using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqua.MVVM.Models
{
    public class CreditorOrDetebtor
    {
        public int id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }
        public decimal Price { get; set; }

        [MaxLength(100)]
        public string Type { get; set; }

        public DateTime Date { get; set; }

        [MaxLength (100)]
        public string SerachDate { get; set; }
        
        [MaxLength (800)]
        public string Descriptions { get; set; }
    }
}
