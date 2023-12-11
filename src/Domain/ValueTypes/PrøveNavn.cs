namespace CleanArchitecture.Prover.Domain.ValueTypes;

public record PrøveNavn
{
    private string Value { get; init; }

    public PrøveNavn(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException("PrøveNavn value cannot be null or empty", nameof(value));
        }

        Value = value;
    }
    public static explicit operator PrøveNavn(string navn) => new(navn);
    public static implicit operator string(PrøveNavn prøveNavn) => prøveNavn.Value;
}

