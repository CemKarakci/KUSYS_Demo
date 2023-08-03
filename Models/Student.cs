using System.ComponentModel.DataAnnotations;

namespace KUSYS_Demo.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [DataType(DataType.Date)]
        public DateTime BirthDay { get; set; }

        public ICollection<Enrollment>? Enrollments { get; set; }

    }
}
