namespace CleanArchitecture.Prover.Web.Models;

public record CreatePrøveModel(string Navn, int Trinn, int Fag, DateTimeOffset FraDato, DateTimeOffset TilDato);