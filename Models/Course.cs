using System.ComponentModel.DataAnnotations;

namespace KUSYS_Demo.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        [Required]
        public string CourseCode { get; set; } = string.Empty;
        [Required]
        public string CourseName { get; set; } = string.Empty;

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
