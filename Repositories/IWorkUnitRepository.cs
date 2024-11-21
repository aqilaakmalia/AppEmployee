using System.Collections.Generic;
using System.Threading.Tasks;
using AppEmployee.Models;

namespace AppEmployee.Repositories
{
    public interface IWorkUnitRepository
    {
        Task<IEnumerable<WorkUnit>> GetAllWorkUnitsAsync();
    }
}
