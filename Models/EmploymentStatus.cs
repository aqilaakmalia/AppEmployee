using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppEmployee.Models
{
    public class EmploymentStatus
    {
        public int Id { get; set; }
        public required string Status { get; set; }
    }
}