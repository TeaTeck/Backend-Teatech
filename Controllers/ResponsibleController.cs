using Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/responsible")]
    public class ResponsibleController : ControllerBase
    {
        private readonly IResponsibleRepository _responsible;

        public ResponsibleController(IResponsibleRepository responsible)
        {
            _responsible = responsible ?? throw new ArgumentNullException(nameof(responsible));
        }

        [HttpPost("add")]
        public IActionResult Add(string nameResponsibleOne, string responsibleKinshipOne, string responsibleCpfOne, string nameResponsibleTwo, string responsibleKinshipTwo, string responsibleCpfTwo)
        {
            var reponsible = new Responsible(nameResponsibleOne, responsibleKinshipOne, responsibleCpfOne, nameResponsibleTwo, responsibleKinshipTwo, responsibleCpfTwo);

            _responsible.Add(reponsible);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var reponsible = _responsible.GetAll();
            return Ok(reponsible);
        }
    }
}
