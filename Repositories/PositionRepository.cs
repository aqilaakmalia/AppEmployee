using System.Collections.Generic;
using System.Threading.Tasks;
using AppEmployee.Data;
using AppEmployee.Models;
using Microsoft.EntityFrameworkCore;

namespace AppEmployee.Repositories
{
    public class PositionRepository : IPositionRepository
    {
        private readonly AppDbContext _context;

        public PositionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Position>> GetAllPositionsAsync()
        {
            return await _context.Positions.ToListAsync();
        }
    }
}
