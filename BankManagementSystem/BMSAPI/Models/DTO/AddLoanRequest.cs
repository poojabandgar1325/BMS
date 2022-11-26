using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMSAPI.Models.DTO
{
    public class AddLoanRequest
    {
        public string LoanType { get; set; }
        public double LoanAmount { get; set; }
        public DateTime Date { get; set; }
        public float RateOfInterest { get; set; }
        public int Duration { get; set; }
       // public string Status { get; set; }
       // public string Comment { get; set; }
        public int AccountNo { get; set; }
       
    }
}
