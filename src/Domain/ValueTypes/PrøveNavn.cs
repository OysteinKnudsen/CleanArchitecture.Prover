namespace CleanArchitecture.Prover.Domain.ValueTypes;

public record PrøveNavn(string Navn)
{
    public static explicit operator PrøveNavn(string navn) => new(navn);
    public static implicit operator string(PrøveNavn prøveNavn) => prøveNavn.Navn;
}

