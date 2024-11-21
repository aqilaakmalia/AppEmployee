using System.Collections.Generic;
using System.Threading.Tasks;
using AppEmployee.Models;

namespace AppEmployee.Repositories
{
    public interface IPositionRepository
    {
        Task<IEnumerable<Position>> GetAllPositionsAsync();
    }
}
