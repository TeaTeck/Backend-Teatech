using Backend_TeaTech.Enum;
using Backend_TeaTech.Models;
using System.Xml.Linq;

namespace Backend_TeaTech.DTO.ChildAssisteds
{
    public class ChildAssistedDTO
    {
            public Guid? Id { get; set; }
            public string? Name { get; set; }
            public string? MedicalRecord { get; set; }
            public string? Photo { get; set; }
            public string? Aversions { get; set; }
            public string? Preferences { get; set; }
            public DateTime? BirthDate { get; set; }
            public string? FoodSelectivity { get; set; }
            public string? Email { get; set; }
            public string? ContactOne { get; set; }
            public string? ContactTwo { get; set; }
            public Guid ResponsibleId { get; set; }
            public string? ResponsibleKinshipOne { get; set; }
            public string? ResponsibleKinshipTwo { get; set; }
            public string? NameResponsibleOne   { get; set; }
            public string? NameResponsibleTwo { get; set; }
            public string? CpfResponsibleOne { get; set; }
            public string? CpfResponsibleTwo { get; set; }
            public string? ProposedActivity { get; set; }
            public string? IdentifiedSkills { get; set; }
            public string? Protocol { get; set; }
            public string? FinalDuration { get; set; }
            public string? ChildAssessment { get; set; }
            public Guid UserId { get; set; }
            public UserType UserType { get; set; }
            public Guid? AssessmentId { get; set; }
            public Guid? PreAnalysisId { get; set; }
            public StatusCode? PreAnalysisStatusCode { get; set; }

        public ChildAssistedDTO()
        {
        }

        public ChildAssistedDTO(ChildAssisted childAssisted, PreAnalysis? preAnalysis, Responsible? responsible, Assessment? assessment, User user)
        {
            Id = childAssisted?.Id;
            Name = childAssisted?.Name;
            Photo = childAssisted?.Photo;
            BirthDate = childAssisted?.BirthDate;
            Aversions = childAssisted?.Aversions;
            Preferences = childAssisted?.Preferences;
            FoodSelectivity = childAssisted?.FoodSelectivity;
            MedicalRecord = childAssisted?.MedicalRecord;

            ResponsibleId = responsible.Id;
            NameResponsibleOne = responsible?.NameResponsibleOne;
            CpfResponsibleOne = responsible?.ResponsibleCpfOne;
            NameResponsibleTwo = responsible?.NameResponsibleTwo;
            CpfResponsibleTwo = responsible?.ResponsibleCpfTwo;
            ContactOne = responsible?.ContactOne;
            ContactTwo = responsible?.ContactTwo;
            ResponsibleKinshipOne = responsible?.ResponsibleKinshipOne;
            ResponsibleKinshipTwo = responsible?.ResponsibleKinshipTwo;

            UserId = user.Id;
            Email = user.Email;
            UserType = user.UserType;

            PreAnalysisId = preAnalysis?.Id;
            PreAnalysisStatusCode = preAnalysis?.StatusCode;
            FinalDuration = preAnalysis?.FinalDuration;
            Protocol = preAnalysis?.Protocol;
            IdentifiedSkills = preAnalysis?.IdentifiedSkills;
            ProposedActivity = preAnalysis?.ProposedActivity;
        
            AssessmentId = assessment?.Id;
            ChildAssessment = assessment?.ChildAssessment;
        }

        public ChildAssistedDTO(Guid? id, string? name)
        {
            Id = id;
            Name = name;
        }
    }
}
