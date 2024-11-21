using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEmployee.Models;

namespace AppEmployee.DTOs
{
    public class DetailEmployeeResponse
    {
        public int Id { get; set; }
        public string EmployeeNumber { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string PlaceOfBirth { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string EmploymentStatus { get; set; } = string.Empty; 
        public string WorkUnit { get; set; } = string.Empty; 
        public string Position { get; set; } = string.Empty;
        public List<EmployeeHistoryResponse> EmployeeHistories { get; set; } = new List<EmployeeHistoryResponse>();

        public static DetailEmployeeResponse From(Employee employee)
        {
            return new DetailEmployeeResponse
            {
                Id = employee.Id,
                EmployeeNumber = employee.EmployeeNumber,
                Name = employee.Name,
                Gender = employee.Gender,
                PlaceOfBirth = employee.PlaceOfBirth,
                DateOfBirth = employee.DateOfBirth,
                EmploymentStatus = employee.EmploymentStatus?.Status ?? string.Empty,
                WorkUnit = employee.WorkUnit?.UnitName ?? string.Empty,
                Position = employee.Position?.PositionName ?? string.Empty,
                EmployeeHistories = employee.EmployeeHistories.Select(h => EmployeeHistoryResponse.From(h)).ToList() 
            };
        }
    }

}