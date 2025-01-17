using lesson_5.Models;
using lesson_5.Models.Clients;
using lesson_5.Models.Data;
using lesson_5.Models.Personals;
using lesson_5.Models.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_5
{
    public class ShopContext : DbContext
    {
        public ShopContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer
                (@"data source=(localdb)\MSSQLLocalDB;initial catalog=InternetShop;integrated security=True;MultipleActiveResultSets=true");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().UseTpcMappingStrategy();
            modelBuilder.Entity<Client>().UseTpcMappingStrategy();
            modelBuilder.Entity<Personal>().UseTpcMappingStrategy();
        }
        // Father classes
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Personal> Personals { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        // Clients
        public virtual DbSet<Buyer> Buyers { get; set; }
        public virtual DbSet<Provider> Providers { get; set; }

        // Personals
        public virtual DbSet<Consultant> Consultants { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }

        // Products
        public virtual DbSet<Technique> Techniques { get; set; }
        public virtual DbSet<Cloth> Clothes { get; set; }
        public virtual DbSet<Book> Books { get; set; }

        // Data
        public virtual DbSet<Call> Calls { get; set; }
        public virtual DbSet<Supply> Supplies { get; set; }
        public virtual DbSet<Purchase> Purchases { get; set; }
    }
}
