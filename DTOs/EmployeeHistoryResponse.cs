using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEmployee.Models;

namespace AppEmployee.DTOs
{
    public class EmployeeHistoryResponse
    {
        public int Id { get; set; }
        public string EmploymentStatus { get; set; } = string.Empty; 
        public string WorkUnit { get; set; } = string.Empty; 
        public string Position { get; set; } = string.Empty; 
        public DateTime ChangeDate { get; set; }
        public string ChangeType { get; set; } = string.Empty;

        public static EmployeeHistoryResponse From(EmployeeHistory employeeHistory)
        {
            return new EmployeeHistoryResponse
            {
                Id = employeeHistory.Id,
                EmploymentStatus = employeeHistory.EmploymentStatus?.Status ?? string.Empty,
                WorkUnit = employeeHistory.WorkUnit?.UnitName ?? string.Empty,
                Position = employeeHistory.Position?.PositionName ?? string.Empty,
                ChangeDate = employeeHistory.ChangeDate,
                ChangeType = employeeHistory.ChangeType
            };
        }
    }

}