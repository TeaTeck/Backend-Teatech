using Microsoft.AspNetCore.Mvc;
using Backend_TeaTech.Interfaces.Services;
using Backend_TeaTech.Services;

namespace Backend_TeaTech.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly JwtService _jwtService;

        public UserController(IUserService userService, JwtService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }

        [HttpGet("list")]
        public IActionResult ListAllUser()
        {
            var users = _userService.ListAllUser();
            return Ok(new { message = "List retrieved successfully", users });
        }

        [HttpPost("login")]
        public IActionResult Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return BadRequest("Invalid login data");
            }

            string token = _userService.Login(email, password);

            if (!string.IsNullOrEmpty(token))
            {
                return Ok(new { message = "Login successful", token });

            }
            else
            {
                return Unauthorized(new { message = "Invalid email or password" });
            }
        }

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

    }
}
