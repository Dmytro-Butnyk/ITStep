using lesson_3.DBTables;
using Microsoft.EntityFrameworkCore;
using static System.Console;

namespace lesson_3
{
    public class SampleContext : DbContext
    {
        public SampleContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer
                (@"data source=(localdb)\MSSQLLocalDB;initial catalog=_GameDB;integrated security=True;MultipleActiveResultSets=true");

        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<GameStudio> GameStudios { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
    }
}
