using CleanArchitecture.Prover.Application.Prøver.Exceptions;
using CleanArchitecture.Prover.Domain.ValueTypes;

namespace CleanArchitecture.Prover.Infrastructure.Database;

internal static class FagFactory
{
    public static Fag GetFag(string fag)
    {
        return fag switch
        {
            "Matematikk" => Fag.Matematikk,
            "Norsk" => Fag.Norsk,
            "Engelsk" => Fag.Engelsk,
            _ => throw new FagNotFoundException(fag)
        };
    }
}