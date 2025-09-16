using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Notero.Application.Behaviors;
using Notero.Application.Options;
using System.Reflection;


namespace Notero.Application.Extensions
{
    public static class ServiceRegistrations
    {
        public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(cfg => cfg.AddMaps(assembly));
            services.AddMediatR(cfg => 
            {
                cfg.RegisterServicesFromAssembly(assembly);
                cfg.AddOpenBehavior(typeof( ValidationBehavior<,>));
            });
            services.AddValidatorsFromAssembly(assembly);

            services.Configure<JwtTokenOptions>(configuration.GetSection(nameof(JwtTokenOptions)));
        }
    }
}
