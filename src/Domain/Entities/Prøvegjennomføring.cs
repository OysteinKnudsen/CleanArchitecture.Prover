using CleanArchitecture.Prover.Domain.ValueTypes;

namespace CleanArchitecture.Prover.Domain.Entities;

/// <summary>
/// Prøvegjennomføring representerer en elev sin gjennomføring på en prøve. 
/// </summary>
public record Prøvegjennomføring (ElevId Elev, Gjennomføringsstatus Gjennomføringsstatus);