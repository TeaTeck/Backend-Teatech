using Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Enum;
using WebApplication1.Interfaces.Services;
using WebApplication1.lib;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/childAssisted")]
    public class ChildAssistedController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IChildAssistedService _childAssistedService;
        private readonly IResponsibleService _responsibleService;

        public ChildAssistedController(IUserService userService, IChildAssistedService childAssistedService, IResponsibleService responsibleService)
        {
            _userService = userService;
            _childAssistedService = childAssistedService;
            _responsibleService = responsibleService;
        }

        [HttpPost("add")]
        public IActionResult Add(string name, DateTime birthDate, string foodSelectivity, string aversions, string preferences, string medicalRecord, string photo, string email, string responsibleCpfOne, string nameResponsibleOne, string responsibleKinshipOne, string nameResponsibleTwo, string responsibleKinshipTwo, string responsibleCpfTwo, string contactOne, string contactTwo)
        {
            //Criar usuario
            //User userResponsible = _userService.CreateUserResponsible("Passar dados")
            //Criar responsavel
            //Responsible responsible = _responsibleService.CreateResponsible("Passar dados do responsavel e o userResponsavel")
            //Criar criança

            try
            {
                User userResponsible = new User(email, responsibleCpfOne);
                userResponsible = _userService.CreateUserResponsible(userResponsible);

                Responsible responsible = new Responsible(nameResponsibleOne, responsibleCpfOne, responsibleKinshipOne, nameResponsibleTwo, responsibleKinshipTwo, responsibleCpfTwo, contactOne, contactTwo, userResponsible);
                responsible = _responsibleService.CreateResponsible(responsible);

                var childAssited = new ChildAssisted(name, birthDate.ToUniversalTime(), foodSelectivity, aversions, preferences, medicalRecord, photo, responsible);
                childAssited = _childAssistedService.CreateChild(childAssited);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
            
        }

        [HttpGet("list")]
        public IActionResult GetAll()
        {
            var childAssisteds = _childAssistedService.ListAllUser();
            return Ok(new { message = "List retrieved successfully", childAssisteds });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteChild(Guid id)
        {
            try
            {
                _childAssistedService.DeleteChildById(id);
                return Ok("Child deleted successfully.");
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

        [HttpGet("filterByData")]
        public IActionResult FilterByData([FromQuery] string data)
        {
            try
            {
                var filteredUsers = _childAssistedService.FilterByData(data);
                return Ok(filteredUsers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while filtering user information: {ex.Message}");
            }
        }

    }
    
    
}
