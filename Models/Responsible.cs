using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    [Table("responsibles")]
    public class Responsible
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Column("name_responsible_one")]
        [StringLength(100)]
        public string NameResponsibleOne { get; private set; }

        [Column("responsible_kinship_one")]
        [StringLength(50)]
        public string ResponsibleKinshipOne { get; private set; }

        [Column("responsible_cpf_one")]
        [StringLength(20)]
        public string ResponsibleCpfOne { get; private set; }

        [Column("name_responsible_two")]
        [StringLength(100)]
        public string NameResponsibleTwo { get; private set; }

        [Column("responsible_kinship_two")]
        [StringLength(50)]
        public string ResponsibleKinshipTwo { get; private set; }

        [Column("resposible_cpf_two")]
        [StringLength(20)]
        public string ResponsibleCpfTwo { get; private set; }

        [ForeignKey("fk_user_id")]
        public User? User { get; set; }

        public Responsible(string nameResponsibleOne, string responsibleKinshipOne, string responsibleCpfOne, string nameResponsibleTwo, string responsibleKinshipTwo, string responsibleCpfTwo)
        {
            this.NameResponsibleOne = nameResponsibleOne;
            this.ResponsibleKinshipOne = responsibleKinshipOne;
            this.ResponsibleCpfOne = responsibleCpfOne;
            this.NameResponsibleTwo = nameResponsibleTwo;
            this.ResponsibleKinshipTwo = responsibleKinshipTwo;
            this.ResponsibleCpfTwo = responsibleCpfTwo;
        }
    }
}
