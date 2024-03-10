using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    [Table("child_assisted")]
    public class ChildAssisted
    {
        [Key]
        public int Id { get; private set; }

        [StringLength(50)]
        public string Name { get; private set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; private set; }

        [StringLength(100)]
        public string FoodSelectivity { get; private set; }

        [StringLength(100)]
        public string Aversions { get; private set; }

        [StringLength(100)]
        public string Preferences { get; private set; }

        [StringLength(100)]
        public string MedicalRecord { get; private set; }

        [ForeignKey("Responsible_id")]

        public int Responsible_id { get; private set; }

        [StringLength(100)]
        public string Photo { get; private set; }

        public ChildAssisted(string name, DateTime birthDate, string foodSelectivity, string aversions, string preferences, string medicalRecord, int responsible_id, string photo)
        {
            this.Name = name;
            this.BirthDate = birthDate;
            this.FoodSelectivity = foodSelectivity;
            this.Aversions = aversions;
            this.Preferences = preferences;
            this.MedicalRecord = medicalRecord;
            this.Responsible_id = responsible_id;
            this.Photo = photo;
        }
    }
}
