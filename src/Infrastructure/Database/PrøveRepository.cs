using CleanArchitecture.Prover.Application.Prøver;
using CleanArchitecture.Prover.Application.Prøver.Exceptions;
using CleanArchitecture.Prover.Domain.Entities;
using CleanArchitecture.Prover.Domain.ValueTypes;

namespace CleanArchitecture.Prover.Infrastructure.Database;

internal class PrøveRepository : IPrøveRepository
{
    private readonly IList<Prøve> _prøver = new List<Prøve>
    {
        new (new PrøveId("a9aef14a-8ed9-4028-ae00-0ddf75cabb10"), new PrøveNavn("Engelsk 8.trinn"),new PrøvePeriode(DateTimeOffset.Now, DateTimeOffset.Now + TimeSpan.FromDays(32)), new Trinn(8), Fag.Engelsk),
        new (new PrøveId("c3ac1cc0-f743-4e94-a0f8-c20daba06156"), new PrøveNavn("Matematikk 5.trinn"),new PrøvePeriode(DateTimeOffset.Now, DateTimeOffset.Now + TimeSpan.FromDays(32)), new Trinn(5), Fag.Matematikk),
        new (new PrøveId("a089d571-e5f2-436d-91d0-b7f94908295a"), new PrøveNavn("Norsk 2.trinn"),new PrøvePeriode(DateTimeOffset.Now, DateTimeOffset.Now + TimeSpan.FromDays(32)), new Trinn(2), Fag.Norsk),
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