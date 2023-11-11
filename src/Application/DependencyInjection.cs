using CleanArchitecture.Prover.Application.Prøver;
using CleanArchitecture.Prover.Application.Prøver.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Prover.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddTransient<IPrøveService, PrøveService>();
        return services;
    }
}