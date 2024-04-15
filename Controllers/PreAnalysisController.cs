using Backend_TeaTech.DTO.PreAnalysiss;
using Backend_TeaTech.Interfaces.Services;
using Backend_TeaTech.Models;
using Backend_TeaTech.Services;
using Microsoft.AspNetCore.Mvc;

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
        [HttpPut("update/{idPreAnalysis}")]
        public IActionResult Update(Guid idPreAnalysis, [FromBody] PreAnalysisRequestDTO req)
        {
            try
            {
                _preAnalysisService.UpdatePreAnalysis(idPreAnalysis, req);
                return Ok();
            }catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }  
        }
        [HttpGet("list")]
        public IActionResult ListAllPreAnalysis()
        {
            var preAnalyses = _preAnalysisService.ListAllPreAnalysis();
            return Ok(new { message = "List retrieved successfully", preAnalyses });
        }

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
    }
}
