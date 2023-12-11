using CleanArchitecture.Prover.Domain.Entities;

namespace CleanArchitecture.Prover.Web.Models;

public record PrøveViewModel(string Id, string Navn, DateTimeOffset Start, DateTimeOffset Slutt, int Trinn, string Fag)
{
    public static PrøveViewModel From(Prøve prøve)
    {
        return new PrøveViewModel(
            prøve.Id,
            prøve.Navn,
            prøve.PrøvePeriode.Start,
            prøve.PrøvePeriode.Slutt,
            prøve.Trinn,
            Enum.GetName(prøve.Fag) ?? string.Empty);
    }
}