namespace CleanArchitecture.Prover.Domain.ValueTypes;

public record PrøveId(string Id)
{
    public static PrøveId From(string id) => new PrøveId(id);
    public static explicit operator PrøveId(string id) => new(id);
    public static implicit operator string(PrøveId prøveId) => prøveId.Id;
}