using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSWPF.Models
{
    public class User
    {
        [Key]
        public int AccountNo { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string EmailID { get; set; }
        public string PAN { get; set; }
        public long ContactNo { get; set; }
        public DateTime DOB { get; set; }
        public string AccountType { get; set; }
        public int Role { get; set; }
        public string JWT { get; set; }

    }
}
