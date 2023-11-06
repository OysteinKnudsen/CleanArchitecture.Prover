using CleanArchitecture.Prover.Domain.ValueTypes;

namespace CleanArchitecture.Prover.Domain.Entities;

public record Klasse (Lærer Lærer, Trinn Trinn, IEnumerable<Elev> Elever);