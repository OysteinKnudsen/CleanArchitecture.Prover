namespace CleanArchitecture.Prover.Domain.ValueTypes;

public record PrøvegruppeId(int Value)
{
    public static implicit operator int(PrøvegruppeId prøvegruppeId) => prøvegruppeId.Value;
    public static explicit operator PrøvegruppeId(int prøvegruppeId) => new(prøvegruppeId);
}
