namespace CleanArchitecture.Prover.Domain.ValueTypes;

public record PrøveNavn(string Navn)
{
    public static PrøveNavn From(string value) => new PrøveNavn(value);
    public static explicit operator PrøveNavn(string navn) => new(navn);
    public static implicit operator string(PrøveNavn prøveNavn) => prøveNavn.Navn;
}

