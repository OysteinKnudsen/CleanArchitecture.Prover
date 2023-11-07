namespace CleanArchitecture.Prover.Domain.ValueTypes;

public record KlasseId(int Value)
{
    public static implicit operator int (KlasseId klasseId) => klasseId.Value;
    public static explicit operator KlasseId(int klasseId) => new(klasseId);
}