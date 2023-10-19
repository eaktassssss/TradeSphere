using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Order.Domain.Entities;

namespace Order.Persistence.DbContexts.EntityConfigurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order.Domain.Entities.Order>
    {
        public void Configure(EntityTypeBuilder<Order.Domain.Entities.Order> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.OrderDate).IsRequired();
            builder.Property(o => o.CustomerId).IsRequired();
            builder.Property(o => o.Status).IsRequired();
            builder.Property(o => o.TotalPrice).IsRequired();
            builder.HasMany(o => o.OrderItems)
                   .WithOne(d => d.Order)
                   .HasForeignKey(d => d.OrderId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
