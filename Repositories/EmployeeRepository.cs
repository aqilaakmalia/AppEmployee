using Microsoft.EntityFrameworkCore;
using AppEmployee.Data;
using AppEmployee.Models;
using AppEmployee.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppEmployee.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ListEmployeeResponse>> GetAllEmployeesAsync(EmployeeFilter filter, int pageNumber = 1, int pageSize = 10)
        {
            var query = _context.Employees
                .Include(e => e.EmploymentStatus)
                .Include(e => e.WorkUnit)
                .Include(e => e.Position)
                .AsQueryable();

            // Filter logic
            if (!string.IsNullOrWhiteSpace(filter.EmployeeId))
                query = query.Where(e => e.EmployeeNumber.Contains(filter.EmployeeId));

            if (!string.IsNullOrWhiteSpace(filter.Name))
                query = query.Where(e => e.Name.Contains(filter.Name));

            if (!string.IsNullOrWhiteSpace(filter.Gender))
                query = query.Where(e => e.Gender == filter.Gender);

            if (filter.EmploymentStatusId.HasValue)
                query = query.Where(e => e.EmploymentStatusId == filter.EmploymentStatusId);

            if (filter.PositionId.HasValue)
                query = query.Where(e => e.PositionId == filter.PositionId);

            if (filter.WorkUnitId.HasValue)
                query = query.Where(e => e.WorkUnitId == filter.WorkUnitId);

            // Pagination
            var totalRecords = await query.CountAsync(); // Optional: For returning total records
            var employees = await query
                .OrderBy(e => e.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return employees.Select(employee => ListEmployeeResponse.From(employee)).ToList();
        }


        public async Task<DetailEmployeeResponse?> GetEmployeeByIdAsync(int id)
        {
            var employee = await _context.Employees
                .Include(e => e.EmploymentStatus)
                .Include(e => e.WorkUnit)
                .Include(e => e.Position)
                .Include(e => e.EmployeeHistories)
                    .ThenInclude(h => h.EmploymentStatus)
                .Include(e => e.EmployeeHistories)
                    .ThenInclude(h => h.WorkUnit)
                .Include(e => e.EmployeeHistories)
                    .ThenInclude(h => h.Position)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (employee == null) return null;

            return DetailEmployeeResponse.From(employee);
        }

        public Employee? GetEmployeeById(int id)
        {
            return _context.Employees
                .Include(e => e.EmploymentStatus)
                .Include(e => e.WorkUnit)
                .Include(e => e.Position)
                .FirstOrDefault(e => e.Id == id);
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var employee = await _context.Employees
                .Include(e => e.EmployeeHistories)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (employee != null)
            {
                _context.EmployeeHistory.RemoveRange(employee.EmployeeHistories);

                _context.Employees.Remove(employee);

                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> CountEmployeesAsync(EmployeeFilter filter)
        {
            var query = _context.Employees.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.EmployeeId))
                query = query.Where(e => e.EmployeeNumber.Contains(filter.EmployeeId));

            if (!string.IsNullOrWhiteSpace(filter.Name))
                query = query.Where(e => e.Name.Contains(filter.Name));

            if (!string.IsNullOrWhiteSpace(filter.Gender))
                query = query.Where(e => e.Gender == filter.Gender);
            
            if (filter.EmploymentStatusId.HasValue)
                query = query.Where(e => e.EmploymentStatusId == filter.EmploymentStatusId);

            if (filter.PositionId.HasValue)
                query = query.Where(e => e.PositionId == filter.PositionId);

            if (filter.WorkUnitId.HasValue)
                query = query.Where(e => e.WorkUnitId == filter.WorkUnitId);

            return await query.CountAsync();
        }


    }
}
