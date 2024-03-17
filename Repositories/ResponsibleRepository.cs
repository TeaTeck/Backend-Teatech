using Interfaces.Repositories;
using WebApplication1.Infrastructure;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class ResponsibleRepository : IResponsibleRepository
    {
        private readonly ConnectionContextResponsible _connectionContextResponsible;

        public ResponsibleRepository(ConnectionContextResponsible context)
        {
            _connectionContextResponsible = context;
        }
        public Responsible Add(Responsible responsible)
        {
            var responsibleAdd = _connectionContextResponsible.Responsibles.Add(responsible).Entity;
            _connectionContextResponsible.SaveChanges();
            return responsibleAdd;
        }

        public List<Responsible> GetAll()
        {
            return _connectionContextResponsible.Responsibles.ToList();
        }
    }
}
