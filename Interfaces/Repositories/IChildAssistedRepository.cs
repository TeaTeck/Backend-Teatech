using WebApplication1.Models;
using WebApplication1.Repositories;

namespace Interfaces.Repositories
{
    public interface IChildAssistedRepository
    {
        ChildAssisted Add(ChildAssisted childAssisted);
        List<ChildAssisted> GetAll();
        void DeleteById(Guid id);
        ChildAssisted? GetById(Guid id);
        ChildAssisted Update(ChildAssisted childAssisted);
        List<ChildAssisted> GetByData(string data);
    }
}
