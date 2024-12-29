using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using TPCleanArchitecture.Domain;

namespace TPCleanArchitecture.Infrastucture
{
    public class AppDBContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Review> Reviews { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
     .HasMany(c => c.FavoriteMovies)
     .WithMany(m => m.Customers)  // Si vous avez une propriété de navigation dans Movie
     .UsingEntity(j => j.ToTable("CustomerFavoriteMovies"));
        }
    }
}