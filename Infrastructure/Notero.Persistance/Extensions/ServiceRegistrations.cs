using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Notero.Application.Contracts.Persistance;
using Notero.Application.Options;
using Notero.Domain.Entities;
using Notero.Persistance.Concrete;
using Notero.Persistance.Context;
using Notero.Persistance.Interceptors;

namespace Notero.Persistance.Extensions
{
    public static class ServiceRegistrations
    {
        public static void AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SqlConnection"));
                options.AddInterceptors(new AuditDBContextInterceptor());
                options.UseLazyLoadingProxies();
            });
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                //options.Password.RequireDigit = true;
                //options.Password.RequireLowercase = true;
                //options.Password.RequireUppercase = true;
                //options.Password.RequiredLength = 6;
                //options.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<AppDbContext>();


            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IJwtService, JwtService>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opt =>
            {
                var jwtTokenOptions = configuration.GetSection(nameof(JwtTokenOptions)).Get<JwtTokenOptions>();
                opt.TokenValidationParameters = new()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidIssuer = jwtTokenOptions.Issuer,
                    ValidAudience = jwtTokenOptions.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtTokenOptions.Key)),
                    ClockSkew = TimeSpan.Zero,
                };
            });

        }
    }
}
