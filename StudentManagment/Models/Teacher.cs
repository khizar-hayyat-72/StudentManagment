using System.ComponentModel.DataAnnotations;

namespace StudentManagment.Models
{
    public class Teacher
    {
        [Key]
        [Display(Name ="Teacher Id")]
        public int TeacherId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name ="Teacher Name")]
        public string? TeacherName { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string? Contact { get; set; }
        
        [Display(Name = "Department")]
        public ICollection<Department>? Departments { get; set; }
       


    }
}
