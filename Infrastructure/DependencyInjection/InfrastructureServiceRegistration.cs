using Application.Interfaces;
using Infrastructure.FakeDatabase;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DependencyInjection
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            // Register ILibraryDatabase with LibraryDatabase implementation
            services.AddSingleton<ILibraryDatabase, LibraryDatabase>();
            return services;
        }
    }
}
