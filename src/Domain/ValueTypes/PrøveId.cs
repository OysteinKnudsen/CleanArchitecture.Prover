namespace CleanArchitecture.Prover.Domain.ValueTypes;

public record PrøveId(int Id)
{
    public static PrøveId From(int id) => new PrøveId(id);
    public static explicit operator PrøveId(int id) => new(id);
    public static implicit operator int(PrøveId prøveId) => prøveId.Id;
}