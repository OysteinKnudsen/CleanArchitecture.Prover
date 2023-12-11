using System.Net;
using CleanArchitecture.Prover.Application.Prøvegrupper.Services;
using CleanArchitecture.Prover.Web.Models;

namespace CleanArchitecture.Prover.Web.Endpoints;

internal static class PrøvegrupperEndpoints
{
    public static IEndpointRouteBuilder AddPrøvegrupperEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("api/prøvegrupper", CreatePrøvegruppe())
            .WithTags("PrøveGrupper")
            .WithName("CreatePrøveGruppe")
            .Produces((int)HttpStatusCode.Created);

        app.MapPatch("api/prøvegrupper/{id}", UpdatePrøvegruppeStatus())
            .WithTags("PrøveGrupper")
            .WithName("UpdatePrøveGruppeStatus")
            .Produces<PrøvegruppeViewModel>();
        
        app.MapGet("api/prøvegrupper/{id}", GetPrøvegruppe())
            .WithTags("PrøveGrupper")
            .WithName("GetPrøvegruppe")
            .Produces<PrøvegruppeViewModel>();

        return app;
    }

    private static Func<int, IPrøvegruppeService, IResult> GetPrøvegruppe()
    {
        return (prøvegruppeId, prøvegruppeService) =>
        {
            return Results.Ok();
        };
    }

    private static Func<CreatePrøvegruppeModel, IPrøvegruppeService, IResult> CreatePrøvegruppe()
    {
        return (CreatePrøvegruppeModel prøveGruppe, IPrøvegruppeService prøveGruppeService) =>
        {
            /*
             * TODO: Definer CreatePrøvegruppeModel med nødvendig data for å opprette en prøvegruppe
             * og implementer CreateAsync i prøveGruppeService. 
             */
            return Results.Created();
        };
    }
    
    private static Func<int, UpdatePrøvegruppeModel, IPrøvegruppeService, IResult> UpdatePrøvegruppeStatus()
    {
        return (int id, UpdatePrøvegruppeModel prøveGruppe, IPrøvegruppeService prøveGruppeService) =>
        {
            /*
             * TODO: Definer UpdatePrøvegruppeModel med nødvendig data for å oppdatere status på en prøvegruppe
             * og implementer UpdatePrøvegruppeStatus i PrøveGruppeService.
             */
            return Results.Ok<PrøvegruppeViewModel>(null);
        };
    }
}