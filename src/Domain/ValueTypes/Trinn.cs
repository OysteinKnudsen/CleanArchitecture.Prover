namespace CleanArchitecture.Prover.Domain.ValueTypes;

public record Trinn
{
    public int Value { get; init; }
    public Trinn(int value)
    {
        if (value is > 10 or < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(value), value, $"Trinn must be a value from 1 to 10");
        }
        Value = value;
    }
    public static explicit operator Trinn(int value) => new(value);
    public static implicit operator int(Trinn trinn) => trinn.Value;
}