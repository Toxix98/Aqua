using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqua.MVVM.Models
{
    public class Store
    {
        public int Id { get; set; }

        [MaxLength (150)]
        public string ProductName { get; set; }

        public int Price { get; set; }

        [MaxLength(800)]
        public string? Description { get; set; }

        [MaxLength(150)]
        public string ProductCode { get; set; }

        public int CountOfProduct { get; set; }

        [MaxLength(30)]
        public string Productype { get; set; }

    }
}
