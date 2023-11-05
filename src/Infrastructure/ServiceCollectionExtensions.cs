using CleanArchitecture.Prover.Domain.Repositories;
using CleanArchitecture.Prover.Infrastructure.Database;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Prover.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IPrøveRepository, PrøveRepository>();
        return services;
    }
}