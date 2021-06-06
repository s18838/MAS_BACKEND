using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Models;

namespace Restaurant.Configurations
{
    public class RoomReservationEfConfiguration : IEntityTypeConfiguration<RoomReservation>
    {
        public void Configure(EntityTypeBuilder<RoomReservation> builder)
        {
            builder.Property(e => e.PersonCount)
                .IsRequired();

            builder.HasOne(e => e.PartyRoom)
                .WithMany(e => e.RoomReservations)
                .HasForeignKey(e => e.PartyRoomId);
        }
    }
}
