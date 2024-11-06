using Microsoft.EntityFrameworkCore;
using CategoryApi.Models;

namespace CategoryApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Seed data
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Electronics", Description ="Electronics" },
                new Category { Id = 2, Name = "Books", Description = "Books"},
                new Category { Id = 3, Name = "Clothing", Description = "Clothing"},
                new Category { Id = 4, Name = "Home & Kitchen", Description = "Home & Kitchen"}
            );
        }
    }
}
