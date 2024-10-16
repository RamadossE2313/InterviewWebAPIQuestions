using InterviewWebAPIQuestions.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace InterviewWebAPIQuestions.Infra
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<OrderDetail> OrderDetails { get; set; } = null!;
    }
}
