namespace Backend_TeaTech.DTO.Assessments
{
    public class AssessmentDTO
    {
        public Guid Id { get; set; }
        public string? ChildAssessment { get; set; }
        public AssessmentDTO() {}
        public AssessmentDTO(Guid id, string? childAssessment)
        {
            Id = id;
            ChildAssessment = childAssessment;
        }
    }
}
