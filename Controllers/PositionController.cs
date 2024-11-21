using Microsoft.AspNetCore.Mvc;
using AppEmployee.Repositories;
using AppEmployee.Models;

namespace AppEmployee.Controllers
{
    [Route("api/position")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly IPositionRepository _positionRepository;

        public PositionController(IPositionRepository positionRepository)
        {
            _positionRepository = positionRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Position>>> GetAll()
        {
            var positions = await _positionRepository.GetAllPositionsAsync();

            var response = DTOs.BaseResponse<IEnumerable<Position>>.Success(200, "Success Get All Positions", positions);

            return Ok(response);
        }
    }
}
