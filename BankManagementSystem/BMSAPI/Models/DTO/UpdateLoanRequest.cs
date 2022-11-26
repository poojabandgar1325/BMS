using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMSAPI.Models.DTO
{
    public class UpdateLoanRequest
    {
        public string Status { get; set; }
        public string Comment { get; set; }
    }
}
