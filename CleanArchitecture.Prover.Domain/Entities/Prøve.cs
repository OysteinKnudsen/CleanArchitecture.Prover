using CleanArchitecture.Prover.Domain.ValueTypes;

namespace CleanArchitecture.Prover.Domain.Entities;

public class Prove
{
    public ProveNavn Navn { get; set; }
    public PrøvePeriode PrøvePeriode { get; set; }
    public Trinn Trinn { get; set; }
}