using Backend_TeaTech.DTO.Users;
using Backend_TeaTech.Models;

namespace Backend_TeaTech.DTO.Responsibles
{
    public class ResponsibleDTO
    {
        public Guid? Id { get; set; }
        public string? NameResponsibleOne { get; set; }
        public string? ResponsibleKinshipOne { get; set; }
        public string? ResponsibleCpfOne { get; set; }
        public string? NameResponsibleTwo { get; set; }
        public string? ResponsibleKinshipTwo { get; set; }
        public string? ResponsibleCpfTwo { get; set; }
        public string? ContactOne { get; set; }
        public string? ContactTwo { get; set; }

        public UserDTO? User { get; set; }

        public ResponsibleDTO()
        {
        }
        public ResponsibleDTO(Responsible responsible)
        {
            Id = responsible.Id;
            NameResponsibleOne = responsible.NameResponsibleOne;
            ResponsibleKinshipOne = responsible.ResponsibleKinshipOne;
            ResponsibleCpfOne = responsible.ResponsibleCpfOne;
            NameResponsibleTwo = responsible.NameResponsibleTwo;
            ResponsibleKinshipTwo = responsible.ResponsibleKinshipTwo;
            ResponsibleCpfTwo = responsible.ResponsibleCpfTwo;
            ContactOne = responsible.ContactOne;
            ContactTwo = responsible.ContactTwo;
            User = responsible.User != null ? new UserDTO(responsible.User) : null;
        }
    }
}
