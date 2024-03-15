using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/childAssisted")]
    public class ChildAssistedController : ControllerBase
    {
        private readonly IChildAssisted _childAssisted;

        public ChildAssistedController(IChildAssisted childAssisted)
        {
            _childAssisted = childAssisted ?? throw new ArgumentNullException(nameof(childAssisted));
        }

        [HttpPost("add")]
        public IActionResult Add(string name, DateTime birthDate, string foodSelectivity, string aversions, string preferences, string medicalRecord, string photo)
        {
            var childAssited = new ChildAssisted(name, birthDate.ToUniversalTime(), foodSelectivity, aversions, preferences, medicalRecord, photo);
            _childAssisted.Add(childAssited);
            return Ok();
        }

        [HttpGet]

        public IActionResult GetAll()
        {
            var childAssisted = _childAssisted.GetAll();
            return Ok(childAssisted);
        }
    }
    
    
}
