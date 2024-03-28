using Interfaces.Repositories;
using WebApplication1.Interfaces.Services;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Services
{
    public class ResponsibleService : IResponsibleService
    {
        private readonly IResponsibleRepository _responsibleRepository;
        public ResponsibleService(IResponsibleRepository responsibleRepository) {
            _responsibleRepository = responsibleRepository;
        }

        public Responsible CreateResponsible(Responsible responsible)
        {
            var responsibleAdd = _responsibleRepository.Add(responsible);

            return responsibleAdd;
        }

        public void DeleteResponsibleById(Guid id)
        {
            var existingResponsible = _responsibleRepository.GetById(id);
            if (existingResponsible != null)
            {
                _responsibleRepository.DeleteById(id);
            }
            else
            {
                throw new ArgumentException("Responsible not found.");
            }
        }

        public List<ResponsibleDTO> ListAllResponsible()
        {
            var responsibles = _responsibleRepository.GetAll();

            List<ResponsibleDTO> responsibleDTO = responsibles.Select(responsible => new ResponsibleDTO
            {
                Id = responsible.Id,
                NameResponsibleOne = responsible.NameResponsibleOne,
                ResponsibleKinshipOne = responsible.ResponsibleKinshipOne,
                ResponsibleCpfOne = responsible.ResponsibleCpfOne,
                ContactOne = responsible.ContactOne,
                NameResponsibleTwo = responsible.NameResponsibleTwo,
                ResponsibleKinshipTwo = responsible.ResponsibleKinshipTwo,
                ResponsibleCpfTwo = responsible.ResponsibleCpfTwo,
                ContactTwo = responsible.ContactTwo,
                User = responsible.User,
                
            }).ToList();

            return responsibleDTO;
        }


    }
}
