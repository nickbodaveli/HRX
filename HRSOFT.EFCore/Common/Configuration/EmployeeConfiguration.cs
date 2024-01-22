using HRSOFT.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSOFT.EFCore.Common.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            ConfigureEmployeeTable(builder);
        }

        private void ConfigureEmployeeTable(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");
            builder.HasKey(x => x.Id);
            builder.Property(m => m.Name).HasMaxLength(100);
            builder.Property(m => m.LastName).HasMaxLength(100);
            builder.Property(m => m.MobileNumber).HasMaxLength(100);
            builder.Property(m => m.Position).HasMaxLength(100);
            builder.Property(m => m.MobileNumber).HasMaxLength(100);
            builder.Property(m => m.DateOfBirht).HasMaxLength(100);
            builder.Property(m => m.FreedDate).HasMaxLength(100);
        }
    }
}
