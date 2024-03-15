using Microsoft.AspNetCore.Mvc;
using WebApplication1.Enum;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUser _user;
        public UserController(IUser user)
        {
            _user = user ?? throw new ArgumentNullException(nameof(user));
        }
        [HttpPost("add")]
        public IActionResult Add(string email, string password, UserType userType)
        {
            var user = new User(email, password, userType);

            _user.Add(user);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var user = _user.GetAll();
            return Ok(user);
        }

    }
}
