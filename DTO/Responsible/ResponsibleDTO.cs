using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class ResponsibleDTO
    {
        public Guid Id { get; set; }
        public string NameResponsibleOne { get; set; }
        public string ResponsibleKinshipOne { get; set; }
        public string ResponsibleCpfOne { get; set; }
        public string NameResponsibleTwo { get; set; }
        public string ResponsibleKinshipTwo { get; set; }
        public string ResponsibleCpfTwo { get; set; }
        public User? User { get; set; }

        public ResponsibleDTO()
        {
        }
        public ResponsibleDTO(Guid id, string nameNameResponsibleOne, string responsibleKinshipOne, string responsibleCpfOne, string nameResponsibleTwo, string responsibleKinshipTwo, string responsibleCpfTwo, User? user)
        {
            Id = id;
            NameResponsibleOne = nameNameResponsibleOne;
            ResponsibleKinshipOne = responsibleKinshipOne;
            ResponsibleCpfOne = responsibleCpfOne;
            NameResponsibleTwo = nameResponsibleTwo;
            ResponsibleKinshipTwo = responsibleKinshipTwo;
            ResponsibleCpfTwo = responsibleCpfTwo;
            User = user;
        }
    }
}
