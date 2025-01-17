using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace lesson_2;

public partial class CountriesContext : DbContext
{
    public CountriesContext()
    {
    }

    public CountriesContext(DbContextOptions<CountriesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Country> Countries { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source=(localdb)\\MSSQLLocalDB;initial catalog=Countries;integrated security=True;MultipleActiveResultSets=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__City__3214EC07F6A032EE");

            entity.ToTable("City");

            entity.Property(e => e.CityName).HasMaxLength(100);

            entity.HasOne(d => d.Country).WithMany(p => p.Cities)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__City__CountryId__286302EC");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Country__3214EC07F474B510");

            entity.ToTable("Country");

            entity.Property(e => e.CountryName).HasMaxLength(100);
            entity.Property(e => e.WorldPart).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
