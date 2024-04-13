using Backend_TeaTech.DTO.Users;
using Backend_TeaTech.Enum;

namespace Backend_TeaTech.DTO.Employee
{
    public class EmployeeDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public OccupationType OccupationType { get; set;}
        public UserDTO? User { get; set; }
        public EmployeeDTO() { }    
        public EmployeeDTO(string name, OccupationType occupationType, UserDTO? user)
        {
            Name = name;
            OccupationType = occupationType;
            User = user;
        }
    }
}
