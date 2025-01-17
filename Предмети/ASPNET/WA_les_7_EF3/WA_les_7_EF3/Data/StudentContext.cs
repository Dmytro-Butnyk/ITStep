using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WA_les_7_EF3.Pages.Models;

namespace WA_les_7_EF3.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext (DbContextOptions<StudentContext> options)
            : base(options)
        {
        }

        public DbSet<WA_les_7_EF3.Pages.Models.Student> Students { get; set; } = default!;
        public DbSet<WA_les_7_EF3.Pages.Models.Course> Courses { get; set; } = default!;
        public DbSet<WA_les_7_EF3.Pages.Models.Enrollment> Enrollments { get; set; } = default!;
        public DbSet<WA_les_7_EF3.Pages.Models.Department> Departments { get; set; } = default!;
        public DbSet<WA_les_7_EF3.Pages.Models.Instructor> Instructors { get; set; } = default!;
    }
}
