using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CustomerService.Domain.Entities;

namespace CustomerService.Persistence.Context.EntityConfigurations
{
    public class CustomerEntityConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName).IsRequired(true);
            builder.Property(x => x.LastName).IsRequired(true);
            builder.Property(x => x.JoiningDate).IsRequired(true);
            builder.Property(x => x.FirstName).HasMaxLength(50);
            builder.Property(x => x.LastName).HasMaxLength(50);
            #region Seed Data
            builder.HasData(new Customer() { Id = 1, FirstName = "EVREN", LastName = "AKTAŞ", JoiningDate = DateTime.Now }
            , new Customer() { Id = 2, FirstName = "ECE", LastName = "DAĞDELEN", JoiningDate = DateTime.Now }
            , new Customer() { Id = 3, FirstName = "İBRAHİM", LastName = "AKIŞIK", JoiningDate = DateTime.Now }
            , new Customer() { Id = 4, FirstName = "GİZEM", LastName = "KURTCUOĞLU", JoiningDate = DateTime.Now });
            #endregion
        }
    }
}
