using Microsoft.AspNetCore.Mvc;
using Backend_TeaTech.DTO.ChildAssisteds;
using Backend_TeaTech.Interfaces.Services;
using Backend_TeaTech.Models;

namespace Backend_TeaTech.Controllers
{
    [ApiController]
    [Route("api/childAssisted")]
    public class ChildAssistedController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IChildAssistedService _childAssistedService;
        private readonly IResponsibleService _responsibleService;
        private readonly IPreAnalysisService _preAnalysisService;

        public ChildAssistedController(IUserService userService, IChildAssistedService childAssistedService, IResponsibleService responsibleService, IPreAnalysisService preAnalysisService)
        {
            _userService = userService;
            _childAssistedService = childAssistedService;
            _responsibleService = responsibleService;
            _preAnalysisService = preAnalysisService;
            
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] ChildAssistedRequestDTO req)
        {
            //Criar usuario
            //User userResponsible = _userService.CreateUserResponsible("Passar dados")
            //Criar responsavel
            //Responsible responsible = _responsibleService.CreateResponsible("Passar dados do responsavel e o userResponsavel")
            //Criar criança

            try
            {
                User userResponsible = new User(req.Email, req.ResponsibleCpfOne);
                userResponsible = _userService.CreateUserResponsible(userResponsible);

                Responsible responsible = new Responsible(req.NameResponsibleOne, req.ResponsibleCpfOne, req.ResponsibleKinshipOne, req.NameResponsibleTwo, req.ResponsibleKinshipTwo, req.ResponsibleCpfTwo, req.ContactOne, req.ContactTwo, userResponsible);
                responsible = _responsibleService.CreateResponsible(responsible);

                ChildAssisted childAssited = new ChildAssisted(req.Name, req.BirthDate.ToUniversalTime(), req.FoodSelectivity, req.Aversions, req.Preferences, req.MedicalRecord, req.Photo, responsible);
                childAssited = _childAssistedService.CreateChild(childAssited);

                PreAnalysis preAnalysis = new PreAnalysis(childAssited);
                preAnalysis = _preAnalysisService.CreatePreAnalysis(preAnalysis);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
            
        }

        [HttpGet("filterByData")]
        public IActionResult FilterByData(string data = "")
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

        [HttpGet("{id}")]
        public IActionResult GetChildById(Guid id)
        {
            try
            {
                var child = _childAssistedService.GetChildById(id);
                if (child == null)
                {
                    return NotFound("ChildAssisted not found.");
                }
                return Ok(child);
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
