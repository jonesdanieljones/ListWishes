using ListWishes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ListWishes.Infra.Data.Mapping
{
    public class ItemsProductWishMap : IEntityTypeConfiguration<ItemsProductWish>
    {
        public void Configure(EntityTypeBuilder<ItemsProductWish> builder)
        {
            builder.ToTable("ItemsProductWish");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.WishId)
                .IsRequired()
                .HasColumnName("WishId");
            builder.Property(c => c.ProductId)
                .IsRequired()
                .HasColumnName("ProductId");

        }
    }
}
