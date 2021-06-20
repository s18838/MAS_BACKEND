using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Models;

namespace Restaurant.Configurations
{
    /// <summary>
    /// Configuration for Employee
    /// </summary>
    public class EmployeeEfConfiguration : IEntityTypeConfiguration<Employee>
    {
        /// <summary>
        /// Configuration method
        /// </summary>
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
