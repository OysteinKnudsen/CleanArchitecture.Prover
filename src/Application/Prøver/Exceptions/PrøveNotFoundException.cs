using CleanArchitecture.Prover.Domain.ValueTypes;

namespace CleanArchitecture.Prover.Application.Prøver.Exceptions;

public class PrøveNotFoundException : Exception
{
    public PrøveId PrøveId { get; }

    public PrøveNotFoundException(PrøveId prøveId) : this(prøveId, string.Empty)
    {
        
    }

    public PrøveNotFoundException(PrøveId prøveId, string message) : base(message)
    {
        PrøveId = prøveId;
    }
}