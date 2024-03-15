using Microsoft.AspNetCore.Connections;
using WebApplication1.Infrastructure;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class UserRepository : IUser
    {
        private readonly ConnectionContextUser _connectionContextUser;

        public UserRepository(ConnectionContextUser context)
        {
            _connectionContextUser = context;
        }
        public UserDTO Add(User user)
        {
            var userAdd = _connectionContextUser.Users.Add(user).Entity;
            _connectionContextUser.SaveChanges();

            UserDTO userDTO = new UserDTO
            {
                Id = user.Id,
                Email = user.Email,
                UserType = user.UserType
            };

            return userDTO;
        }
        public List<UserDTO> GetAll()
        {
            var listUser = _connectionContextUser.Users.ToList();

            var listUserDTO = listUser.Select(user => new UserDTO
            {
                Id = user.Id,
                Email = user.Email,
                UserType = user.UserType
                
            }).ToList();

            return listUserDTO;
        }
    }
}
