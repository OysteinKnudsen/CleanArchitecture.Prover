namespace CleanArchitecture.Prover.Web.Models;

public record CreatePrøveModel(string Navn, int Trinn, DateTimeOffset Fra, DateTimeOffset Til, string Fag);