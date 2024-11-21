using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace AppEmployee.DTOs
{
    public class EmployeeFilter
    {
        [SwaggerSchema(Description = "Filter by Employee Number (partial match)")]
        public string? EmployeeId { get; set; }

        [SwaggerSchema(Description = "Filter by Employee Name (partial match)")]
        public string? Name { get; set; }

        [SwaggerSchema(Description = "Filter by Gender (e.g., 'Laki-laki', 'Perempuan')")]
        public string? Gender { get; set; }

        [SwaggerSchema(Description = "Filter by Employment Status ID")]
        public int? EmploymentStatusId { get; set; }

        [SwaggerSchema(Description = "Filter by Position ID")]
        public int? PositionId { get; set; }

        [SwaggerSchema(Description = "Filter by Work Unit ID")]
        public int? WorkUnitId { get; set; }
    }
}
