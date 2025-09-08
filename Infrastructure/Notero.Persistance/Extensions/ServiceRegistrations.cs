using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Notero.Application.Contracts.Persistance;
using Notero.Domain.Entities;
using Notero.Persistance.Concrete;
using Notero.Persistance.Context;
using Notero.Persistance.Interceptors;

namespace Notero.Persistance.Extensions
{
    public static class ServiceRegistrations
    {
        public static void AddPersistance(this IServiceCollection services , IConfiguration configuration)
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
            services.AddScoped(typeof(IRepository<>),typeof(GenericRepository<>));
        }   
    }
}
