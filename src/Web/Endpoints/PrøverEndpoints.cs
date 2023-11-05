using CleanArchitecture.Prover.Application.Prøver.Queries;
using CleanArchitecture.Prover.Domain.ValueTypes;
using CleanArchitecture.Prover.Web.ViewModels;
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
            .Produces<PrøveViewModel>();;
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
}