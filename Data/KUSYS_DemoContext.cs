using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KUSYS_Demo.Models;

namespace KUSYS_Demo.Data
{
    public class KUSYS_DemoContext : DbContext
    {
        public KUSYS_DemoContext(DbContextOptions<KUSYS_DemoContext> options)
            : base(options)
        {
        }

        public DbSet<Student>? Students { get; set; }
        public DbSet<Enrollment>? Enrollments { get; set; }
        public DbSet<Course>? Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Student>().ToTable("Student");
        }
    }
}
