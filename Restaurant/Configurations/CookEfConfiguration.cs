using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Models;

namespace Restaurant.Configurations
{
    /// <summary>
    /// Configuration for Cook
    /// </summary>
    public class CookEfConfiguration : IEntityTypeConfiguration<Cook>
    {
        /// <summary>
        /// Configuration method
        /// </summary>
        public void Configure(EntityTypeBuilder<Cook> builder)
        {
            builder.Property(e => e.Specialization)
                .HasMaxLength(256)
                .IsRequired();
        }
    }
}
