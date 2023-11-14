using System.Net;
using CleanArchitecture.Prover.Application.Prøver;
using CleanArchitecture.Prover.Domain.ValueTypes;
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
    
    private static Action<CreatePrøvegruppeModel, IPrøvegruppeService, CancellationToken> CreatePrøveGruppe()
    {
        return (prøveGruppe, prøveGruppeService,
            cancellationToken) =>
        {
            var elevIds = prøveGruppe.ElevIds.Select(id => (ElevId)id);
            prøveGruppeService.CreateAsync((PrøveId) prøveGruppe.PrøveId, (LærerId) prøveGruppe.LærerId, elevIds,
                cancellationToken);
            Results.Accepted();
        };
    }
    
    private static Action<int, UpdatePrøvegruppeModel, IPrøvegruppeService, CancellationToken> UpdatePrøveGruppeStatus()
    {
        return (int id, UpdatePrøvegruppeModel prøveGruppe, IPrøvegruppeService prøveGruppeService, CancellationToken cancellationToken) =>
        {
            Results.NoContent();
        };
    }
}