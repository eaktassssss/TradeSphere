using Microsoft.EntityFrameworkCore;
using System.Reflection;
using CustomerService.Domain.Entities;

namespace CustomerService.Persistence.Context.EntityFramework
{
    public class CustomerDdContext : DbContext
    {
        public CustomerDdContext(DbContextOptions<CustomerDdContext> options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("CustomerService");
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
