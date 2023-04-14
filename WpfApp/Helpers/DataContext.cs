using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WpfApp.Models;

namespace WpfApp.Helpers
{
    public class DataContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\MSSQLLocalDB;Database=Software_Development_1;Trusted_Connection=True;");
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .HasIndex(a => a.Name)
                .IsUnique(); 
            
            modelBuilder.Entity<Book>()
                .HasIndex(b => b.Name)
                .IsUnique();

            modelBuilder.Seed();
        }
    }
}