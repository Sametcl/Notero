using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Notero.Application.Contracts.Persistance;
using Notero.Persistance.Concrete;
using Notero.Persistance.Context;
using Notero.Persistance.Interceptors;

namespace Notero.Persistance.Extensions
{
    public static class ServerRegistrations
    {
        public static void AddPersistance(this IServiceCollection services , IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SqlConnection"));
                options.AddInterceptors(new AuditDBContextInterceptor());
            }); 

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>),typeof(GenericRepository<>));
        }   
    }
}
