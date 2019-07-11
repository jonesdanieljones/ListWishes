using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ListWishes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListWishes.Infra.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Email)
                .IsRequired()
                .HasColumnName("Email");
    
            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnName("Name");
        }
    }
}
