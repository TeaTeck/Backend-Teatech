namespace Backend_TeaTech.DTO.Assessments
{
    public class AssessmentRequestDTO
    {
        public string? ChildAssessment { get; set; }
        public AssessmentRequestDTO() { }
        public AssessmentRequestDTO(string? childAssessment)
        {
            ChildAssessment = childAssessment;
        }
    }
}
