using CleanArchitecture.Prover.Application.Prøver;

namespace CleanArchitecture.Prover.Web.Endpoints;

internal static class PrøverEndpoints
{
    public static void AddPrøverEndpoints(this IEndpointRouteBuilder app)
    {
        //app.MapGet("api/prøver", (IGetPrøver getPrøver) => Results.Ok(getPrøver.GetAllPrøver()));
        app.MapGet("api/prøver/{id}", (int id) => Results.Ok());
    }
}