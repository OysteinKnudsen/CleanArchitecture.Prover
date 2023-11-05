using CleanArchitecture.Prover.Domain.ValueTypes;

namespace CleanArchitecture.Prover.Domain.Entities;

public class Prøvegruppe (Prøve Prøve, Lærer Prøvegruppeansvarlig, IList<Prøvegjennomføring> Prøvegjennomføringer, PrøvegruppeStatus Status);