using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ListWishes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

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
