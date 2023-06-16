using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GettingEmployeeInformation.Models
{
    public class ExperienceLevel
    {
        [Key]
        public int EmpId { get; set; }
        [ForeignKey("EmployeeDetails")]
        [Column("EmpId")]

        [Required]
        public string? EmployeesLevel { get; set; }

        [Required]
        public int SkillScore { get; set; }
       
    }
}
