using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Interfaces
{
    public interface IChildAssisted
    {
        ChildAssistedDTO Add(ChildAssisted childAssisted);

        List<ChildAssisted> GetAll();
    }
}
