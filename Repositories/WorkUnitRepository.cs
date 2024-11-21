using AppEmployee.Data;
using AppEmployee.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppEmployee.Repositories
{
    public class WorkUnitRepository : IWorkUnitRepository
    {
        private readonly AppDbContext _context;

        public WorkUnitRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<WorkUnit>> GetAllWorkUnitsAsync()
        {
            return await _context.WorkUnits.ToListAsync();
        }
    }
}
