namespace CleanArchitecture.Prover.Web.Models;

public record CreatePrøvegruppeModel(int PrøveId, int LærerId, IEnumerable<int> Elever);
// TODO: Utvid denne modellen til å inkludere nødvendig data for å opprette en prøvegruppe
