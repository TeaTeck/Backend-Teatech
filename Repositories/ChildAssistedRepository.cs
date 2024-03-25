using Interfaces.Repositories;
using WebApplication1.Infrastructure;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class ChildAssistedRepository : IChildAssistedRepository
    {
        private readonly ConnectionContext _connectionContext;

        public ChildAssistedRepository(ConnectionContext context)
        {
            _connectionContext = context;
        }
        public ChildAssisted Add(ChildAssisted childAssisted)
        {

            var childAdd =  _connectionContext.ChildAssisteds.Add(childAssisted).Entity;
            _connectionContext.SaveChanges();
            return childAdd;
            
        }
        public List<ChildAssisted> GetAll()
        {
            return _connectionContext.ChildAssisteds.ToList();
        }
    }
}
