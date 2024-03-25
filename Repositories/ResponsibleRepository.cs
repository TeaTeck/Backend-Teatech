using Interfaces.Repositories;
using WebApplication1.Infrastructure;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class ResponsibleRepository : IResponsibleRepository
    {
        private readonly ConnectionContext _connectionContext;

        public ResponsibleRepository(ConnectionContext context)
        {
            _connectionContext = context;
        }
        public Responsible Add(Responsible responsible)
        {
            var responsibleAdd = _connectionContext.Responsibles.Add(responsible).Entity;
            _connectionContext.SaveChanges();
            return responsibleAdd;
        }

        public List<Responsible> GetAll()
        {
            return _connectionContext.Responsibles.ToList();
        }
    }
}
