
using Microsoft.EntityFrameworkCore;


namespace WebMVC_2.Data
{
    public class DBContext : DbContext
    {
        public DBContext (DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Auth> Auth { get; set; } = default!;
        public DbSet<Models.Book> Book { get; set; } = default!;
    }
}
