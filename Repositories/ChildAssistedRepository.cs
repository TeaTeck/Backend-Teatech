using WebApplication1.Infrastructure;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class ChildAssistedRepository : IChildAssisted
    {
        private readonly ConnectionContext _connectionContext;

        public ChildAssistedRepository(ConnectionContext context)
        {
            _connectionContext = context;
        }
        public void Add(ChildAssisted childAssisted)
        {
            _connectionContext.ChildAssisteds.Add(childAssisted);
            _connectionContext.SaveChanges();
        }

        public List<ChildAssisted> GetAll()
        {
            return _connectionContext.ChildAssisteds.ToList();
        }
    }
}
