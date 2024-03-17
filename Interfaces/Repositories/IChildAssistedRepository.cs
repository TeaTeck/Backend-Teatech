using WebApplication1.Models;
using WebApplication1.Repositories;

namespace Interfaces.Repositories
{
    public interface IChildAssistedRepository
    {
        ChildAssisted Add(ChildAssisted childAssisted);

        List<ChildAssisted> GetAll();
    }
}
