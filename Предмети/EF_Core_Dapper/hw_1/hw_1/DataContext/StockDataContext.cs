using hw_1.Models;
using Microsoft.EntityFrameworkCore;

namespace hw_1.DataContext;

public class StockDataContext : DbContext
{
    
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductType> ProductTypes { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Stock;Trusted_Connection=True;");
    }
}