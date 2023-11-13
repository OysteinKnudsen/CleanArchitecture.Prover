namespace CleanArchitecture.Prover.Domain.ValueTypes;

public record LærerNavn(string Fornavn, string Etternavn)
{
    public override string ToString()
    {
        return $"{Fornavn} {Etternavn}";
    }
}