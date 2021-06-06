using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Models;

namespace Restaurant.Configurations
{
    public class CookEfConfiguration : IEntityTypeConfiguration<Cook>
    {
        public void Configure(EntityTypeBuilder<Cook> builder)
        {
            builder.Property(e => e.Specialization)
                .HasMaxLength(256)
                .IsRequired();
        }
    }
}
