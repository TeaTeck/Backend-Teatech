using Interfaces.Repositories;
using WebApplication1.Interfaces.Services;
using WebApplication1.lib;
using WebApplication1.Repositories;

namespace WebApplication1.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtService _jwtService;
        public UserService(IUserRepository userRepository, JwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }


        public User CreateUserResponsible(User user)
        {
            var existingUser = _userRepository.GetByEmail(user.Email);

            if (existingUser != null)
            {
                throw new Exception("User already exists");
            }

            string hashedPassword = PasswordHasher.HashPassword(user.Password);

            user.Password = hashedPassword;

            user.UserType = Enum.UserType.Responsible;

            var createdUser = _userRepository.Add(user);

            return createdUser;
        }

        public UserDTO CreateUserEmployee(User user)
        {
            var existingUser = _userRepository.GetByEmail(user.Email);

            if (existingUser != null)
            {
                throw new Exception("User already exists");
            }

            string hashedPassword = PasswordHasher.HashPassword(user.Password);

            user.Password = hashedPassword;

            user.UserType = Enum.UserType.Employee;

            var createdUser = _userRepository.Add(user);

            UserDTO userDTO = new UserDTO
            {
                Id = createdUser.Id,
                Email = createdUser.Email,
                UserType = createdUser.UserType
            };

            return userDTO;
        }
        public List<UserDTO> ListAllUser()
        {
            var users = _userRepository.GetAll();

            List<UserDTO> userDTO = users.Select(user => new UserDTO
            {
                Id = user.Id,
                Email = user.Email,
                UserType = user.UserType
            }).ToList();

            return userDTO;
        }
        public string? Login(string email, string password)
        {
            var user = _userRepository.GetByEmail(email);

            if (user == null)
            {
                return null;
            }

            string hashedPassword = PasswordHasher.HashPassword(password);

            if (user.Password == hashedPassword)
            {
                string token = _jwtService.GenerateToken(user.Id.ToString(), user.Email);
                return token;
            }

            return null; 
        }


    }
}
