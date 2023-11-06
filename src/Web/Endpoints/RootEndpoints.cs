using System.Reflection;
using CleanArchitecture.Prover.Web.Extensions;

namespace CleanArchitecture.Prover.Web.Endpoints;

internal static class RootEndpoint
{
    public static IEndpointRouteBuilder AddRootEndpoint(this IEndpointRouteBuilder app)
    {
        app.Map("/", () => $"CleanArchitecture.Prover.Web v.{Assembly.GetExecutingAssembly().GetCurrentSemVer()}");
        return app;
    }
}