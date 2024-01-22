using FluentValidation;
using FluentValidation.AspNetCore;
using HRSOFT.Application.Common.Interfaces;
using HRSOFT.Application.Feature.Commands.Authentication;
using HRSOFT.Application.Feature.Commands.Authentication.Login;
using HRSOFT.Application.Feature.Commands.Authentication.Register;
using HRSOFT.Application.Feature.Commands.Employee;
using HRSOFT.Application.Feature.Commands.Employee.Create;
using HRSOFT.Application.Feature.Commands.Employee.Edit;
using HRSOFT.Domain.Common;
using HRSOFT.EFCore.Common;
using HRSOFT.Infrastructure.Persistance.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace HRSOFT.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services)
        {
            services
            .AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 4;

                options.User.AllowedUserNameCharacters = null;
            })
            .AddEntityFrameworkStores<HRSOFTDBContext>().AddDefaultTokenProviders();

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            services.AddScoped<IValidator<UserRegisterCommand>, UserRegisterValidation>();
            services.AddValidatorsFromAssemblyContaining<UserRegisterValidation>();

            services.AddScoped<IValidator<UserLoginCommand>, UserLoginValidation>();
            services.AddValidatorsFromAssemblyContaining<UserLoginValidation>();

            services.AddScoped<IValidator<EmployeeCreateCommand>, EmployeeCreateValidation>();
            services.AddValidatorsFromAssemblyContaining<EmployeeCreateValidation>();

            services.AddScoped<IValidator<EmployeeUpdateCommand>, EmployeeUpdateValidation>();
            services.AddValidatorsFromAssemblyContaining<EmployeeUpdateValidation>();

            services.AddFluentValidationAutoValidation(config =>
            {
                config.DisableDataAnnotationsValidation = true;
                config.ImplicitlyValidateChildProperties = true;
            });


            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Account/Login"; // Specify the login path
                    options.AccessDeniedPath = "/Account/AccessDenied"; // Specify the access denied path
                });

            return services;
        }
    }
}

