using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IChildAssisted
    {
        void Add(ChildAssisted childAssisted);

        List<ChildAssisted> GetAll();
    }
}
