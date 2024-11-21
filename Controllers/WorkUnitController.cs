using Microsoft.AspNetCore.Mvc;
using AppEmployee.Repositories;
using AppEmployee.Models;
using AppEmployee.DTOs; // Make sure to include the DTOs namespace
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppEmployee.Controllers
{
    [Route("api/work-unit")]
    [ApiController]
    public class WorkUnitController : ControllerBase
    {
        private readonly IWorkUnitRepository _workUnitRepository;

        public WorkUnitController(IWorkUnitRepository workUnitRepository)
        {
            _workUnitRepository = workUnitRepository;
        }

        [HttpGet]
        public async Task<ActionResult<BaseResponse<IEnumerable<WorkUnit>>>> GetAll()
        {
            var workUnits = await _workUnitRepository.GetAllWorkUnitsAsync();

            var response = BaseResponse<IEnumerable<WorkUnit>>.Success(200, "Success Get All Work Units", workUnits);

            return Ok(response);
        }
    }
}
