using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudentManagment.Models
{
    public class Enrollment
    {
        [Key]
        public int EnrollmentId { get; set; }
        [ForeignKey("Student")] 
        public int StudentId { get; set;}
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public DateTime EnrollmentDate  { get; set; }

        public Student? Student { get; set; }
        public Course? Course { get; set; }
    }
}
