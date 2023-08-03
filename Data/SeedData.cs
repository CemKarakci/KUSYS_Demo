using KUSYS_Demo.Models;
using System.Diagnostics;

namespace KUSYS_Demo.Data
{
    public static class SeedData
    {
        public static void Initialize(KUSYS_DemoContext context)
        {
            // Look for any students.
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }

            var students = new Student[]
            {
                new Student{FirstName="Ali",LastName="Koş",BirthDay=DateTime.Parse("2001-07-05")},
                new Student{FirstName="Veli",LastName="Demir",BirthDay=DateTime.Parse("1999-07-01")},
                new Student{FirstName="Ada",LastName="Yılmaz",BirthDay=DateTime.Parse("2003-03-01")},
                new Student{FirstName="Esen",LastName="Gür",BirthDay=DateTime.Parse("1998-03-01")},
                new Student{FirstName="Duygu",LastName="Dost",BirthDay = DateTime.Parse("1997-03-01")},
                new Student{FirstName="Deniz",LastName="Gezgin",BirthDay=DateTime.Parse("2004-03-01")},
            };

            context.Students.AddRange(students);
            context.SaveChanges();

            var courses = new Course[]
            {
                new Course{CourseCode="CSI101",CourseName="Introduction to Computer Science"},
                new Course{CourseCode="CSI102",CourseName = "Algorithms"},
                new Course{CourseCode="MAT101",CourseName = "Calculus"},
                new Course{CourseCode="PHY101",CourseName = "Physics"}
            };

            context.Courses.AddRange(courses);
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
                new Enrollment{StudentId=1,CourseId=1},
                new Enrollment{StudentId=1,CourseId=2},
                new Enrollment{StudentId=1,CourseId=3},
                new Enrollment{StudentId=2,CourseId=1},
                new Enrollment{StudentId=2,CourseId=2},
                new Enrollment{StudentId=3,CourseId=2},
                new Enrollment{StudentId=3,CourseId=4},
                new Enrollment{StudentId=4,CourseId=1},
                new Enrollment{StudentId=4,CourseId=4}
            };

            context.Enrollments.AddRange(enrollments);
            context.SaveChanges();
        }
    }
}
