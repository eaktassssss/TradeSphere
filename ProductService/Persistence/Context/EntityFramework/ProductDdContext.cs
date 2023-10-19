using Microsoft.EntityFrameworkCore;
using System.Reflection;
using ProductService.Domain.Entities;

namespace ProductService.Persistence.Context.EntityFramework
{
    public class ProductDdContext : DbContext
    {
        public ProductDdContext(DbContextOptions<ProductDdContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
