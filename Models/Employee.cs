using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AppEmployee.Models
{ 
   public class Employee
    {
        public int Id { get; set; }

        [JsonPropertyName("employeeNumber")]
        public required string EmployeeNumber { get; set; }

        [JsonPropertyName("name")]
        public required string Name { get; set; }

        [JsonPropertyName("gender")]
        public required string Gender { get; set; }

        [JsonPropertyName("placeOfBirth")]
        public required string PlaceOfBirth { get; set; }

        [JsonPropertyName("dateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        [JsonIgnore]
        public int EmploymentStatusId { get; set; }
        [JsonIgnore]
        public int WorkUnitId { get; set; }
        [JsonIgnore]
        public int PositionId { get; set; }

        [JsonPropertyName("employmentStatus")] 
        public EmploymentStatus? EmploymentStatus { get; set; }

        [JsonPropertyName("workUnit")]
        public WorkUnit? WorkUnit { get; set; }

        [JsonPropertyName("position")]
        public Position? Position { get; set; }      

        public ICollection<EmployeeHistory> EmployeeHistories { get; set; } = new List<EmployeeHistory>();
    }
}
