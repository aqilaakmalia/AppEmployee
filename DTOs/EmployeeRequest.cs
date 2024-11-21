using System;
using System.ComponentModel.DataAnnotations;

namespace AppEmployee.DTOs
{
    public class EmployeeRequest
    {
        public string Name { get; set; } = string.Empty;

        public string Gender { get; set; } = string.Empty;

        public string PlaceOfBirth { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }

        public int EmploymentStatusId { get; set; }

        public int WorkUnitId { get; set; }

        public int PositionId { get; set; }
    }
}