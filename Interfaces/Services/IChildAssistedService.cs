using Backend_TeaTech.DTO.ChildAssisteds;
using Backend_TeaTech.Models;

namespace Backend_TeaTech.Interfaces.Services
{
    public interface IChildAssistedService
    {
        ChildAssisted CreateChild(ChildAssisted childAssisted);
        void DeleteChildById(Guid id);
        List<ChildAssistedDTO> FilterByData(string data);
        ChildAssisted GetChildById(Guid id);

    }
}
