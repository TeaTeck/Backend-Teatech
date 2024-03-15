using WebApplication1.Infrastructure;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class ResponsibleRepository : IResponsible
    {
        private readonly ConnectionContextResponsible _connectionContextResponsible;

        public ResponsibleRepository(ConnectionContextResponsible context)
        {
            _connectionContextResponsible = context;
        }
        public ResponsibleDTO Add(Responsible responsible)
        {
            var responsibleAdd = _connectionContextResponsible.Responsibles.Add(responsible).Entity;
            _connectionContextResponsible.SaveChanges();

            ResponsibleDTO responsibleDTO = new ResponsibleDTO
            {
                Id = responsibleAdd.Id,
                NameNameResponsibleOne = responsibleAdd.NameResponsibleOne,
                ResponsibleKinshipOne = responsibleAdd.ResponsibleKinshipOne,
                ResponsibleCpfOne = responsibleAdd.ResponsibleCpfOne,
                NameResponsibleTwo = responsibleAdd.NameResponsibleTwo,
                ResponsibleCpfTwo = responsibleAdd.ResponsibleCpfTwo,
                ResponsibleKinshipTwo = responsibleAdd.ResponsibleCpfTwo,
                User = responsibleAdd.User,
            };

            return responsibleDTO;
        }

        public List<Responsible> GetAll()
        {
            return _connectionContextResponsible.Responsibles.ToList();
        }
    }
}
