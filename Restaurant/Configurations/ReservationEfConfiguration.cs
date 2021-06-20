using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Models;

namespace Restaurant.Configurations
{
    /// <summary>
    /// Configuration for Reservation
    /// </summary>
    public class ReservationEfConfiguration : IEntityTypeConfiguration<Reservation>
    {
        /// <summary>
        /// Configuration method
        /// </summary>
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.ReservationDate)
                .IsRequired();

            builder.Property(e => e.Status)
                .IsRequired();

            builder.HasOne(e => e.Client)
                .WithMany(e => e.Reservations)
                .HasForeignKey(e => e.ClientId);
        }
    }
}
