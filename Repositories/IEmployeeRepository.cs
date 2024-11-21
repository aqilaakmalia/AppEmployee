using System.Collections.Generic;
using System.Threading.Tasks;
using AppEmployee.DTOs;
using AppEmployee.Models;

namespace AppEmployee.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<ListEmployeeResponse>> GetAllEmployeesAsync(EmployeeFilter filter, int pageNumber = 1, int pageSize = 10);
        Task<DetailEmployeeResponse?> GetEmployeeByIdAsync(int id);
        Employee? GetEmployeeById(int id);
        Task AddEmployeeAsync(Employee employee);
        Task UpdateEmployeeAsync(Employee employee);
        Task DeleteEmployeeAsync(int id);
        Task<int> CountEmployeesAsync(EmployeeFilter filter);
        
    }
}
