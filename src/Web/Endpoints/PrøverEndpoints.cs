using System.Net;
using CleanArchitecture.Prover.Application.Prøver.Queries;
using CleanArchitecture.Prover.Domain.ValueTypes;
using CleanArchitecture.Prover.Web.Models;
using MediatR;

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

    private static Func<IMediator, CancellationToken, Task<IResult>> GetPrøver()
    {
        return async (mediator, cancellationToken) =>
        {
            var prøver = await mediator.Send(new GetPrøver(), cancellationToken);
            return Results.Ok(prøver.Select(PrøveViewModel.From));
        };
    }

    private static Func<int, IMediator, CancellationToken, Task<IResult>> GetPrøve()
    {
        return async (id, mediator, cancellationToken) =>
        {
            var prøve = await mediator.Send(new GetPrøve((PrøveId)id), cancellationToken);
            return Results.Ok(PrøveViewModel.From(prøve));
        };
    }
    
    private static Action<CreatePrøveModel, IMediator, CancellationToken> CreatePrøve()
    {
        return (CreatePrøveModel prøve, IMediator mediator, CancellationToken cancellationToken) =>
        {
            //TODO: Send CreatePrøve command to mediator
            Results.Accepted();
        };
    }
    
    private static Action<int, int, UpdateElevModel, IMediator, CancellationToken> UpdateElev()
    {
        return (int prøveId, int elevId, UpdateElevModel elev, IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            //TODO: Send UpdateElev command to mediator
            Results.NoContent();
        };
    }
}