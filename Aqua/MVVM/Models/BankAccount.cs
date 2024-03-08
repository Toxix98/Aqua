using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqua.MVVM.Models
{
    public class BankAccount
    {
        public int Id { get; set; }

        [MaxLength (150)]
        public string BankName { get; set; }

        [MaxLength(30)]
        public string BankAccountNumber { get; set; }

        [MaxLength(150)]
        public string? BankBranck { get; set; }

    }
}
