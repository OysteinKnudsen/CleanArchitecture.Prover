namespace CleanArchitecture.Prover.Domain.ValueTypes;

public record PrøvePeriode
{
    public DateTimeOffset Start { get; }
    public DateTimeOffset Slutt { get; }

    public PrøvePeriode(DateTimeOffset Start, DateTimeOffset Slutt)
    {
        if (Start >= Slutt)
        {
           throw new ArgumentException($"{nameof(Start)} must be before {nameof(Slutt)}");
        }

        this.Start = Start;
        this.Slutt = Slutt;
    }
}
