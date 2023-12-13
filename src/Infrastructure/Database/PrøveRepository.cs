using CleanArchitecture.Prover.Application.Prøver;
using CleanArchitecture.Prover.Application.Prøver.Exceptions;
using CleanArchitecture.Prover.Domain.Entities;
using CleanArchitecture.Prover.Domain.ValueTypes;

namespace CleanArchitecture.Prover.Infrastructure.Database;

internal class PrøveRepository : IPrøveRepository
{
    private readonly IList<Prøve> _prøver = new List<Prøve>
    {
        new (new PrøveId(1), new PrøveNavn("Engelsk 8.trinn"),new PrøvePeriode(DateTimeOffset.Now, DateTimeOffset.Now + TimeSpan.FromDays(32)), new Trinn(8), Fag.Engelsk),
        new (new PrøveId(2), new PrøveNavn("Matematikk 5.trinn"),new PrøvePeriode(DateTimeOffset.Now, DateTimeOffset.Now + TimeSpan.FromDays(32)), new Trinn(5), Fag.Matematikk),
        new (new PrøveId(3), new PrøveNavn("Norsk 2.trinn"),new PrøvePeriode(DateTimeOffset.Now, DateTimeOffset.Now + TimeSpan.FromDays(32)), new Trinn(2), Fag.Norsk),
    };

    public Task<IEnumerable<Prøve>> GetAllAsync()
    {
        return Task.FromResult((IEnumerable<Prøve>)_prøver);
    }

    public Task<Prøve> GetByIdAsync(PrøveId prøveId)
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

    public Task<Prøve> SaveAsync(Prøve prøve)
    {
        _prøver.Add(prøve);
        return Task.FromResult(prøve);
    }
}