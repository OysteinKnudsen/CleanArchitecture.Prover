namespace CleanArchitecture.Prover.Infrastructure.Database.Models;

internal class InMemoryPrøve
{
    public int Id { get; set; }
    public string Navn { get; set; } = default!;
    public InMemoryPrøvePeriode PrøvePeriode { get; set; } = default!;
    public int Trinn { get; set; }
    public string Fag { get; set; } = default!;
}