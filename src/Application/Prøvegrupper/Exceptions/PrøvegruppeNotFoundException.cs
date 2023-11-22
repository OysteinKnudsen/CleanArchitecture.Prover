using CleanArchitecture.Prover.Domain.ValueTypes;

namespace CleanArchitecture.Prover.Application.Prøvegrupper.Exceptions;

public class PrøvegruppeNotFoundException : Exception
{
    public PrøvegruppeNotFoundException(string message) : base(message){}
}