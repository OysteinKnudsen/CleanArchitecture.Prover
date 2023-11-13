using CleanArchitecture.Prover.Application.Skole;
using CleanArchitecture.Prover.Domain.ValueTypes;
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
        
        routeBuilder.MapGet("api/skole/lærere/{id}", GetLærer())
            .WithName("GetLærer")
            .WithTags("Skole")
            .Produces<LærerViewModel>();
        
        routeBuilder.MapGet("api/skole/elever", GetElever())
            .WithName("GetElever")
            .WithTags("Skole")
            .Produces<IEnumerable<ElevViewModel>>();
        
        routeBuilder.MapGet("api/skole/elever/{id}", GetElev())
            .WithName("GetElev")
            .WithTags("Skole")
            .Produces<ElevViewModel>();
        
        routeBuilder.MapGet("api/skole/klasser", GetKlasser())
            .WithName("GetKlasser")
            .WithTags("Skole")
            .Produces<IEnumerable<KlasseViewModel>>();
        
        routeBuilder.MapGet("api/skole/klasser/{id}", GetKlasse())
            .WithName("GetKlasse")
            .WithTags("Skole")
            .Produces<KlasseViewModel>();
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

    private static Func<int, ISkoleService, Task<IResult>> GetLærer()
    {
        return async (id, skoleService) =>
        {
            var lærer = await skoleService.GetLærerByIdAsync((LærerId)id);
            if (lærer is null) return Results.NotFound();
            return Results.Ok(LærerViewModel.From(lærer));
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
    
    private static Func<int, ISkoleService, Task<IResult>> GetElev()
    {
        return async (id, skoleService) =>
        {
            var elev = await skoleService.GetElevByIdAsync((ElevId)id);
            if (elev is null) return Results.NotFound();
            return Results.Ok(ElevViewModel.From(elev));
        };
    }
    
    private static Func<ISkoleService, Task<IResult>> GetKlasser()
    {
        return async (skoleService) =>
        {
            var klasser = await skoleService.GetKlasserAsync();
            return Results.Ok(klasser.Select(KlasseViewModel.From));
        };
    }
    
    private static Func<int, ISkoleService, Task<IResult>> GetKlasse()
    {
        return async (id, skoleService) =>
        {
            var klasse = await skoleService.GetKlasseByIdAsync((KlasseId)id);
            if (klasse is null) return Results.NotFound();
            return Results.Ok(KlasseViewModel.From(klasse));
        };
    }
}