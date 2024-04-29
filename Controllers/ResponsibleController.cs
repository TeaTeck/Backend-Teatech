using Microsoft.AspNetCore.Mvc;
using Backend_TeaTech.Interfaces.Services;
using Backend_TeaTech.DTO.Responsibles;
using Backend_TeaTech.Services;
using Microsoft.AspNetCore.Authorization;

namespace Backend_TeaTech.Controllers
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

        [Authorize(Policy = "CoordinatorOrApplicator")]
        [HttpGet("list")]
        public IActionResult ListAllResponsible()
        {
            var reponsibles = _responsibleService.ListAllResponsible();
            return Ok(new { message = "List retrieved successfully", reponsibles });
        }

        [Authorize(Roles = "Employee:Coordinator")]
        [HttpDelete("{id}")]
        public IActionResult DeleteResponsible(Guid id)
        {
            try
            {
                _responsibleService.DeleteResponsibleById(id);
                return Ok("Responsible deleted successfully.");
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

        [Authorize(Roles = "CoordinatorOrResponsible")]
        [HttpPut("update/{id}")]
        public IActionResult PutResponsible(Guid id, [FromBody] ResponsibleRequestDTO req)
        {
            return Ok("Responsible updated successfully.");
            //Adicionar regra de negócio
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetResponsibleById(Guid id)
        {
            try
            {
                var responsible = _responsibleService.GetResponsibleById(id);
                if (responsible == null)
                {
                    return NotFound("Resposible not found.");
                }
                return Ok(responsible);
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
