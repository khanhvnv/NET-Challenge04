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
                new Category { ID = 1, Name = "Electronics" },
                new Category { ID = 2, Name = "Books" },
                new Category { ID = 3, Name = "Clothing" },
                new Category { ID = 4, Name = "Home & Kitchen" }
            );
        }
    }
}
