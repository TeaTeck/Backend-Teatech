using Interfaces.Repositories;
using WebApplication1.Infrastructure;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ConnectionContext _connectionContextUser;

        public UserRepository(ConnectionContext context)
        {
            _connectionContextUser = context;
        }
        public User Add(User user)
        {
            var userAdd = _connectionContextUser.Users.Add(user).Entity;
            _connectionContextUser.SaveChanges();
            return userAdd;

        }
        public List<User> GetAll()
        {
            return _connectionContextUser.Users.ToList();
        }

        public User GetByEmail(string email)
        {
            return _connectionContextUser.Users.FirstOrDefault(user => user.Email == email);
        }
    }
}
