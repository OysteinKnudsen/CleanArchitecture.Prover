using CleanArchitecture.Prover.Domain.Entities;
using CleanArchitecture.Prover.Domain.ValueTypes;

namespace CleanArchitecture.Prover.Application.Prøver.Services;

internal class PrøveService(IPrøveRepository prøveRepository) : IPrøveService
{
    public Task<IEnumerable<Prøve>> GetAllAsync(CancellationToken cancellationToken)
    {
        return prøveRepository.GetAllAsync(cancellationToken);
    }

    public Task<Prøve> GetByIdAsync(PrøveId prøveId, CancellationToken cancellationToken)
    {
        return prøveRepository.GetByIdAsync(prøveId, cancellationToken);
    }

    public Task<Prøve> CreateAsync(PrøveNavn navn, Trinn trinn, Fag fag, DateTimeOffset start, DateTimeOffset slutt,
        CancellationToken cancellationToken)
    {
        /*
         * TODO: Implementer opprettelse og lagring av en prøve.
         * Regel: Trinn skal være mellom 1 og 10
         * Regel: Fra-dato skal være i fremtiden
         * Regel: Fra-dato skal være før til-dato
         */ 
        
        throw new NotImplementedException();
    }
}