using CleanArchitecture.Prover.Application.Abstractions;
using CleanArchitecture.Prover.Infrastructure.Database;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Prover.Infrastructure;

public static class ServiceConfigurator
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IPrøveRepository, PrøveRepository>();
        return services;
    }
}