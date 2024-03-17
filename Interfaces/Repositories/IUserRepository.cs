using WebApplication1;
using WebApplication1.Repositories;

namespace Interfaces.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User Add(User user);
        User GetByEmail(string email);

    }
}
