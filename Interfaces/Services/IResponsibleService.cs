using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Interfaces.Services
{
    public interface IResponsibleService
    {
        Responsible CreateResponsible(Responsible responsible);

        List<ResponsibleDTO> ListAllResponsible();
    }
}
