using Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Enum;
using WebApplication1.Interfaces.Services;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
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

    }
}
