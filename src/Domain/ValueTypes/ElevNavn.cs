namespace CleanArchitecture.Prover.Domain.ValueTypes;

public record ElevNavn(string Fornavn, string Etternavn)
{
    public override string ToString()
    {
        return $"{Fornavn} {Etternavn}";
    }
}
