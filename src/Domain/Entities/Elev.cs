using CleanArchitecture.Prover.Domain.ValueTypes;

namespace CleanArchitecture.Prover.Domain.Entities;

public record Elev (ElevId Id, ElevNavn Navn, KlasseId Klasse, IEnumerable<Prøvegjennomføring>? Prøvegjennomføringer);