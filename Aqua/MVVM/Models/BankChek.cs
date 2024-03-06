using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqua.MVVM.Models
{
    public class BankChek
    {
        public int Id { get; set; }

        public int BankChekId { get; set; }

        [MaxLength(200)]
        public string ChekNumber { get; set; }

        [MaxLength(150)]
        public string Bank { get; set; }

        public int ChekPrice { get; set; }

        [MaxLength(100)]
        public string Assignment { get; set; }

        [MaxLength(50)]
        public string IssueDtaeSTR { get; set; }

        public DateTime IssueDate { get; set; }

        [MaxLength(50)]
        public string DueDateSTR { get; set; }

        public DateTime DueDate { get; set; }

        [MaxLength(800)]
        public string? Descriptions { get; set; }
    }
}
