using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Models;

namespace Restaurant.Configurations
{
    public class ReservationEfConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.ReservationDate)
                .IsRequired();

            builder.Property(e => e.Status)
                .IsRequired();

            builder.HasOne(e => e.Client)
                .WithMany(e => e.Reservations);
        }
    }
}
