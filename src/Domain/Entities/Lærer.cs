using CleanArchitecture.Prover.Domain.ValueTypes;

namespace CleanArchitecture.Prover.Domain.Entities;

public record Lærer(LærerId Id, LærerNavn Navn, KlasseId Klasseansvar);