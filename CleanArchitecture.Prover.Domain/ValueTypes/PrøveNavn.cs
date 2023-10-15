namespace CleanArchitecture.Prover.Domain.ValueTypes;

public record ProveNavn(string Value)
{
    public static ProveNavn From(string value) => new ProveNavn(value);
}