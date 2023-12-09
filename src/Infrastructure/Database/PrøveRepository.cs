using CleanArchitecture.Prover.Application.Prøver;
using CleanArchitecture.Prover.Application.Prøver.Exceptions;
using CleanArchitecture.Prover.Domain.Entities;
using CleanArchitecture.Prover.Domain.ValueTypes;

namespace CleanArchitecture.Prover.Infrastructure.Database;

internal class PrøveRepository : IPrøveRepository
{
    private readonly IList<Prøve> _prøver = new List<Prøve>
    {
        new (PrøveId.From("a9aef14a-8ed9-4028-ae00-0ddf75cabb10"), PrøveNavn.From("Engelsk 8.trinn"),new PrøvePeriode(DateTimeOffset.Now, DateTimeOffset.Now + TimeSpan.FromDays(32)), Trinn.From(8), Fag.Engelsk),
        new (PrøveId.From("c3ac1cc0-f743-4e94-a0f8-c20daba06156"), PrøveNavn.From("Matematikk 5.trinn"),new PrøvePeriode(DateTimeOffset.Now, DateTimeOffset.Now + TimeSpan.FromDays(32)), Trinn.From(5), Fag.Matematikk),
        new (PrøveId.From("a089d571-e5f2-436d-91d0-b7f94908295a"), PrøveNavn.From("Norsk 2.trinn"),new PrøvePeriode(DateTimeOffset.Now, DateTimeOffset.Now + TimeSpan.FromDays(32)), Trinn.From(2), Fag.Norsk),
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

    public Task<Prøve> CreateAsync(Prøve prøve)
    {
        _prøver.Add(prøve);
        return Task.FromResult(prøve);
    }
}