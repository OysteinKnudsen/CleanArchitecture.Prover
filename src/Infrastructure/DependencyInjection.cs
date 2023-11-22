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
    /*
     * Når en klasse krever en avhengighet, injiseres den automatisk av DI-kontaineren
     * basert på konfigurasjonen i IServiceCollection. DI-kontaineren håndterer
     * altså opprettelse og levetid av avhengigheter. Dette bidrar til "loose coupling".
     *
     * Hint: Har du opprettet et nytt repository? Husk at du må registrere det i DI-kontaineren.
     */
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient();
        services.AddTransient<ISkoleService, InMemorySkoleService>();
        services.AddSingleton<IPrøveRepository, PrøveRepository>();
        return services;
    }
}