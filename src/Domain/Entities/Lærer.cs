using CleanArchitecture.Prover.Domain.ValueTypes;

namespace CleanArchitecture.Prover.Domain.Entities;

public record Lærer(LærerId LærerId, LærerNavn Navn, Klasse Klasseansvar);