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

        public ResponsibleDTO Add(Responsible responsible)
        {
            var responsibleAdd = _responsibleRepository.Add(responsible);

            ResponsibleDTO responsibleDTO = new ResponsibleDTO
            {
                Id = responsibleAdd.Id,
                NameResponsibleOne = responsibleAdd.NameResponsibleOne,
                ResponsibleKinshipOne = responsibleAdd.ResponsibleKinshipOne,
                ResponsibleCpfOne = responsibleAdd.ResponsibleCpfOne,
                NameResponsibleTwo = responsibleAdd.NameResponsibleTwo,
                ResponsibleCpfTwo = responsibleAdd.ResponsibleCpfTwo,
                ResponsibleKinshipTwo = responsibleAdd.ResponsibleCpfTwo,
                User = responsibleAdd.User,
            };

            return responsibleDTO;
        }

        
    }
}
