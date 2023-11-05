using System.Net;
using CleanArchitecture.Prover.Web.Models;
using MediatR;

namespace CleanArchitecture.Prover.Web.Endpoints;

internal static class PrøveGrupperEndpoints
{
    public static IEndpointRouteBuilder AddPrøveGrupperEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("api/prøvegrupper", CreatePrøveGruppe())
            .WithTags("PrøveGrupper")
            .WithName("CreatePrøveGruppe")
            .Produces((int)HttpStatusCode.Accepted);

        app.MapPut("api/prøvegrupper/{id}", UpdatePrøveGruppeStatus())
            .WithTags("PrøveGrupper")
            .WithName("UpdatePrøveGruppeStatus")
            .Produces((int)HttpStatusCode.NoContent);

        return app;
    }
    
    private static Action<int, CreatePrøveGruppeModel, IMediator, CancellationToken> CreatePrøveGruppe()
    {
        return (int prøveId, CreatePrøveGruppeModel prøveGruppe, IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            //TODO: Send CreatePrøveGruppe command to mediator
            Results.Accepted();
        };
    }
    
    private static Action<int, UpdatePrøveGruppeModel, IMediator, CancellationToken> UpdatePrøveGruppeStatus()
    {
        return (int id, UpdatePrøveGruppeModel prøveGruppe, IMediator mediator, CancellationToken cancellationToken) =>
        {
            //TODO: Send UpdatePrøveGruppe command to mediator
            Results.NoContent();
        };
    }
}