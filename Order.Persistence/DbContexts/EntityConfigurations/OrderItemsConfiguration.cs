using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Persistence.DbContexts.EntityConfigurations
{
    public class OrderItemsConfiguration : IEntityTypeConfiguration<OrderItems>
    {
        public void Configure(EntityTypeBuilder<OrderItems> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.ProductId).IsRequired();
            builder.Property(d => d.Quantity).IsRequired();
            builder.Property(d => d.UnitPrice).IsRequired();
            builder.Property(d => d.OrderId).IsRequired();
        }
    }

}
