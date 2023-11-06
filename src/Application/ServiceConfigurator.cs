using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Prover.Application;

public static class ServiceConfigurator
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(ServiceConfigurator).Assembly;
        services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(assembly));

        return services;
    }
}