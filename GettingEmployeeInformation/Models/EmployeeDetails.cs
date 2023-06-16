using System.ComponentModel.DataAnnotations;

namespace GettingEmployeeInformation.Models
{
    public class EmployeeDetails
    {
        [Key]
        [Required]
        public int EmpId{ get; set; }
        [MinLength(4)]
        public string EmplName { get; set; }

        [Required]
        [RegularExpression(@"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$", ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }
        

        public int LocId { get; set; }
       

        public int PraticeId { get; set; }  
       

        public int BillableId { get; set; }


        public int ResourceId { get; set; }
        [MinLength(8)]
        public string ?ActiveStatus { get; set; }
       
    }
}
