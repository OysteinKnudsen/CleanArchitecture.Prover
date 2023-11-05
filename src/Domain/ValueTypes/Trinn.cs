namespace CleanArchitecture.Prover.Domain.ValueTypes;

public record Trinn(int Value)
{
    public static Trinn From(int value) => new Trinn(value);
}