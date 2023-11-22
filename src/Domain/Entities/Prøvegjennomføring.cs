using CleanArchitecture.Prover.Domain.ValueTypes;

namespace CleanArchitecture.Prover.Domain.Entities;

/// <summary>
/// Prøvegjennomføring representerer en elev sin gjennomføring på en prøve, men det går kanskje fint?
/// </summary>
public record Prøvegjennomføring (ElevId Elev, Gjennomføringsstatus Gjennomføringsstatus);
// TODO: denne modellen gir ikke mening uten en referanse til en prøve.