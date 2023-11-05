using CleanArchitecture.Prover.Domain.ValueTypes;

namespace CleanArchitecture.Prover.Domain.Entities;

public record Prøve(PrøveId PrøveId, PrøveNavn Navn, PrøvePeriode PrøvePeriode, Trinn Trinn, Fag Fag);