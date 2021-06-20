using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Models;

namespace Restaurant.Configurations
{
    /// <summary>
    /// Configuration for Robot
    /// </summary>
    public class RobotEfConfiguration : IEntityTypeConfiguration<Robot>
    {
        /// <summary>
        /// Configuration method
        /// </summary>
        public void Configure(EntityTypeBuilder<Robot> builder)
        {
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.LaunchDate)
                .IsRequired();

            builder.Property(e => e.PositionX)
                .HasColumnName("X");

            builder.Property(e => e.PositionY)
                .HasColumnName("Y");

            builder.Property(e => e.DateOfLastCheck)
                .IsRequired();

            builder.Property(e => e.IsStatic)
                .IsRequired();

            builder.HasDiscriminator<int>("RobotType")
                .HasValue<WaiterRobot>(1)
                .HasValue<ChefRobot>(2);

            builder.HasMany(e => e.RobotRepairmen)
                .WithMany(e => e.Robots);
        }
    }
}
