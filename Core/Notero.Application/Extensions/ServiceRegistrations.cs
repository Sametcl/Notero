using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Notero.Application.Behaviors;
using System.Reflection;

namespace Notero.Application.Extensions
{
    public static class ServiceRegistrations
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(cfg => cfg.AddMaps(assembly));
            services.AddMediatR(cfg => 
            {
                cfg.RegisterServicesFromAssembly(assembly);
                cfg.AddOpenBehavior(typeof( ValidationBehavior<,>));
            });
            services.AddValidatorsFromAssembly(assembly);
        }
    }
}

