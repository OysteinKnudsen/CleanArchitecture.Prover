using CleanArchitecture.Prover.Application.Prøver;
using CleanArchitecture.Prover.Infrastructure.Database;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Prover.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IPrøveRepository, PrøveRepository>();
        return services;
    }
}