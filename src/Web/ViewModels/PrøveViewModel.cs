using CleanArchitecture.Prover.Domain.Entities;

namespace CleanArchitecture.Prover.Web.ViewModels;

public record PrøveViewModel(int Id, string Navn, DateTimeOffset Start, DateTimeOffset Slutt, int Trinn, string Fag)
{
    public static PrøveViewModel From(Prøve prøve)
    {
        return new PrøveViewModel(
            prøve.PrøveId,
            prøve.Navn,
            prøve.PrøvePeriode.Start,
            prøve.PrøvePeriode.Slutt,
            prøve.Trinn,
            Enum.GetName(prøve.Fag) ?? string.Empty);
    }
}