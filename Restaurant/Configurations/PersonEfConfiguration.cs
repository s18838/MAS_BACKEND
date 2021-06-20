using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Models;

namespace Restaurant.Configurations
{
    /// <summary>
    /// Configuration for Person
    /// </summary>
    public class PersonEfConfiguration : IEntityTypeConfiguration<Person>
    {
        /// <summary>
        /// Configuration method
        /// </summary>
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Name)
                .HasMaxLength(32)
                .IsRequired();

            builder.Property(e => e.Surname)
                .HasMaxLength(32)
                .IsRequired();

            builder.Property(e => e.Password)
                .HasMaxLength(32)
                .IsRequired();

            builder.Property(e => e.Email)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(e => e.Phone)
                .HasMaxLength(16)
                .IsRequired(false);

            builder.Property(e => e.Birthday)
                .IsRequired(false);

            builder.HasDiscriminator<int>("PersonType")
                .HasValue<Client>(1)
                .HasValue<RobotRepairman>(2)
                .HasValue<Cook>(3);
        }
    }
}
