using CleanArchitecture.Prover.Domain.ValueTypes;

namespace CleanArchitecture.Prover.Domain.Entities;

/// <summary>
/// En prøvegruppe er en gruppe elever som skal gjennomføre en prøve.
/// Prøvegruppen har en ansvarlig lærer for gjennomføringen.  
/// </summary>
public record Prøvegruppe (PrøveId Prøve, LærerId Prøvegruppeansvarlig, IList<Prøvegjennomføring> Prøvegjennomføringer, PrøvegruppeStatus Status);