using ListWishes.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ListWishes.Infra.Data.Mapping
{
    public class WishMap : IEntityTypeConfiguration<Wish>
    {
        public void Configure(EntityTypeBuilder<Wish> builder)
        {
            builder.ToTable("Wish");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.UserId)
                .IsRequired()
                .HasColumnName("UserId");    
        }
    }
}
