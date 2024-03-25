using Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interfaces;
using WebApplication1.Interfaces.Services;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/responsible")]
    public class ResponsibleController : ControllerBase
    {
        private readonly IResponsibleService _responsibleService;

        public ResponsibleController(IResponsibleService responsibleService)
        {
            _responsibleService = responsibleService;
        }

        [HttpGet("list")]
        public IActionResult ListAllResponsible()
        {
            var reponsibles = _responsibleService.ListAllResponsible();
            return Ok(new { message = "List retrieved successfully", reponsibles });
        }
    }
}
