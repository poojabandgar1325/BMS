using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSWPF.Models
{
    class Loan
    {
        [Key]
        public int LoanID { get; set; }
        public string LoanType { get; set; }
        public double LoanAmount { get; set; }
        public DateTime Date { get; set; }
        public float RateOfInterest { get; set; }
        public int Duration { get; set; }
        public string Status { get; set; }
        public string Comment { get; set; }
        public int AccountNo { get; set; }
        public User User { get; set; }
    }
}
