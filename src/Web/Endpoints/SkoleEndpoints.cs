using CleanArchitecture.Prover.Application.Skole;
using CleanArchitecture.Prover.Web.Models;

namespace CleanArchitecture.Prover.Web.Endpoints;

internal static class SkoleEndpoints
{
    public static IEndpointRouteBuilder AddSkoleEndpoints(this IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapGet("api/lærere", GetLærere())
            .WithName("GetLærere")
            .Produces<IEnumerable<LærerViewModel>>();
        return routeBuilder;
    }
    
    private static Func<int, ISkoleService, Task<IResult>> GetLærere()
    {
        return async (id, skoleService) =>
        {
            var lærere = await skoleService.GetLærereAsync();
            return Results.Ok(lærere.Select(LærerViewModel.From));
        };
    }
}