using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Interfaces.Services
{
    public interface IUserService
    {
        User CreateUserResponsible(User user);

        UserDTO CreateUserEmployee(User user);

        string Login(string email, string password);

        List<UserDTO> ListAllUser();
    }
}

