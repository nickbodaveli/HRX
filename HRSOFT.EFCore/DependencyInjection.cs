using HRSOFT.EFCore.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSOFT.EFCore
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDatabaseContext(
        this IServiceCollection services,
        ConfigurationManager configuration)
        {
            services.AddDbContext<HRSOFTDBContext>(options =>
            {
                options.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);
            });

            return services;
        }
    }
}
