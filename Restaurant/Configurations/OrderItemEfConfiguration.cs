using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Models;

namespace Restaurant.Configurations
{
    /// <summary>
    /// Configuration for OrderItem
    /// </summary>
    public class OrderItemEfConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        /// <summary>
        /// Configuration method
        /// </summary>
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Count)
                .IsRequired();

            builder.Property(e => e.Status)
                .IsRequired();

            builder.HasOne(e => e.Dish)
                .WithMany(e => e.OrderItems)
                .HasForeignKey(e => e.DishId);

            builder.HasMany(e => e.Cooks)
                .WithMany(e => e.OrderItems);

            builder.HasMany(e => e.ChefRobots)
                .WithMany(e => e.OrderItems);
        }
    }
}
