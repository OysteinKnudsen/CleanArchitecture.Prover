using CleanArchitecture.Prover.Domain.ValueTypes;

namespace CleanArchitecture.Prover.Domain.Entities;

public record Klasse (KlasseId Id, LærerId Lærer, Trinn Trinn, IEnumerable<ElevId> Elever);