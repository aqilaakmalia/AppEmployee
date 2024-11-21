using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using AppEmployee.Models;

namespace AppEmployee.Data
{
    public static class DbInitializer
    {
        public static async Task Initialize(AppDbContext context)
        {
            // Seed EmploymentStatuses jika kosong
            if (!context.EmploymentStatuses.Any())
            {
                var statuses = new[]
                {
                    new EmploymentStatus { Status = "Tetap" },
                    new EmploymentStatus { Status = "Kontrak" }
                };
                await context.EmploymentStatuses.AddRangeAsync(statuses);
                await context.SaveChangesAsync();
            }

            // Seed WorkUnits jika kosong
            if (!context.WorkUnits.Any())
            {
                var units = new[]
                {
                    new WorkUnit { UnitName = "Keuangan" }, 
                    new WorkUnit { UnitName = "HRD" }, 
                    new WorkUnit { UnitName = "Pemasaran" },
                    new WorkUnit { UnitName = "Produksi" }, 
                    new WorkUnit { UnitName = "Umum" },
                    new WorkUnit { UnitName = "IT" }
                };
                await context.WorkUnits.AddRangeAsync(units);
                await context.SaveChangesAsync();
            }

            // Seed Positions jika kosong
            if (!context.Positions.Any())
            {
                var positions = new[]
                {
                    new Position { PositionName = "Developer" },
                    new Position { PositionName = "Manager" },
                    new Position { PositionName = "Asisten Manager" },
                    new Position { PositionName = "Analyst" },
                    new Position { PositionName = "Staff" }
                };
                await context.Positions.AddRangeAsync(positions);
                await context.SaveChangesAsync();
            }

            // Seed Employees jika kosong
            if (!context.Employees.Any())
            {
                var employees = new[]
                {
                    new Employee
                    {
                        EmployeeNumber = "E001",
                        Name = "Ali Rahman",
                        Gender = "Laki-laki",
                        PlaceOfBirth = "Jakarta",
                        DateOfBirth = new DateTime(1990, 1, 15),
                        EmploymentStatusId = 1, // Tetap
                        WorkUnitId = 1, // Keuangan
                        PositionId = 1 // Developer
                    },
                    new Employee
                    {
                        EmployeeNumber = "E002",
                        Name = "Siti Aminah",
                        Gender = "Perempuan",
                        PlaceOfBirth = "Bandung",
                        DateOfBirth = new DateTime(1992, 3, 22),
                        EmploymentStatusId = 2, // Kontrak
                        WorkUnitId = 2, // HRD
                        PositionId = 2 // Manager
                    },
                    new Employee
                    {
                        EmployeeNumber = "E003",
                        Name = "Budi Santoso",
                        Gender = "Laki-laki",
                        PlaceOfBirth = "Surabaya",
                        DateOfBirth = new DateTime(1988, 5, 10),
                        EmploymentStatusId = 1, // Tetap
                        WorkUnitId = 3, // Pemasaran
                        PositionId = 3 // Analyst
                    }
                };
                await context.Employees.AddRangeAsync(employees);
                await context.SaveChangesAsync();
            }

            // Seed EmployeeHistory
            if (!context.EmployeeHistory.Any()) 
            {
                var histories = new[]
                {
                    new EmployeeHistory
                    {
                        EmployeeId = 1,
                        EmploymentStatusId = 2, //Kontrak
                        WorkUnitId = 1, //Keuangan
                        PositionId = 5, //Staff
                        ChangeDate = new DateTime(2022, 9, 18),
                        ChangeType = "Initial Entry"
                    },
                    new EmployeeHistory
                    {
                        EmployeeId = 1,
                        EmploymentStatusId = 1, //Tetap
                        WorkUnitId = 1, //Keuangan
                        PositionId = 3, //Asisten Manager
                        ChangeDate = DateTime.Now,
                        ChangeType = "Update"
                    },
                    new EmployeeHistory
                    {
                        EmployeeId = 2,
                        EmploymentStatusId = 2,
                        WorkUnitId = 2,
                        PositionId = 2,
                        ChangeDate = new DateTime(2023, 1, 5),
                        ChangeType = "Initial Entry"
                    },
                    new EmployeeHistory
                    {
                        EmployeeId = 2,
                        EmploymentStatusId = 1,
                        WorkUnitId = 2,
                        PositionId = 2,
                        ChangeDate = DateTime.Now,
                        ChangeType = "Update"
                    }
                };
                
            await context.EmployeeHistory.AddRangeAsync(histories);
            await context.SaveChangesAsync();
            }
            
           
        }
    }
}
