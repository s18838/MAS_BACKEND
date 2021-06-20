using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Models;

namespace Restaurant.Configurations
{
    /// <summary>
    /// Configuration for Table
    /// </summary>
    public class TableEfConfiguration : IEntityTypeConfiguration<Table>
    {
        /// <summary>
        /// Configuration method
        /// </summary>
        public void Configure(EntityTypeBuilder<Table> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.NumberOfSeats)
                .IsRequired();

            builder.HasMany(e => e.TableReservations)
                .WithOne(e => e.Table)
                .HasForeignKey(e => e.TableId);

            builder.HasOne(e => e.Room)
                .WithMany(e => e.Tables)
                .HasForeignKey(e => e.RoomId);
        }
    }
}
