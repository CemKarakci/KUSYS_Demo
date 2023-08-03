using System.ComponentModel.DataAnnotations;

namespace KUSYS_Demo.Models
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        [Required]
        public int CourseId { get; set; }
        [Required]
        public int StudentId { get; set; }
        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}
