
namespace Backend_TeaTech.DTO.ChildAssisted
{
    public class ChildAssistedDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }

        public ChildAssistedDTO()
        {
        }
        public ChildAssistedDTO(Guid id, string name, string email, string contact)
        {
            Id = id;
            Name = name;
            Email = email;
            Contact = contact;


        }
    }
}
