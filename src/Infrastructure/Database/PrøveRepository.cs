using CleanArchitecture.Prover.Application.Prøver;
using CleanArchitecture.Prover.Application.Prøver.Exceptions;
using CleanArchitecture.Prover.Domain.Entities;
using CleanArchitecture.Prover.Domain.ValueTypes;

namespace CleanArchitecture.Prover.Infrastructure.Database;

internal class PrøveRepository : IPrøveRepository
{
    private readonly IList<Prøve> _prøver = new List<Prøve>()
    {
        new (PrøveId.From(1), PrøveNavn.From("Engelsk 8.trinn"),new PrøvePeriode(DateTimeOffset.Now, DateTimeOffset.Now + TimeSpan.FromDays(32)), Trinn.From(8), Fag.Engelsk),
        new (PrøveId.From(2), PrøveNavn.From("Matematikk 5.trinn"),new PrøvePeriode(DateTimeOffset.Now, DateTimeOffset.Now + TimeSpan.FromDays(32)), Trinn.From(5), Fag.Matematikk),
        new (PrøveId.From(3), PrøveNavn.From("Norsk 2.trinn"),new PrøvePeriode(DateTimeOffset.Now, DateTimeOffset.Now + TimeSpan.FromDays(32)), Trinn.From(2), Fag.Norsk),
    };

    public Task<IEnumerable<Prøve>> GetAllAsync(CancellationToken cancellationToken)
    {
        return Task.FromResult((IEnumerable<Prøve>) _prøver);
    }

    public Task<Prøve> GetByIdAsync(PrøveId prøveId, CancellationToken cancellationToken)
    {
        if (_prøver is null)
        {
            throw new PrøveNotFoundException(prøveId);
        }
        
        var foundPrøve = _prøver.FirstOrDefault(prove => prove.Id == prøveId.Id);
        return foundPrøve is null
            ? throw new PrøveNotFoundException(prøveId)
            : Task.FromResult(foundPrøve);
    }

    public Task<Prøve> CreateAsync(PrøveNavn navn, Trinn trinn, Fag fag, PrøvePeriode prøvePeriode, CancellationToken cancellationToken)
    {
        var newProveId = _prøver.Count + 1;
        var newProve = new Prøve(new PrøveId(newProveId), navn, prøvePeriode, trinn, fag);
        _prøver.Add(newProve);
        return Task.FromResult(newProve);
    }
}