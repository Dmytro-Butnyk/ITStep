using lesson_4.Entities;
using Microsoft.EntityFrameworkCore;
using static System.Console;

namespace lesson_3
{
    public class SampleContext : DbContext
    {
        public SampleContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer
                (@"data source=(localdb)\MSSQLLocalDB;initial catalog=University;integrated security=True;MultipleActiveResultSets=true");

        public virtual DbSet<Student> Students{ get; set; }
        public virtual DbSet<Teacher> Teachers{ get; set; }
        public virtual DbSet<Course> Courses{ get; set; }
        public virtual DbSet<Department> Departments{ get; set; }
        public virtual DbSet<Adress> Adresses{ get; set; }
    }
}
