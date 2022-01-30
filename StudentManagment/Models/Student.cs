using System.ComponentModel.DataAnnotations;

namespace StudentManagment.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        [Display(Name ="Student Name")]
        public string? StudentName { get; set; }
        [Required]
        public string? Gender { get; set; }
        public string? Contact { get; set; }
        [Required]
        [Display(Name ="Date Of Birth")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public int StudentAge { get; set; }

        public ICollection<Enrollment>? Enrollments { get; set; }
    }
}
