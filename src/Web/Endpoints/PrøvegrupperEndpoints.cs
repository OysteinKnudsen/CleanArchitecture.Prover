using System.Net;
using CleanArchitecture.Prover.Application.Prøvegrupper;
using CleanArchitecture.Prover.Application.Prøvegrupper.Services;
using CleanArchitecture.Prover.Application.Prøver;
using CleanArchitecture.Prover.Application.Prøver.Exceptions;
using CleanArchitecture.Prover.Domain.ValueTypes;
using CleanArchitecture.Prover.Web.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CleanArchitecture.Prover.Web.Endpoints;

internal static class PrøvegrupperEndpoints
{
    public static IEndpointRouteBuilder AddPrøvegrupperEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("api/prøvegrupper/{id}", GetPrøvegruppe())
            .WithTags("Prøvegrupper")
            .WithName("GetPrøvegruppe")
            .Produces<PrøvegruppeViewModel>()
            .Produces((int) HttpStatusCode.NotFound);

        app.MapPost("api/prøvegrupper", CreatePrøvegruppe())
            .WithTags("Prøvegrupper")
            .WithName("CreatePrøvegruppe")
            .Produces((int) HttpStatusCode.Created);

        app.MapPut("api/prøvegrupper/{id}", UpdatePrøvegruppeStatus())
            .WithTags("Prøvegrupper")
            .WithName("UpdatePrøvegruppe")
            .Produces((int)HttpStatusCode.NoContent);

        return app;
    }
    
    private static Func<CreatePrøvegruppeModel, IPrøvegruppeService, CancellationToken, Task<IResult>> CreatePrøvegruppe()
    {
        return async (prøveGruppe, prøveGruppeService, cancellationToken) =>
        {
                var elever = prøveGruppe.Elever.Select(e => new ElevId(e));
                var created = await prøveGruppeService.CreateAsync(new PrøveId(prøveGruppe.PrøveId), new LærerId(prøveGruppe.LærerId), elever,
                    cancellationToken);
                return Results.Created(new Uri(string.Empty), PrøvegruppeViewModel.From(created));
        };
    }
    
    private static Action<int, UpdatePrøvegruppeModel, IPrøvegruppeService, CancellationToken> UpdatePrøvegruppeStatus()
    {
        return (int id, UpdatePrøvegruppeModel prøveGruppe, IPrøvegruppeService prøveGruppeService, CancellationToken cancellationToken) =>
        {
            Results.NoContent();
        };
    }
    
    private static Action<int, IPrøvegruppeService, CancellationToken> GetPrøvegruppe()
    {
        return (int id, IPrøvegruppeService prøveGruppeService, CancellationToken cancellationToken) =>
        {
            Results.NoContent();
        };
    }
}