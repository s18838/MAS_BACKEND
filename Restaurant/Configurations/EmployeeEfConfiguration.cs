using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Models;

namespace Restaurant.Configurations
{
    public class EmployeeEfConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.Salary)
                .IsRequired();

            builder.Property(e => e.DateOfEmployment)
                .IsRequired();

            builder.Property(e => e.StartHour)
                .IsRequired();

            builder.Property(e => e.FinishHour)
                .IsRequired();
        }
    }
}
