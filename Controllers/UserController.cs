using Microsoft.AspNetCore.Mvc;
using Backend_TeaTech.Interfaces.Services;
using Backend_TeaTech.Services;
using Backend_TeaTech.DTO.Users;
using Microsoft.AspNetCore.Authorization;

namespace Backend_TeaTech.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize(Roles = "Employee:Coordinator")]
        [HttpGet("list")]
        public IActionResult ListAllUser()
        {
            var users = _userService.ListAllUser();
            return Ok(new { message = "List retrieved successfully", users });
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserRequestDTO req)
        {
            if (string.IsNullOrEmpty(req.Email) || string.IsNullOrEmpty(req.Password))
            {
                return BadRequest("Invalid login data");
            }

            string token = _userService.Login(req.Email, req.Password);

            if (!string.IsNullOrEmpty(token))
            {
                return Ok(new { message = "Login successful", token });

            }
            else
            {
                return Unauthorized(new { message = "Invalid email or password" });
            }
        }

        [Authorize(Roles = "Employee:Coordinator")]
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(Guid id)
        {
            try
            {
                _userService.DeleteUserById(id);
                return Ok("User deleted successfully.");
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

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetUserById(Guid id)
        {
            try
            {
                var user = _userService.GetUserById(id);
                if (user == null)
                {
                    return NotFound("User not found.");
                }
                return Ok(user);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing the request." + ex);
            }

        }


    }
}
