using Interfaces.Repositories;
using Microsoft.AspNetCore.Connections;
using WebApplication1.Infrastructure;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ConnectionContextUser _connectionContextUser;

        public UserRepository(ConnectionContextUser context)
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
