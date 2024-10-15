using InterviewWebAPIQuestions.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace InterviewWebAPIQuestions.Infra
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasKey("Id");
            modelBuilder.Entity<Product>().HasData(new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Product A",
                    Price = 100
                },
                new Product
                {
                    Id = 2,
                    Name = "Product B",
                    Price = 200
                },
                new Product
                {
                    Id = 3,
                    Name = "Product C",
                    Price = 300
                },
                new Product
                {
                    Id = 4,
                    Name = "Product D",
                    Price = 400
                },
                new Product
                {
                    Id = 5,
                    Name = "Product E",
                    Price = 500
                }
            });
        }
    }
}
