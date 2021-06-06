using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Models;

namespace Restaurant.Configurations
{
    public class ChefRobotEfConfiguration : IEntityTypeConfiguration<ChefRobot>
    {
        public void Configure(EntityTypeBuilder<ChefRobot> builder)
        {
            builder.Property(e => e.Specialization)
                .HasMaxLength(256)
                .IsRequired();
        }
    }
}
