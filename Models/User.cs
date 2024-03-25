using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Enum;
namespace WebApplication1
{
    [Table("users")]
    public class User
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Column("email")]
        [StringLength(100)]
        public string? Email { get; private set; }

        [Column("password")]
        [StringLength(100)]
        public string? Password { get; set; }

        [Column("user_type")]
        [StringLength(20)]
        public UserType UserType { get; set; }
        public User()
        {

        }
        public User(string email, string password, UserType userType)
        {
            Email = email;
            Password = password;
            UserType = userType;
        }
        public User(string email, string password)
        {
            Email = email;
            Password = password;
            
        }

    }
}
