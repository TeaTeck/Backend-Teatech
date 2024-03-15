using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    [Table("child_assisteds")]
    public class ChildAssisted
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Column("name")]
        [StringLength(100)]
        public string Name { get; private set; }

        [Column("birth_date")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; private set; }

        [Column("food_selectiity")]
        [StringLength(100)]
        public string FoodSelectivity { get; private set; }

        [Column("aversions")]
        [StringLength(100)]
        public string Aversions { get; private set; }

        [Column("preferences")]
        [StringLength(100)]
        public string Preferences { get; private set; }

        [Column("medical_record")]
        [StringLength(100)]
        public string MedicalRecord { get; private set; }

        [ForeignKey("fk_responsible_id")]
        public Responsible? Responsible { get; set; }

        [Column("photo")]
        [StringLength(100)]
        public string? Photo { get; private set; }

        public ChildAssisted(string name, DateTime birthDate, string foodSelectivity, string aversions, string preferences, string medicalRecord, string photo)
        {
            this.Name = name;
            this.BirthDate = birthDate;
            this.FoodSelectivity = foodSelectivity;
            this.Aversions = aversions;
            this.Preferences = preferences;
            this.MedicalRecord = medicalRecord;
            this.Photo = photo;
        }
    }
}
