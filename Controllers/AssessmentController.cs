using Backend_TeaTech.DTO.Assessments;
using Backend_TeaTech.DTO.PreAnalysiss;
using Backend_TeaTech.Interfaces.Services;
using Backend_TeaTech.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;

namespace Backend_TeaTech.Controllers
{
    [ApiController]
    [Route("api/assessment")]
    public class AssessmentController : Controller
    {
        private readonly IAssessmentService _assessmentService;
        public AssessmentController(IAssessmentService assessmentService)
        {
            _assessmentService = assessmentService;
        }

        /// <summary>
        /// Update a Assessment.
        /// </summary>
        /// <remarks>
        /// Updates a Assessment with the provided data.
        /// </remarks>
        [Authorize(Roles = "Employee:Coordinator")]
        [HttpPut("update/{idAssessment}")]
        [SwaggerResponse(200, "Success")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(401, "Unauthorized")]
        [SwaggerResponse(500, "Internal Server Error")]
        public IActionResult Update(Guid idAssessment, [FromBody] AssessmentRequestDTO req)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            try
            {
                _assessmentService.UpdateAssessment(idAssessment, req, new Guid(userId));
                return Ok();
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized("You are not authorized to perform this action.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating the pre-analysis: {ex.Message}");
            }
        }

        /// <summary>
        /// Get an assessment by ID.
        /// </summary>
        /// <remarks>
        /// Retrieves an assessment by its ID.
        /// </remarks>
        [HttpGet("{id}")]
        [SwaggerResponse(200, "Success")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "Not Found")]
        [SwaggerResponse(500, "Internal Server Error")]
        public IActionResult GetAssessmentByChildId(Guid id)
        {
            try
            {
                var assessment = _assessmentService.GetAssessmentById(id);
                if (assessment == null)
                {
                    return NotFound("Assessment not found.");
                }
                return Ok(assessment);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
            }
        }
    }
}
