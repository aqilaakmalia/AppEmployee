using Microsoft.AspNetCore.Mvc;
using AppEmployee.Repositories;
using AppEmployee.Models;
using AppEmployee.DTOs;

namespace AppEmployee.Controllers
{
    [Route("api/employment-status")]
    [ApiController]
    public class EmploymentStatusController : ControllerBase
    {
        private readonly IEmploymentStatusRepository _employmentStatusRepository;

        public EmploymentStatusController(IEmploymentStatusRepository employmentStatusRepository)
        {
            _employmentStatusRepository = employmentStatusRepository;
        }

        [HttpGet]
        public async Task<ActionResult<BaseResponse<IEnumerable<EmploymentStatus>>>> GetAll()
        {
            var employmentStatuses = await _employmentStatusRepository.GetAllEmploymentStatusesAsync();

            var response = BaseResponse<IEnumerable<EmploymentStatus>>.Success(200, "Success Get All Employment Statuses", employmentStatuses);

            return Ok(response);
        }
    }
}
