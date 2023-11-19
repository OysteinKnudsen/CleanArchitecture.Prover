using CleanArchitecture.Prover.Application.Prøvegrupper;
using CleanArchitecture.Prover.Application.Prøver;
using CleanArchitecture.Prover.Application.Skole;
using CleanArchitecture.Prover.Infrastructure.Database;
using CleanArchitecture.Prover.Infrastructure.Services;
using CleanArchitecture.Prover.Infrastructure.Services.MemorySkoleService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Prover.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IPrøveRepository, PrøveRepository>();
        services.AddTransient<ISkoleService, InMemorySkoleService>();
        services.AddSingleton<IPrøvegruppeRepository, PrøvegruppeRepository>();
        return services;
    }
}