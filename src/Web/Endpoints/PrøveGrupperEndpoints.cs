using System.Net;
using CleanArchitecture.Prover.Application.Prøver;
using CleanArchitecture.Prover.Web.Models;

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
    
    private static Action<CreatePrøveGruppeModel, IPrøveGruppeService, CancellationToken> CreatePrøveGruppe()
    {
        return (CreatePrøveGruppeModel prøveGruppe, IPrøveGruppeService prøveGruppeService,
            CancellationToken cancellationToken) =>
        {
            //TODO: Send CreatePrøveGruppe command to mediator
            Results.Accepted();
        };
    }
    
    private static Action<int, UpdatePrøveGruppeModel, IPrøveGruppeService, CancellationToken> UpdatePrøveGruppeStatus()
    {
        return (int id, UpdatePrøveGruppeModel prøveGruppe, IPrøveGruppeService prøveGruppeService, CancellationToken cancellationToken) =>
        {
            //TODO: Send UpdatePrøveGruppe command to mediator
            Results.NoContent();
        };
    }
}