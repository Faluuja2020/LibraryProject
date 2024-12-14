using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Register MediatR with the current assembly (Application layer)
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(typeof(ApplicationServiceRegistration).Assembly);
            });

            return services;
        }
    }
}
