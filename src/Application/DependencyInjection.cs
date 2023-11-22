using CleanArchitecture.Prover.Application.Prøvegrupper.Services;
using CleanArchitecture.Prover.Application.Prøver;
using CleanArchitecture.Prover.Application.Prøver.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Prover.Application;

public static class DependencyInjection
{
    
    /*
     * Når en klasse krever en avhengighet, injiseres den automatisk av DI-kontaineren
     * basert på konfigurasjonen i IServiceCollection. DI-kontaineren håndterer
     * altså opprettelse og levetid av avhengigheter. Dette bidrar til "loose coupling".
     *
     * Hint: Har du opprettet en ny service? Husk at du må registrere den i DI-kontaineren.
     */
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddTransient<IPrøvegruppeService, PrøvegruppeService>();
        services.AddTransient<IPrøveService, PrøveService>();
        return services;
    }
}