namespace CleanArchitecture.Prover.Domain.ValueTypes;

public record Trinn(int Value)
{
    public static explicit operator Trinn(int value) => new(value);
    public static implicit operator int(Trinn trinn) => trinn.Value;
}