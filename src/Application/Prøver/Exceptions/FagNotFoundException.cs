namespace CleanArchitecture.Prover.Application.Prøver.Exceptions;

public class FagNotFoundException : Exception
{
    public string Fag { get; } = default!;

    public FagNotFoundException(string fag, string message) : base(message)
    {
        Fag = fag;
    }

    public FagNotFoundException(string fag) : this(fag, string.Empty)
    {
        
    }

    public FagNotFoundException()
    {
    }

    public FagNotFoundException(string message, Exception innerException) : base(message, innerException)
    {
    }
}