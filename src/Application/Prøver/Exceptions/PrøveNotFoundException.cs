using CleanArchitecture.Prover.Domain.ValueTypes;

namespace CleanArchitecture.Prover.Application.Prøver.Exceptions;

public class PrøveNotFoundException : Exception
{
    public PrøveId PrøveId { get; } = default!;

    public PrøveNotFoundException(PrøveId prøveId) : this(prøveId, string.Empty)
    {
        
    }

    public PrøveNotFoundException(PrøveId prøveId, string message) : base(message)
    {
        PrøveId = prøveId;
    }

    public PrøveNotFoundException()
    {
    }

    public PrøveNotFoundException(string message) : base(message)
    {
    }

    public PrøveNotFoundException(string message, Exception innerException) : base(message, innerException)
    {
    }
}