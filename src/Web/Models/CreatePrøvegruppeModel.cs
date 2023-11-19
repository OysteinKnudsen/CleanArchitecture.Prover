namespace CleanArchitecture.Prover.Web.Models;

public record CreatePrøvegruppeModel(int PrøveId, int LærerId, IEnumerable<int> Elever);