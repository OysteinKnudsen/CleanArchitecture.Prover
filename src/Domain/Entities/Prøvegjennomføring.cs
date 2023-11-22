using CleanArchitecture.Prover.Domain.ValueTypes;

namespace CleanArchitecture.Prover.Domain.Entities;

/// <summary>
/// Prøvegjennomføring representerer en elev sin gjennomføring på en prøve, men det går kanskje fint?
/// </summary>
public record Prøvegjennomføring (PrøveId PrøveId, ElevId ElevId, Gjennomføringsstatus Gjennomføringsstatus);
