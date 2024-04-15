using Microsoft.AspNetCore.Mvc;
using Backend_TeaTech.DTO.Employees;
using Backend_TeaTech.DTO.Users;
using Backend_TeaTech.Interfaces.Services;
using Backend_TeaTech.Models;
using Backend_TeaTech.Repositories;
using Backend_TeaTech.Services;

namespace Backend_TeaTech.Controllers
{
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
        [HttpPost("add")]
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
            catch (Exception ex) 
            {
                return BadRequest($"{ex.Message}");
            }
            
        }

        [HttpGet("list")]
        public IActionResult ListAllEmployee()
        {
            var employees = _employeeService.ListAllEmployee();
            return Ok(new { message = "List retrieved successfully", employees });
        }

        [HttpDelete("{id}")]
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
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }
    }
}
