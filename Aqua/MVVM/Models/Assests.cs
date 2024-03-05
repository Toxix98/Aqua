using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqua.MVVM.Models
{
    public class Assests
    {
        public int Id { get; set; }
        [MaxLength (150)]
        public string AssestName { get; set; }

        public decimal AssestPrice { get; set; }
        
        [MaxLength(150)]
        public string? AssestType { get; set; }

        public DateTime AssestDateOfBuye { get; set; }

        [MaxLength (150)]
        public string SearchDate { get; set; }
    }
}
