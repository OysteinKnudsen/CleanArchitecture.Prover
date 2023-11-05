namespace CleanArchitecture.Prover.Application.Prøver.Exceptions;

public class FagNotFoundException : Exception
{
    public string Fag { get; }

    public FagNotFoundException(string fag, string message) : base(message)
    {
        Fag = fag;
    }

    public FagNotFoundException(string fag) : this(fag, string.Empty)
    {
        
    }
}