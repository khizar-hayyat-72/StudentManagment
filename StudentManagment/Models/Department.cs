using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace StudentManagment.Models
{
    public class Department
    {
        [Key]
        
        public int DepartmentId { get; set; }
        [Required]
        [Display(Name = "Department")]
        public string? DeprtmentName { get; set; }
     
        [ForeignKey("Teacher")]
        [Display(Name = "Teacher Id")]
        public int TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
        
        public ICollection<Course>? Courses { get; set; }

    }
}
