using Backend_TeaTech.Enum;
using Backend_TeaTech.Models;
using System.Xml.Linq;

namespace Backend_TeaTech.DTO.ChildAssisteds
{
    public class ChildAssistedDTO
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Contact { get; set; }
        public string? Photo { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? NameResponsible { get; set; }
        public string? CpfResponsible { get; set; }
        public Guid? PreAnalysisId { get; set; }
        public StatusCode? PreAnalysisStatusCode { get; set; }

        public ChildAssistedDTO()
        {
        }

        public ChildAssistedDTO(ChildAssisted childAssisted, PreAnalysis? preAnalysis, Responsible responsible)
        {
            Id = childAssisted?.Id;
            Name = childAssisted?.Name;
            Email = childAssisted?.Responsible?.User?.Email;
            Contact = childAssisted?.Responsible?.ContactOne;
            Photo = childAssisted?.Photo;
            BirthDate = childAssisted?.BirthDate;
            NameResponsible = responsible?.NameResponsibleOne;
            CpfResponsible = responsible?.ResponsibleCpfOne;
            PreAnalysisId = preAnalysis?.Id;
            PreAnalysisStatusCode = preAnalysis?.StatusCode;
        }

        public ChildAssistedDTO(Guid? id, string? name)
        {
            Id = id;
            Name = name;
        }
    }
}
