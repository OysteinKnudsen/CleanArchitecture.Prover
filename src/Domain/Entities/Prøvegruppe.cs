using CleanArchitecture.Prover.Domain.ValueTypes;

namespace CleanArchitecture.Prover.Domain.Entities;

public record Prøvegruppe (Prøve Prøve, Lærer Prøvegruppeansvarlig, IList<Prøvegjennomføring> Prøvegjennomføringer, PrøvegruppeStatus Status);