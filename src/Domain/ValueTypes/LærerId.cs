namespace CleanArchitecture.Prover.Domain.ValueTypes;

public record LærerId(int Value)
{
    public static implicit operator int(LærerId lærerId) => lærerId.Value;
    public static explicit operator LærerId(int lærerId) => new(lærerId);
}