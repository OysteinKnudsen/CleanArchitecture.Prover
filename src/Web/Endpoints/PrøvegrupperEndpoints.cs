using System.Net;
using CleanArchitecture.Prover.Application.Prøvegrupper;
using CleanArchitecture.Prover.Application.Prøvegrupper.Services;
using CleanArchitecture.Prover.Application.Prøver;
using CleanArchitecture.Prover.Application.Prøver.Exceptions;
using CleanArchitecture.Prover.Domain.Entities;
using CleanArchitecture.Prover.Domain.ValueTypes;
using CleanArchitecture.Prover.Web.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Prover.Web.Endpoints;

internal static class PrøvegrupperEndpoints
{
    public static IEndpointRouteBuilder AddPrøvegrupperEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("api/prøvegrupper", GetPrøvegrupper())
            .WithTags("Prøvegrupper")
            .WithName("GetPrøvegrupper")
            .Produces<IEnumerable<PrøvegruppeViewModel>>();
        
        app.MapGet("api/prøvegrupper/{id}", GetPrøvegruppe())
            .WithTags("Prøvegrupper")
            .WithName("GetPrøvegruppe")
            .Produces<PrøvegruppeViewModel>();

        app.MapPost("api/prøvegrupper", CreatePrøvegruppe())
            .WithTags("Prøvegrupper")
            .WithName("CreatePrøvegruppe")
            .Produces((int) HttpStatusCode.Created);

        app.MapPatch("api/prøvegrupper/{id}", UpdatePrøvegruppeStatus())
            .WithTags("Prøvegrupper")
            .WithName("UpdatePrøvegruppe")
            .Produces<PrøvegruppeViewModel>();

        return app;
    }
    
    private static Func<CreatePrøvegruppeModel, IPrøvegruppeService, CancellationToken, Task<IResult>> CreatePrøvegruppe()
    {
        return async (prøveGruppe, prøveGruppeService, cancellationToken) =>
        {
                var elever = prøveGruppe.Elever.Select(e => new ElevId(e));
                await prøveGruppeService.CreateAsync(new PrøveId(prøveGruppe.PrøveId), new LærerId(prøveGruppe.LærerId), elever,
                    cancellationToken);
                return Results.Created();
        };
    }
    
    private static Func<int, UpdatePrøvegruppeModel, IPrøvegruppeService, CancellationToken, Task<IResult>> UpdatePrøvegruppeStatus()
    {
        return async (int id, UpdatePrøvegruppeModel prøveGruppe, IPrøvegruppeService prøveGruppeService, CancellationToken cancellationToken) =>
        {
            var updatedPrøvegruppe = await prøveGruppeService.UpdateStatusAsync(new PrøvegruppeId(id), (PrøvegruppeStatus)prøveGruppe.Prøvegruppestatus, cancellationToken);
            return Results.Ok(updatedPrøvegruppe);
        };
    }
    
    private static Func<int, IPrøvegruppeService, CancellationToken, Task<IResult>> GetPrøvegruppe()
    {
        return async (id, prøveGruppeService, cancellationToken) =>
        {
            var provegruppe = await prøveGruppeService.GetByIdAsync(new PrøvegruppeId(id), cancellationToken);
            return Results.Ok(provegruppe);
        };
    }
    
    
    private static Func<IPrøvegruppeService, CancellationToken, Task<IResult>> GetPrøvegrupper()
    {
        return async (prøveGruppeService, cancellationToken) =>
        {
            var provegrupper = await prøveGruppeService.GetAllAsync(cancellationToken);
            return Results.Ok(provegrupper);
        };
    }
}