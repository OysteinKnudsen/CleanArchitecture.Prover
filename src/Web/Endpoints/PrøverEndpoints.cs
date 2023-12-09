using System.Net;
using CleanArchitecture.Prover.Application.Prøver;
using CleanArchitecture.Prover.Domain.ValueTypes;
using CleanArchitecture.Prover.Web.Models;

namespace CleanArchitecture.Prover.Web.Endpoints;

internal static class PrøverEndpoints
{
    public static IEndpointRouteBuilder AddPrøverEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("api/prøver", GetPrøver())
            .WithTags("Prøver")
            .WithName("GetPrøver")
            .Produces<IEnumerable<PrøveViewModel>>();
        
        app.MapGet("api/prøver/{id}", GetPrøve())
            .WithTags("Prøver")
            .WithName("GetPrøve")
            .Produces<PrøveViewModel>();

        app.MapPost("api/prøver", CreatePrøve())
            .WithTags("Prøver")
            .WithName("CreatePrøve")
            .Produces((int)HttpStatusCode.Accepted);

        app.MapPut("api/prøver/{prøveId}/elever/{elevId}", UpdateElev())
            .WithTags("Prøver")
            .WithName("UpdateElev")
            .Produces((int)HttpStatusCode.NoContent);
        return app;
    }

    private static Func<IPrøveService, Task<IResult>> GetPrøver()
    {
        return async (prøveService) =>
        {
            var prøver = await prøveService.GetAllAsync();
            return Results.Ok(prøver.Select(PrøveViewModel.From));
        };
    }

    private static Func<int, IPrøveService, Task<IResult>> GetPrøve()
    {
        return async (id, prøveService) =>
        {
            var prøve = await prøveService.GetByIdAsync((PrøveId)id);
            return Results.Ok(PrøveViewModel.From(prøve));
        };
    }
    
    private static Func<CreatePrøveModel, IPrøveService, IResult> CreatePrøve()
    {
        // Hint: lurer du på forskjellen på en Func<T1..> og en Action<T1..>?
        // Func representerer en metode som returnerer en verdi,
        // mens Action representerer en metode som ikke returnerer en verdi.
        
        return (CreatePrøveModel prøve, IPrøveService prøveService) =>
        {
            //TODO: Implement required changes in prøveService
            return Results.Accepted();
        };
    }
    
    private static Func<int, int, UpdateElevModel, IPrøveService, IResult> UpdateElev()
    {
        return (int prøveId, int elevId, UpdateElevModel elev, IPrøveService prøveService) =>
        {
            //TODO: Implement required changes in prøveService
            return Results.NoContent();
        };
    }
}