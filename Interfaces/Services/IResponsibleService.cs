using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Interfaces.Services
{
    public interface IResponsibleService
    {
        ResponsibleDTO Add(Responsible responsible);
    }
}
