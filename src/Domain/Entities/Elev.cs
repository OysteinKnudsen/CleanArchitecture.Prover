using CleanArchitecture.Prover.Domain.ValueTypes;

namespace CleanArchitecture.Prover.Domain.Entities;

public record Elev (ElevId ElevId, ElevNavn Navn, Klasse Klasse, IEnumerable<Prøvegjennomføring>? Prøvegjennomføringer);