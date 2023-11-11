using CleanArchitecture.Prover.Domain.Entities;
using CleanArchitecture.Prover.Domain.ValueTypes;

namespace CleanArchitecture.Prover.Application.Prøver.Services;

internal class PrøveService : IPrøveService
{
    private readonly IPrøveRepository _prøveRepository;

    public PrøveService(IPrøveRepository prøveRepository)
    {
        _prøveRepository = prøveRepository;
    }
    
    public Task<IEnumerable<Prøve>> GetAllAsync(CancellationToken cancellationToken)
    {
        return _prøveRepository.GetAllAsync(cancellationToken);
    }

    public Task<Prøve> GetByIdAsync(PrøveId prøveId, CancellationToken cancellationToken)
    {
        return _prøveRepository.GetByIdAsync(prøveId, cancellationToken);
    }
}