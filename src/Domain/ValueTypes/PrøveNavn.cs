namespace CleanArchitecture.Prover.Domain.ValueTypes;

public record PrøveNavn(string Value)
{
    public static PrøveNavn From(string value) => new PrøveNavn(value);
}

