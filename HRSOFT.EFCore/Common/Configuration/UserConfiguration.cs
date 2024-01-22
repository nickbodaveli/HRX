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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            ConfigureUserTable(builder);
        }

        private void ConfigureUserTable(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);
            builder.Property(m => m.Name).HasMaxLength(100);
            builder.Property(m => m.LastName).HasMaxLength(100);
            builder.Property(m => m.Password).HasMaxLength(100);
            builder.Property(m => m.RepeatPassword).HasMaxLength(100);
            builder.Property(m => m.DateOfBirht).HasMaxLength(100);
            builder.Property(m => m.Email).HasMaxLength(100);
            builder.Property(m => m.PrivateNumber).HasMaxLength(100);
        }
    }
}
