using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Models;

namespace Restaurant.Configurations
{
    /// <summary>
    /// Configuration for Order
    /// </summary>
    public class OrderEfConfiguration : IEntityTypeConfiguration<Order>
    {
        /// <summary>
        /// Configuration method
        /// </summary>
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.OrderDate)
                .IsRequired();

            builder.Property(e => e.Status)
                .IsRequired();

            builder.HasOne(e => e.Reservation)
                .WithMany(e => e.Orders)
                .HasForeignKey(e => e.ReservationId);

            builder.HasMany(e => e.WaiterRobots)
                .WithMany(e => e.Orders);

            builder.HasMany(e => e.OrderItems)
                .WithOne(e => e.Order)
                .HasForeignKey(e => e.OrderId);
        }
    }
}
