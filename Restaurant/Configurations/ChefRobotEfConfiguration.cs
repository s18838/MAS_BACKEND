using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Models;

namespace Restaurant.Configurations
{
    /// <summary>
    /// Configuration for ChefRobot
    /// </summary>
    public class ChefRobotEfConfiguration : IEntityTypeConfiguration<ChefRobot>
    {
        /// <summary>
        /// Configuration method
        /// </summary>
        public void Configure(EntityTypeBuilder<ChefRobot> builder)
        {
            builder.Property(e => e.Specialization)
                .HasMaxLength(256)
                .IsRequired();
        }
    }
}
