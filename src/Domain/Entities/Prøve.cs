using CleanArchitecture.Prover.Domain.ValueTypes;

namespace CleanArchitecture.Prover.Domain.Entities;

public record Prøve(PrøveId Id, PrøveNavn Navn, PrøvePeriode PrøvePeriode, Trinn Trinn, Fag Fag)
{
    public bool ErAktiv => DateTime.Now <= PrøvePeriode.Slutt && DateTime.Now >= PrøvePeriode.Start;
}