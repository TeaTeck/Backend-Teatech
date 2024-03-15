using WebApplication1.Enum;

namespace WebApplication1.Repositories
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public UserType UserType { get; set; }
        public UserDTO()
        {
        }
        public UserDTO(Guid id, string email, UserType userType)
        {
            Id = id;
            Email = email;
            UserType = userType;
        }

    }
}
