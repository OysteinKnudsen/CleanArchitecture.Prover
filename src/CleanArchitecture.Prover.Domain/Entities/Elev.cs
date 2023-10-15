using CleanArchitecture.Prover.Domain.ValueTypes;

namespace CleanArchitecture.Prover.Domain.Entities;

public class Elev (ElevNavn Navn, Klasse Klasse, IEnumerable<Prøvegjennomføring>? Prøvegjennomføringer);