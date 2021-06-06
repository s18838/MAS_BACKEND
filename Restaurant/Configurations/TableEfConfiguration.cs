using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Models;

namespace Restaurant.Configurations
{
    public class TableEfConfiguration : IEntityTypeConfiguration<Table>
    {
        public void Configure(EntityTypeBuilder<Table> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.NumberOfSeats)
                .IsRequired();

            builder.HasMany(e => e.TableReservations)
                .WithOne(e => e.Table);

            builder.HasOne(e => e.Room)
                .WithMany(e => e.Tables)
                .HasForeignKey(e => e.RoomId);
        }
    }
}
