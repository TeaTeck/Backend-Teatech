using Microsoft.AspNetCore.Mvc;
using Backend_TeaTech.DTO.Employees;
using Backend_TeaTech.DTO.Users;
using Backend_TeaTech.Interfaces.Services;
using Backend_TeaTech.Models;
using Backend_TeaTech.Repositories;
using Backend_TeaTech.Services;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Annotations;

namespace Backend_TeaTech.Controllers
{
    [Authorize(Roles = "Employee:Coordinator")]
    [ApiController]
    [Route("api/employee")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IUserService _userService;
        public EmployeeController(IEmployeeService employeeService, IUserService userService)
        {
            _employeeService = employeeService;
            _userService = userService;
        }

        /// <summary>
        /// Add a new employee.
        /// </summary>
        /// <remarks>
        /// Adds a new employee with the provided data.
        /// </remarks>
        [HttpPost("add")]
        [SwaggerResponse(200, "Success")]
        [SwaggerResponse(400, "Bad Request", typeof(string))]
        [SwaggerResponse(401, "Unauthorized", null)]
        [SwaggerResponse(500, "Internal Server Error", null)]
        public IActionResult Add([FromBody] EmployeeRequestDTO req)
        {
            try
            {
                User userEmployee = new User(req.Email, req.Cpf);
                userEmployee = _userService.CreateUserEmployee(userEmployee);

                Employee employee = new Employee(req.Name, req.Cpf, req.OccupationType, userEmployee);
                employee = _employeeService.CreateEmployee(employee);

                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding the employee: {ex.Message}");
            }
        }

        /// <summary>
        /// List all employees.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all employees.
        /// </remarks>
        [HttpGet("list")]
        [SwaggerResponse(200, "Success", typeof(List<Employee>))]
        [SwaggerResponse(500, "Internal Server Error", typeof(string))]
        [SwaggerResponse(400, "Bad Request", typeof(string))]
        [SwaggerResponse(401, "Unauthorized", null)]
        public IActionResult ListAllEmployee()
        {
            try
            {
                var employees = _employeeService.ListAllEmployee();
                return Ok(new { message = "List retrieved successfully", employees });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving the list of employees: {ex.Message}");
            }
        }

        /// <summary>
        /// Delete an employee.
        /// </summary>
        /// <remarks>
        /// Deletes an employee by its ID.
        /// </remarks>
        [HttpDelete("{id}")]
        [SwaggerResponse(200, "Success")]
        [SwaggerResponse(400, "Bad Request", typeof(string))]
        [SwaggerResponse(404, "Not Found", typeof(string))]
        [SwaggerResponse(500, "Internal Server Error", typeof(string))]
        public IActionResult DeleteEmployee(Guid id)
        {
            try
            {
                _employeeService.DeleteEmployeeById(id);
                return Ok("Employee deleted successfully.");
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting the employee: {ex.Message}");
            }
        }

        /// <summary>
        /// Get an employee by ID.
        /// </summary>
        /// <remarks>
        /// Retrieves an employee by its ID.
        /// </remarks>
        [HttpGet("{id}")]
        [SwaggerResponse(200, "Success", typeof(Employee))]
        [SwaggerResponse(400, "Bad Request", typeof(string))]
        [SwaggerResponse(404, "Not Found", typeof(string))]
        [SwaggerResponse(500, "Internal Server Error", typeof(string))]
        public IActionResult GetEmployeeById(Guid id)
        {
            try
            {
                var employee = _employeeService.GetEmployeeById(id);
                if (employee == null)
                {
                    return NotFound("Employee not found.");
                }
                return Ok(employee);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
            }
        }

    }
}
