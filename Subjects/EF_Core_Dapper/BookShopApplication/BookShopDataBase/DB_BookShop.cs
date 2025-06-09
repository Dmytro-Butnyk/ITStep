using BookShopDataBase.Models.BookDetails;
using BookShopDataBase.Models.BookTable;
using BookShopDataBase.Models.ClientDetails;
using BookShopDataBase.Models.DiscountTable;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopDataBase
{
    public class DB_BookShop : DbContext
    {
        public DB_BookShop() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer
                (@"data source=(localdb)\MSSQLLocalDB;initial catalog=DB_BookShop;integrated security=True;MultipleActiveResultSets=true");

        // Book details
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }

        // BookTable
        public virtual DbSet<Book> Books { get; set; }

        // Client details
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        // Discount table
        public virtual DbSet<DiscountGenre> DiscountGenres { get; set; }
    }
}
