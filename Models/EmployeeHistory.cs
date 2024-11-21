using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppEmployee.Models
{
    public class EmployeeHistory
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int EmploymentStatusId { get; set; }
        public int WorkUnitId { get; set; }
        public int PositionId { get; set; }
        public DateTime ChangeDate { get; set; }
        public required string ChangeType { get; set; }

        // Navigation properties
        public Employee? Employee { get; set; }
        public EmploymentStatus? EmploymentStatus { get; set; }
        public WorkUnit? WorkUnit { get; set; }
        public Position? Position { get; set; }
    }
}