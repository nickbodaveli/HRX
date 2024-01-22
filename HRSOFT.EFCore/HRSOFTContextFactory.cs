using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRSOFT.EFCore.Common;

namespace HRSOFT.EFCore
{
    public class HRSOFTContextFactory : IDesignTimeDbContextFactory<HRSOFTDBContext>
    {
        public HRSOFTDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<HRSOFTDBContext>();
            var connectionString = "server=DESKTOP-KAU7PU8\\SQLEXPRESS;Database=HRSOFT;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True";
            optionsBuilder.UseSqlServer(connectionString);

            return new HRSOFTDBContext(optionsBuilder.Options);
        }
    }
}
