using AppEmployee.Data;
using AppEmployee.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppEmployee.Repositories
{
    public class EmploymentStatusRepository : IEmploymentStatusRepository
    {
        private readonly AppDbContext _context;

        public EmploymentStatusRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmploymentStatus>> GetAllEmploymentStatusesAsync()
        {
            return await _context.EmploymentStatuses.ToListAsync();
        }
    }
}
