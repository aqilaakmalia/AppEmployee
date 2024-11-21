using System.Collections.Generic;
using System.Threading.Tasks;
using AppEmployee.Models;

namespace AppEmployee.Repositories
{
    public interface IEmploymentStatusRepository
    {
        Task<IEnumerable<EmploymentStatus>> GetAllEmploymentStatusesAsync();
    }
}
