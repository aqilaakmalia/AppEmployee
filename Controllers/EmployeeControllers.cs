using Microsoft.AspNetCore.Mvc;
using AppEmployee.Models;
using AppEmployee.Repositories;
using AppEmployee.DTOs;
using AppEmployee.Data;
using System.Text.Json;
using Swashbuckle.AspNetCore.Annotations;

namespace AppEmployee.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly AppDbContext _context;

        public EmployeeController(IEmployeeRepository employeeRepository, AppDbContext context)
        {
            _employeeRepository = employeeRepository;
            _context = context;
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Get all employees",
            Description = "Get a list of employees with optional filtering and pagination"
        )]
        public async Task<ActionResult<BaseResponse<PaginatedResponse<ListEmployeeResponse>>>> GetAll(
            [FromQuery] EmployeeFilter filter, 
            [FromQuery] int pageNumber = 1, 
            [FromQuery] int pageSize = 10)
        {
            var totalData = await _employeeRepository.CountEmployeesAsync(filter);
            
            var employees = await _employeeRepository.GetAllEmployeesAsync(filter, pageNumber, pageSize);

            if (employees == null || !employees.Any())
            {
                return NotFound(BaseResponse<PaginatedResponse<ListEmployeeResponse>>.Failure(404, "No employees found"));
            }

            var totalPages = (int)Math.Ceiling((double)totalData / pageSize);

            var paginatedResponse = new PaginatedResponse<ListEmployeeResponse>
            {
                Items = employees,
                TotalData = totalData,
                CurrentPage = pageNumber,
                TotalPages = totalPages
            };

            var response = BaseResponse<PaginatedResponse<ListEmployeeResponse>>.Success(200, "Success Get All Employees", paginatedResponse);

            return Ok(response);
        }


        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Get employee by ID",
            Description = "Retrieves the details of an employee by their ID. It returns a detailed response including employee name, gender, place of birth, date of birth, and associated information such as employment status, work unit, and position."
        )]
        public async Task<ActionResult<BaseResponse<DetailEmployeeResponse>>> GetById(int id)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(id);

            if (employee == null) 
            {
                return NotFound(BaseResponse<DetailEmployeeResponse>.Failure(404, "Employee not found"));
            }

            var response = BaseResponse<DetailEmployeeResponse>.Success(200, $"Success Get Employee by ID: {id}", employee);

            return Ok(response);
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Create a new employee",
            Description = "Create a new employee in the system. The request must contain the employee's basic details like Name, Gender, Place of Birth, Date of Birth, Employment Status ID, Work Unit ID, and Position ID."
        )]
        public async Task<ActionResult> Create([FromBody] EmployeeRequest employeeRequest)
        {
            Console.WriteLine($"Received Employee Request: {JsonSerializer.Serialize(employeeRequest)}");
            
            if (employeeRequest == null)
            {
                return BadRequest(BaseResponse<EmployeeResponse>.Failure(400, "Invalid employee data"));
            }

            var employmentStatus = await _context.EmploymentStatuses.FindAsync(employeeRequest.EmploymentStatusId);
            if (employmentStatus == null)
            {
                return BadRequest(BaseResponse<EmployeeResponse>.Failure(400, "Invalid Employment Status ID"));
            }

            var workUnit = await _context.WorkUnits.FindAsync(employeeRequest.WorkUnitId);
            if (workUnit == null)
            {
                return BadRequest(BaseResponse<EmployeeResponse>.Failure(400, "Invalid Work Unit ID"));
            }

            var position = await _context.Positions.FindAsync(employeeRequest.PositionId);
            if (position == null)
            {
                return BadRequest(BaseResponse<EmployeeResponse>.Failure(400, "Invalid Position ID"));
            }

            var employee = new Employee
            {
                EmployeeNumber = GenerateEmployeeNumber(),
                Name = employeeRequest.Name,
                Gender = employeeRequest.Gender,
                PlaceOfBirth = employeeRequest.PlaceOfBirth,
                DateOfBirth = employeeRequest.DateOfBirth,
                EmploymentStatusId = employeeRequest.EmploymentStatusId,
                WorkUnitId = employeeRequest.WorkUnitId,
                PositionId = employeeRequest.PositionId
            };

            try
            {
                await _employeeRepository.AddEmployeeAsync(employee);

                var employeeHistory = new EmployeeHistory
                {
                    EmployeeId = employee.Id,
                    EmploymentStatusId = employee.EmploymentStatusId,
                    WorkUnitId = employee.WorkUnitId,
                    PositionId = employee.PositionId,
                    ChangeDate = DateTime.Now,
                    ChangeType = "Initial Entry"
                };

                await _context.EmployeeHistory.AddAsync(employeeHistory);
                await _context.SaveChangesAsync();

                var createdEmployee = await _employeeRepository.GetEmployeeByIdAsync(employee.Id);

                if (createdEmployee == null)
                {
                    return NotFound(BaseResponse<DetailEmployeeResponse>.Failure(404, "Employee not found after creation"));
                }

                var responseData = new EmployeeResponse
                {
                    Id = createdEmployee.Id,
                    EmployeeId = createdEmployee.EmployeeNumber,              
                    Name = createdEmployee.Name,
                    Gender = createdEmployee.Gender,
                    PlaceOfBirth = createdEmployee.PlaceOfBirth,
                    DateOfBirth = createdEmployee.DateOfBirth,
                    EmploymentStatus = createdEmployee.EmploymentStatus,
                    WorkUnit = createdEmployee.WorkUnit,
                    Position = createdEmployee.Position
                };

                var response = BaseResponse<EmployeeResponse>.Success(200, "Employee created successfully", responseData);

                return CreatedAtAction(nameof(Create), new { id = employee.Id }, response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        private string GenerateEmployeeNumber()
        {
            var timestamp = DateTime.Now.ToString("yyMMdd");
            var randomNumber = new Random().Next(100, 1000);
            return $"{timestamp}{randomNumber}";
        }

        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Update an existing employee",
            Description = "update the details of an existing employee. The request must include the employee's updated information such as Name, Gender, Place of Birth, Employment Status ID, Work Unit ID, and Position ID."
        )]
        public async Task<ActionResult<BaseResponse<EmployeeResponse>>> Update(int id, [FromBody] EmployeeRequest employeeRequest)
        {
            if (employeeRequest == null)
            {
                return BadRequest(BaseResponse<EmployeeResponse>.Failure(400, "Invalid employee data"));
            }

            var employee = _employeeRepository.GetEmployeeById(id);
            if (employee == null)
            {
                 return NotFound(BaseResponse<DetailEmployeeResponse>.Failure(404, "Employee not found"));
            }

            var employmentStatus = await _context.EmploymentStatuses.FindAsync(employeeRequest.EmploymentStatusId);
            if (employmentStatus == null)
            {
                return BadRequest(BaseResponse<EmployeeResponse>.Failure(400, "Invalid Employment Status ID"));
            }

            var workUnit = await _context.WorkUnits.FindAsync(employeeRequest.WorkUnitId);
            if (workUnit == null)
            {
                return BadRequest(BaseResponse<EmployeeResponse>.Failure(400, "Invalid Work Unit ID"));
            }

            var position = await _context.Positions.FindAsync(employeeRequest.PositionId);
            if (position == null)
            {
                return BadRequest(BaseResponse<EmployeeResponse>.Failure(400, "Invalid Position ID"));
            }

            try {
                employee.Name = employeeRequest.Name;
                employee.Gender = employeeRequest.Gender;
                employee.PlaceOfBirth = employeeRequest.PlaceOfBirth;
                employee.DateOfBirth = employeeRequest.DateOfBirth;
                employee.EmploymentStatusId = employeeRequest.EmploymentStatusId;
                employee.WorkUnitId = employeeRequest.WorkUnitId;
                employee.PositionId = employeeRequest.PositionId;

                await _employeeRepository.UpdateEmployeeAsync(employee);

                var employeeHistory = new EmployeeHistory
                {
                    EmployeeId = employee.Id,
                    EmploymentStatusId = employee.EmploymentStatusId,
                    WorkUnitId = employee.WorkUnitId,
                    PositionId = employee.PositionId,
                    ChangeDate = DateTime.Now,
                    ChangeType = "Update" 
                };

                await _context.EmployeeHistory.AddAsync(employeeHistory);
                await _context.SaveChangesAsync();

                var createdEmployee = await _employeeRepository.GetEmployeeByIdAsync(employee.Id);

                if (createdEmployee == null)
                {
                    return NotFound(BaseResponse<DetailEmployeeResponse>.Failure(404, "Employee not found after update"));
                }

                var responseData = new EmployeeResponse
                {
                    Id = createdEmployee.Id,
                    EmployeeId = createdEmployee.EmployeeNumber,              
                    Name = createdEmployee.Name,
                    Gender = createdEmployee.Gender,
                    PlaceOfBirth = createdEmployee.PlaceOfBirth,
                    DateOfBirth = createdEmployee.DateOfBirth,
                    EmploymentStatus = createdEmployee.EmploymentStatus,
                    WorkUnit = createdEmployee.WorkUnit,
                    Position = createdEmployee.Position
                };

                var response = BaseResponse<EmployeeResponse>.Success(200, "Employee updated successfully", responseData);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Delete an employee by ID",
            Description = "Deletes an employee by their unique ID. It will return a success message if the employee is deleted successfully, or an error if the employee does not exist."
        )]
        public async Task<ActionResult<BaseResponse<object>>> Delete(int id)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound(BaseResponse<DetailEmployeeResponse>.Failure(404, $"Employee with ID {id} not found"));
            }

            await _employeeRepository.DeleteEmployeeAsync(id);

            var response = BaseResponse<object>.Success(200, $"Employee with ID {id} has been successfully deleted", null);

            return Ok(response);
        }

    }
}
