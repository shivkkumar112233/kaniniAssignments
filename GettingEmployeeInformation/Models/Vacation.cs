using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GettingEmployeeInformation.Models
{
    public class Vacation
    {
        [Key]
        public int VacationId { get; set; }

     
        [ForeignKey("EmployeeDetails")]
        [Required]
        public int EmpId { get; set; }
    }
}
