using CleanArchitecture.Prover.Application.Skole;
using CleanArchitecture.Prover.Web.Models;

namespace CleanArchitecture.Prover.Web.Endpoints;

internal static class SkoleEndpoints
{
    public static IEndpointRouteBuilder AddSkoleEndpoints(this IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapGet("api/skole/lærere", GetLærere())
            .WithName("GetLærere")
            .WithTags("Skole")
            .Produces<IEnumerable<LærerViewModel>>();
        
        routeBuilder.MapGet("api/skole/elever", GetElever())
            .WithName("GetElever")
            .WithTags("Skole")
            .Produces<IEnumerable<ElevViewModel>>();
        
        routeBuilder.MapGet("api/skole/klasser", GetKlasser())
            .WithName("GetKlasser")
            .WithTags("Skole")
            .Produces<IEnumerable<KlasseViewModel>>();
        return routeBuilder;
    }
    
    private static Func<ISkoleService, Task<IResult>> GetLærere()
    {
        return async (skoleService) =>
        {
            var lærere = await skoleService.GetLærereAsync();
            return Results.Ok(lærere.Select(LærerViewModel.From));
        };
    }
    
    private static Func<ISkoleService, Task<IResult>> GetElever()
    {
        return async (skoleService) =>
        {
            var elever = await skoleService.GetEleverAsync();
            return Results.Ok(elever.Select(ElevViewModel.From));
        };
    }
    
    private static Func<ISkoleService, Task<IResult>> GetKlasser()
    {
        return async (skoleService) =>
        {
            var klasser = await skoleService.GetKlasserAsync();
            return Results.Ok(klasser);
        };
    }
}