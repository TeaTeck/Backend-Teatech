using Backend_TeaTech.DTO.PreAnalysiss;
using Backend_TeaTech.Interfaces.Services;
using Backend_TeaTech.Models;
using Backend_TeaTech.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Backend_TeaTech.Controllers
{
    
    [ApiController]
    [Route("api/preAnalysis")]
    public class PreAnalysisController : Controller
    {
        private readonly IPreAnalysisService _preAnalysisService;
        public PreAnalysisController(IPreAnalysisService preAnalysisService)
        {
            _preAnalysisService = preAnalysisService;
        }
        [Authorize(Roles = "Employee:Coordinator")]
        [HttpPut("update/{idPreAnalysis}")]
        public IActionResult Update(Guid idPreAnalysis, [FromBody] PreAnalysisRequestDTO req)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            try
            {
                _preAnalysisService.UpdatePreAnalysis(idPreAnalysis, req, new Guid(userId));
                return Ok();
            }catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }  
        }
        [Authorize(Policy = "CoordinatorOrApplicator")]
        [HttpGet("list")]
        public IActionResult ListAllPreAnalysis()
        {
            
            var preAnalyses = _preAnalysisService.ListAllPreAnalysis();
            return Ok(new { message = "List retrieved successfully", preAnalyses });
        }

        [Authorize(Roles = "Employee:Coordinator")]
        [HttpDelete("{id}")]
        public IActionResult DeletePreAnalysis(Guid id)
        {
            try
            {
                _preAnalysisService.DeletePreAnalysisById(id);
                return Ok("Pre Analysis deleted successfully.");
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
        [Authorize(Policy = "CoordinatorOrApplicator")]
        [HttpGet("{id}")]
        public IActionResult GetPreAnalysisById(Guid id)
        {
            try
            {
                var user = _preAnalysisService.GetPreAnalysisById(id);
                if (user == null)
                {
                    return NotFound("Pre-Analysis not found.");
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
