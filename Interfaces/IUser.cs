using WebApplication1.Repositories;

namespace WebApplication1.Interfaces
{
    public interface IUser
    {
        List<UserDTO> GetAll();
        UserDTO Add(User user);
    }
}
