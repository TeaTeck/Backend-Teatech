using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class ChildAssistedDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string FoodSelectivity { get; set; }
        public string Aversions { get; set; }
        public string Preferences { get; set; }
        public string MedicalRecord { get; set; }
        public Responsible? Responsible { get; set; }
        public string? Photo { get; set; }

        public ChildAssistedDTO()
        {
        }
        public ChildAssistedDTO(Guid id, string name, DateTime birthDate, string foodSelectivity, string aversions, string preferences, string medicalRecord, Responsible? responsible, string? photo)
        {
            Id = id;
            Name = name;
            BirthDate = birthDate;
            FoodSelectivity = foodSelectivity;
            Aversions = aversions;
            Preferences = preferences;
            MedicalRecord = medicalRecord;
            Responsible = responsible;
            Photo = photo;
        }
    }
}
