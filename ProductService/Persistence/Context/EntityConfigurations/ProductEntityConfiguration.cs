using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProductService.Domain.Entities;

namespace ProductService.Persistence.Context.EntityConfigurations
{
    public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired(true);
            builder.Property(x => x.Price).IsRequired(true);
            builder.Property(x => x.Name).HasMaxLength(80);
            builder.Property(x => x.CategoryId).IsRequired(true);
            builder.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.NoAction);



            #region Seed Data
            builder.HasData(new Product() { Id = 1, Name = "Gardırop", Price = 3000, CategoryId = 1 },
              new Product() { Id = 2, Name = "Fırın", Price = 4000, CategoryId = 2 }
            , new Product() { Id = 3, Name = "Fıstık Ezmesi", Price = 85, CategoryId = 3 }, new Product() { Id = 4, Name = "ModeLight Işıl 3'lü Avize", Price = 4000, CategoryId = 4 });
            #endregion
        }
    }
}
