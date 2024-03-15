using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Models
{
    public interface IResponsible
    {
        ResponsibleDTO Add(Responsible responsible);

        List<Responsible> GetAll();
    }
}
