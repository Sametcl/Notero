using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Notero.Application.Extensions
{
    public static class ServiceRegistrations
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(cfg => cfg.AddMaps(assembly)); 
        }
    }
}

