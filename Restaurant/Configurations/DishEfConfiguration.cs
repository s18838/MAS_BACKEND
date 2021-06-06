using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Models;

namespace Restaurant.Configurations
{
    public class DishEfConfiguration : IEntityTypeConfiguration<Dish>
    {
        public void Configure(EntityTypeBuilder<Dish> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(e => e.Price)
                .IsRequired();

            builder.Property(e => e.Country)
                .HasMaxLength(32)
                .IsRequired();

            builder.Property(e => e.Weight)
                .IsRequired();

            builder.Property(e => e.Ingredients)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(e => e.Image)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(e => e.CookingTime)
                .IsRequired();
        }
    }
}
