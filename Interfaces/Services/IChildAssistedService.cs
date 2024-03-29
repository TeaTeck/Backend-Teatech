using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Interfaces.Services
{
    public interface IChildAssistedService
    {
        ChildAssisted CreateChild(ChildAssisted childAssisted);
        void DeleteChildById(Guid id);
        List<ChildAssistedDTO> FilterByData(string data);
        ChildAssisted GetChildById(Guid id);

    }
}
