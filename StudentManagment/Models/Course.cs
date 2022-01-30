using System.ComponentModel.DataAnnotations;

namespace StudentManagment.Models
{
    public class Course
    {

        [Key]
        public int CourseId { get; set; }
        public int DeprtmentId { get; set; }
        [Display(Name ="Course Name")]
        public string? CourseName { get; set; }
        [Display(Name = "Course Code")]
        public string? CourseCode { get; set; }

        public Department? Department { get; set; }
        public ICollection<Enrollment>? Enrollments { get; set; }
    }
}
