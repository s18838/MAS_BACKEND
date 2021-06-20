using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Models;

namespace Restaurant.Configurations
{
    /// <summary>
    /// Configuration for Room
    /// </summary>
    public class RoomEfConfiguration : IEntityTypeConfiguration<Room>
    {
        /// <summary>
        /// Configuration method
        /// </summary>
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Level)
                .IsRequired();

            builder.Property(e => e.Image)
                .IsRequired();
        }
    }
}
