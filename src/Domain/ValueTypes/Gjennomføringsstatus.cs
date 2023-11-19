namespace CleanArchitecture.Prover.Domain.ValueTypes;

/// <summary>
/// Representerer en elev sin gjennomføringsstatus på en prøve.
/// </summary>
public enum Gjennomføringsstatus
{
    IkkeStartet = 0,
    Startet = 1,
    Levert = 2
}