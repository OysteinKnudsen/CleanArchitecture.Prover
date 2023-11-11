namespace CleanArchitecture.Prover.Domain.ValueTypes;

public record ElevId(int Value)
{
    public static implicit operator int (ElevId elevId) => elevId.Value;
    public static explicit operator ElevId(int elevId) => new(elevId);
}