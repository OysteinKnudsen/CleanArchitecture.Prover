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

        app.MapPut("api/prøver/{prøveId}/elev/{elevId}", UpdateElev())
            .WithTags("Prøver")
            .WithName("UpdateElev")
            .Produces((int)HttpStatusCode.NoContent);
        return app;
    }

    private static Func<IPrøveService, CancellationToken, Task<IResult>> GetPrøver()
    {
        return async (prøveService, cancellationToken) =>
        {
            var prøver = await prøveService.GetAllAsync(cancellationToken);
            return Results.Ok(prøver.Select(PrøveViewModel.From));
        };
    }

    private static Func<int, IPrøveService, CancellationToken, Task<IResult>> GetPrøve()
    {
        return async (id, prøveService, cancellationToken) =>
        {
            var prøve = await prøveService.GetByIdAsync((PrøveId)id, cancellationToken);
            return Results.Ok(PrøveViewModel.From(prøve));
        };
    }
    
    private static Action<CreatePrøveModel, IPrøveService, CancellationToken> CreatePrøve()
    {
        // Hint: lurer du på forskjellen på en Func<T1..> og en Action<T1..>?
        // Func representerer en metode som returnerer en verdi,
        // mens Action representerer en metode som ikke returnerer en verdi.
        
        return (CreatePrøveModel prøve, IPrøveService prøveService, CancellationToken cancellationToken) =>
        {
            //TODO: Implement required changes in prøveService
            Results.Accepted();
        };
    }
    
    private static Action<int, int, UpdateElevModel, IPrøveService, CancellationToken> UpdateElev()
    {
        return (int prøveId, int elevId, UpdateElevModel elev, IPrøveService prøveService,
            CancellationToken cancellationToken) =>
        {
            //TODO: Implement required changes in prøveService
            Results.NoContent();
        };
    }
}